open System

let readList n =
    let rec readListRec n acc = 
        match n with
        |0 -> acc
        |k ->
            let el = Console.ReadLine() |> int
            let newAcc = acc@[el]
            readListRec (k-1) newAcc
    readListRec n []

let rec printList list =
    match list with
    |[] -> Console.ReadKey()
    |head::tail ->
        Console.WriteLine(head.ToString())
        printList tail
    
let rec reduce_list list (f: int->int->int) (condition: int->bool) acc =
    match list with
    | [] -> acc
    | head::tail ->
        let current = head
        let flag = condition current
        let newAcc = if condition current then f acc current else acc
        reduce_list tail f condition newAcc

let min_list list = 
    match list with
    | [] -> 0
    | head::tail -> reduce_list list (fun a b -> if a < b then a else b) (fun a -> true) head

let sum_even list = reduce_list list (+) (fun a -> a%2 = 0) 0

let count_odd list = reduce_list list (fun a b -> a+1) (fun a -> a%2 = 1) 0
//со встроенным List
let mostFrequentElement list =
    list
    |> List.countBy id
    |> List.maxBy snd
    |> fst

let countSquares list =
    let squares = list |> List.map (fun x -> x * x)
    list
    |> List.filter (fun x -> List.contains x squares)
    |> List.length

//10
let sumDigits n = 
        let rec loop acc = function
            | 0 -> acc
            | x -> loop (acc + x % 10) (x / 10)
        loop 0 (abs n)

let countDivisors n =
        if n = 0 then 0
        else
            let nAbs = abs n
            [1..nAbs] |> List.filter (fun x -> nAbs % x = 0) |> List.length
let createTuples (listA: int list) (listB: int list) (listC: int list) =
    let sortedA = listA |> List.sortDescending

    let sortedB = 
        listB 
        |> List.sortBy (fun x -> abs x |> (~-))  
        |> List.sortBy sumDigits               

    let sortedC = 
        listC 
        |> List.sortBy (fun x -> abs x |> (~-))  
        |> List.sortBy (fun x -> countDivisors x |> (~-))  

    List.zip3 sortedA sortedB sortedC

let sortStringsByLength (strings: string list) =
    strings |> List.sortBy (fun s -> s.Length)

let main =
    let fruits = ["яблоко"; "апельсин"; "банан"; "киви"]
    let sortedFruits = sortStringsByLength fruits
    System.Console.Write(sortedFruits)
main


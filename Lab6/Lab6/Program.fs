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

let main =
    let list = [1; 2; 3; 2; 1; 2; 4; 2]
    let result = mostFrequentElement list
    System.Console.Write(result)

main

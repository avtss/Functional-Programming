﻿//printfn "Hello World"

let solve (a,b,c) =
    let D = b*b-4.*a*c
    ((-b+sqrt(D))/(2.*a), (-b-sqrt(D))/(2.*a));;

let circleArea r =
    let pi = 3.14159
    pi * r * r

let cylinderVolume r h =
    h * circleArea r

let rec digitSum n =
    if n = 0 then 0
    else (n%10) + (digitSum (n/10))

let rec fibonacci n =
    if n<=1 then n
    else fibonacci (n-1) + fibonacci (n-2)

let getFunction (isDigitSum: bool) =
    match isDigitSum with
    |true -> digitSum
    |false -> fibonacci


let digitSum2 n = 
    let rec sumCifr1 n curSum = 
        if n = 0 then curSum
        else
            let n1 = n/10
            let cifr = n%10
            let newSum = curSum + cifr
            sumCifr1 n1 newSum
    sumCifr1 n 0

let digitTraversal number operation initial =
    let rec loop n acc =
        match n with
        | 0 -> acc
        | _ ->
            let digit = n % 10
            loop (n / 10) (operation acc digit)
    loop number initial

let conditionalDigitTraversal number operation initial condition =
    let rec loop n acc =
        match n with
        | 0 -> acc
        | _ ->
            let digit = n % 10
            let newAcc = 
                match condition digit with
                | true -> operation acc digit
                | false -> acc
            loop (n / 10) newAcc
    loop number initial

let quizLanguage language =
    match language with
    | "F#" | "Prolog" -> "Ты - подлиза"
    | "Java" | "C#"  -> "ООП круто"
    | "Python" -> "некруто"
    |_ -> "вау"

let quizLanguageSuperposition = 
    System.Console.ReadLine >> quizLanguage >> System.Console.Write

let rec gcd a b =
    match b with
    | 0 -> a
    | _ -> gcd b (a % b)

let processCoprimes n operation initial =
    let rec loop i acc =
        match i > n with
        | true -> acc
        | false -> 
            let newAcc = 
                match gcd i n with
                | 1 -> operation acc i
                | _ -> acc
            loop (i + 1) newAcc
    loop 1 initial

let euler n =
    match n with
    | 1 -> 1 
    | _ -> processCoprimes n (fun acc _ -> acc + 1) 0

let processCoprimesWithCondition n operation initial condition =
    let rec loop i acc =
        match i > n with
        | true -> acc
        | false ->
            match gcd i n with
            | 1 when condition i -> 
                loop (i + 1) (operation acc i)
            | _ -> 
                loop (i + 1) acc
    loop 1 initial

//Вариант 6
let isPrime n =
    match n with
    | n when n <= 1 -> false
    | _ ->
        let rec check i =
            match i * i > n with
            | true -> true
            | false ->
                match n % i with
                | 0 -> false
                | _ -> check (i + 1)
        check 2
//1
let sumNonPrimeDivisors n =
    let rec loop i acc =
        match i > n with
        | true -> acc
        | false ->
            match n % i, isPrime i with
            | 0, false -> loop (i + 1) (acc + i)
            | _, _ -> loop (i + 1) acc
    loop 2 0
//2
let countDigitsLessThan3 n =
    let rec loop num acc =
        match num with
        | 0 -> acc
        | _ ->
            let dig = num % 10
            match dig < 3 with
            | true -> loop (num / 10) (acc + 1)
            | false -> loop (num / 10) acc
    loop (abs n) 0

let primeDigitsSum n =
        let rec loop num acc =
            match num with
            | 0 -> acc
            | _ ->
                let digit = num % 10
                match isPrime digit with
                | true -> loop (num / 10) (acc + digit)
                | false -> loop (num / 10) acc
        loop n 0
//3
let method3 n =
    let sum = primeDigitsSum n  
    let rec count i acc =
        match i > n with
        | true -> acc
        | false ->
            match (n % i <> 0), (gcd i n <> 1), (gcd i sum = 1) with
            | true, true, true -> count (i + 1) (acc + 1)
            | _, _, _ -> count (i + 1) acc
    count 1 0

let main () =
    System.Console.Write(countDigitsLessThan3 123)

main()
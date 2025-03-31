//printfn "Hello World"

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

let main () =
    quizLanguageSuperposition ()


main()
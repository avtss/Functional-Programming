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

let main () =
    let number = 12345
    
    let sum = digitTraversal number (+) 0
    printfn "Сумма цифр числа %d: %d" number sum
    
    let product = digitTraversal number (*) 1
    printfn "Произведение цифр числа %d: %d" number product
    //let func = getFunction(true)
    //System.Console.WriteLine(func 123)
    //// суперпозиция
    //System.Console.WriteLine "Введите радиус цилиндра"
    //let radius = System.Console.ReadLine() |> float
    //System.Console.WriteLine "Введите высоту цилиндра"
    //let height = System.Console.ReadLine() |> float

    //let calculateVolume = circleArea >> ((*) height)
    //let volume = calculateVolume radius

    //System.Console.Write "Объем цилиндра (суперпозиция): "
    //System.Console.WriteLine volume

    //// каррирование
    //System.Console.WriteLine "Введите радиус цилиндра"
    //let radius = System.Console.ReadLine() |> float

    //System.Console.WriteLine "Введите высоту цилиндра"
    //let height = System.Console.ReadLine() |> float

    //let calculateVolume = cylinderVolume radius 
    //let volume = calculateVolume height

    //System.Console.Write "Объем цилиндра (каррирование): "
    //System.Console.WriteLine volume

    //let sum = digitSum 268
    //System.Console.Write "сумма цифр числа 268: "
    //System.Console.WriteLine sum

    //let sum2 = digitSum2 324
    //System.Console.Write "сумма цифр числа 324: "
    //System.Console.Write sum2

    //System.Console.ReadKey()


main()
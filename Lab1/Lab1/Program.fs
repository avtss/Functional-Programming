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

let main () =
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

    let sum = digitSum 268
    System.Console.Write "сумма цифр числа 268: "
    System.Console.Write sum

    System.Console.ReadKey()


main()
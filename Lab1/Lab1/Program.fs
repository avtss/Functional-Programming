//printfn "Hello World"

let solve (a,b,c) =
    let D = b*b-4.*a*c
    ((-b+sqrt(D))/(2.*a), (-b-sqrt(D))/(2.*a));;

let circleArea r =
    let pi = 3.14159
    pi * r * r

let cylinderVolume r h =
    h * circleArea r

let bigCylinderVol = cylinderVolume 10

let main () =
    // суперпозиция
    printfn "Введите радиус цилиндра:"
    let radius = System.Console.ReadLine() |> float
    printfn "Введите высоту цилиндра:"
    let height = System.Console.ReadLine() |> float

    let calculateVolume = circleArea >> ((*) height)
    let volume = calculateVolume radius

    printfn "Объем цилиндра (суперпозиция): %f" volume

    // каррирование
    printfn "Введите радиус цилиндра:"
    let radius = System.Console.ReadLine() |> float

    printfn "Введите высоту цилиндра:"
    let height = System.Console.ReadLine() |> float

    let calculateVolume = cylinderVolume radius 
    let volume = calculateVolume height

    printfn "Объем цилиндра (каррирование): %f" volume

    System.Console.ReadKey()


main()
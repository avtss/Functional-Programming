type Shape =
    | Rectangle of width: float * height: float
    | Square of side: float
    | Circle of radius: float

let getArea shape =
    match shape with
    | Rectangle (width, height) -> width * height
    | Square side -> side * side
    | Circle radius -> 3.14 * radius * radius

[<EntryPoint>]
let main argv =
    let rectangle = Rectangle(5.0, 10.0)
    let square = Square(4.0)
    let circle = Circle(3.0)

    System.Console.WriteLine("Площадь прямоугольника: " + (getArea rectangle).ToString("F2"))
    System.Console.WriteLine("Площадь квадрата: " + (getArea square).ToString("F2"))
    System.Console.WriteLine("Площадь круга: " + (getArea circle).ToString("F2"))

    0

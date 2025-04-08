module Lab7

[<AbstractClass>]
type Shape() =
    abstract member GetArea: unit -> float

    override this.ToString() =
        let area = this.GetArea()
        System.String.Format("Фигура с площадью: {0:F2}", area)

type Rectangle(width: float, height: float) =
    inherit Shape()

    member this.Width = width
    member this.Height = height

    override this.GetArea() = this.Width * this.Height

    override this.ToString() =
        System.String.Format("Прямоугольник: Ширина = {0:F2}, Высота = {1:F2}, Площадь = {2:F2}", this.Width, this.Height, this.GetArea())

type Square(side: float) =
    inherit Rectangle(side, side) 

    override this.ToString() =
        System.String.Format("Квадрат: Сторона = {0:F2}, Площадь = {1:F2}", this.Width, this.GetArea())

type Circle(radius: float) =
    inherit Shape()

    member this.Radius = radius

    override this.GetArea() = 3.14 * this.Radius * this.Radius

    override this.ToString() =
        System.String.Format("Круг: Радиус = {0:F2}, Площадь = {1:F2}", this.Radius, this.GetArea())

type IPrint =
    abstract member Print: unit -> unit

type RectangleWithPrint(width: float, height: float) =
    inherit Rectangle(width, height)
    interface IPrint with
        member this.Print() =
            System.Console.WriteLine(this.ToString())

type SquareWithPrint(side: float) =
    inherit Square(side)
    interface IPrint with
        member this.Print() =
            System.Console.WriteLine(this.ToString())

type CircleWithPrint(radius: float) =
    inherit Circle(radius)
    interface IPrint with
        member this.Print() =
            System.Console.WriteLine(this.ToString())

[<EntryPoint>]
let main argv =
    let rectangle = RectangleWithPrint(5.0, 10.0) :> IPrint
    let square = SquareWithPrint(4.0) :> IPrint
    let circle = CircleWithPrint(3.0) :> IPrint

    rectangle.Print()
    square.Print()
    circle.Print()

    0

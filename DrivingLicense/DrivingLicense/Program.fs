open System
open System.Text.RegularExpressions

type DrivingLicense(seria: string, number: string, fullName: string, birthDate: DateTime) =

    let validateSeria (seria: string) =
        let regex = Regex(@"^[A-Z]{2}$")
        regex.IsMatch(seria)

    let validateNumber (number: string) =
        let regex = Regex(@"^\d{6}$")
        regex.IsMatch(number)

    let validateFullName (name: string) =
        let regex = Regex(@"^[A-Za-zА-Яа-яЁё\s]+$")
        regex.IsMatch(name)

    let validateBirthDate (date: DateTime) =
        date <= DateTime.Now

    member val Seria = seria with get, set
    member val Number = number with get, set
    member val FullName = fullName with get, set
    member val BirthDate = birthDate with get, set

    member this.IsValid() =
        validateSeria this.Seria &&
        validateNumber this.Number &&
        validateFullName this.FullName &&
        validateBirthDate this.BirthDate

    override this.ToString() =
        if this.IsValid() then
            System.String.Format("Водительские права:\nСерия: {0}\nНомер: {1}\nФИО: {2}\nДата рождения: {3}",
                                 this.Seria, this.Number, this.FullName, this.BirthDate.ToString("dd.MM.yyyy"))
        else
            "Документ невалиден"

    override this.Equals(other: obj) =
        match other with
        | :? DrivingLicense as otherLicense ->
            this.Seria = otherLicense.Seria && this.Number = otherLicense.Number
        | _ -> false

    override this.GetHashCode() =
        (this.Seria, this.Number).GetHashCode()

[<EntryPoint>]
let main argv =
    let license1 = DrivingLicense("AA", "123456", "Иванов Иван Иванович", DateTime(1990, 5, 20))
    let license2 = DrivingLicense("BB", "654321", "Петров Петр Петрович", DateTime(1985, 3, 15))
    let license3 = DrivingLicense("AA", "123456", "Иванов Иван Иванович", DateTime(1990, 5, 20))

    System.Console.WriteLine("Документ 1:\n" + license1.ToString())
    System.Console.WriteLine("Документ 2:\n" + license2.ToString())

    match license1 = license3 with
    | true -> System.Console.WriteLine("\nДокументы идентичны")
    | false -> System.Console.WriteLine("\nДокументы различны")

    match license1.IsValid() with
    | true -> System.Console.WriteLine("\nДокумент 1 валиден")
    | false -> System.Console.WriteLine("\nДокумент 1 невалиден")

    0

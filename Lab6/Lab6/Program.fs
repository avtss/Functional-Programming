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

let main =
    readList 5

main
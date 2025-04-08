open System
open System.Threading

type AgentMessage =
    | PrintMessage of string
    | AddNumbers of int * int
    | SleepAndPrint of int * string

let agent = MailboxProcessor.Start(fun inbox ->
    let rec loop () =
        async {
            let! message = inbox.Receive()

            match message with
            | PrintMessage msg -> 
                System.Console.WriteLine("Получено сообщение для печати: " + msg)
            | AddNumbers (a, b) -> 
                let result = a + b
                System.Console.WriteLine("Результат сложения: " + result.ToString())
            | SleepAndPrint (delay, msg) ->
                System.Console.WriteLine("Засыпаем на " + delay.ToString() + " миллисекунд...")
                do! Async.Sleep(delay)
                System.Console.WriteLine("После сна, сообщение: " + msg)

            return! loop ()
        }
    loop ()
)

let sendMessages() =
    agent.Post(PrintMessage "Привет, мир!")
    agent.Post(AddNumbers(3, 5))
    agent.Post(SleepAndPrint(2000, "Это сообщение после 2 секунд ожидания"))

    Thread.Sleep(3000)

sendMessages()

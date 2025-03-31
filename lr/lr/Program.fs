let rec fibonacci n =
    if n<=1 then n
    else fibonacci (n-1) + fibonacci (n-2)

let rec fibonacci2 n =
    match n with
    |0 ->0
    |1 ->1
    |_ -> fibonacci2 (n-1) + fibonacci2 (n-2)

let fibvniz n =
    let rec fibvniz1 n a b =
        match n with
        |0->a
        |1->b
        |_->fibvniz1 (n-1) b (a+b)
    fibvniz1 n 0 1

let divCount n = 
    let rec countTail n acc i =
        match i with
        |0 -> acc
        |_ ->   if n%i = 0 then countTail n (acc+1) (i-1)
                else countTail n acc (i-1)
    countTail n 0 n



let main() =
    System.Console.WriteLine(fibonacci2 19)
    System.Console.WriteLine(fibonacci 19)
    System.Console.WriteLine(fibvniz 19)
    System.Console.WriteLine(divCount 20)
main()

type Maybe<'a> =
    | Just of 'a
    | Nothing

module Functor =
    let map f maybe =
        match maybe with
        | Just x -> Just (f x)
        | Nothing -> Nothing

module Applicative =
    let pure x = Just x

    let apply f maybe =
        match f, maybe with
        | Just f', Just x -> Just (f' x)
        | _ -> Nothing

module Monad =
    let bind maybe f =
        match maybe with
        | Just x -> f x
        | Nothing -> Nothing

    let returnMaybe x = Just x  


let increment x = x + 1
let double x = x * 2

let resultFunctor = Functor.map increment (Just 5)
let resultNothingFunctor = Functor.map increment Nothing

let resultApplicative = Applicative.apply (Just increment) (Just 5)
let resultNothingApplicative = Applicative.apply (Just increment) Nothing

let resultMonad = Monad.bind (Just 5) (fun x -> Just (x * 2))
let resultNothingMonad = Monad.bind Nothing (fun x -> Just (x * 2))

System.Console.WriteLine("Результат функтора: " + resultFunctor.ToString())
System.Console.WriteLine("Результат функтора для Nothing: " + resultNothingFunctor.ToString())
System.Console.WriteLine("Результат аппликативного функтора: " + resultApplicative.ToString())
System.Console.WriteLine("Результат аппликативного функтора для Nothing: " + resultNothingApplicative.ToString())
System.Console.WriteLine("Результат монады: " + resultMonad.ToString())
System.Console.WriteLine("Результат монады для Nothing: " + resultNothingMonad.ToString())

0

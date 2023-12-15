open System.IO

let digits = [| "1"; "2"; "3"; "4"; "5"; "6"; "7"; "8"; "9" |]
let numbers = [| "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine" |]
let both = Array.concat [| digits; numbers |]

// printfn "%A" both

let firstNumber indexOf by =
  both
  |> Array.mapi (fun i x -> (indexOf(x), i + 1))
  |> Array.filter (fun x -> fst x > -1)
  |> by fst
  |> snd 
  |> (fun x -> if x > 9 then (x - 9) else x)
  |> string

"input"
// "example"
// "problem"
|> File.ReadAllLines
|> Seq.map (fun line ->
            (firstNumber line.IndexOf Array.minBy) + (firstNumber line.LastIndexOf Array.maxBy)
            |> int
           )
// |> Seq.iter (fun x -> printfn "%A" x)
|> Seq.sum
|> printfn "%A" 


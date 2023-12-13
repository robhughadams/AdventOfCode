open System.IO

let firstNumber line =
  line
  |> Seq.tryFind (fun c -> c >= '0' && c <= '9')
  |> (function
      | Some x -> x
      | None -> '0')

let lastNumber line =
  line
  |> Seq.rev
  |> firstNumber

"input"
|> File.ReadAllLines
|> Seq.map (fun line ->
            string (firstNumber line) + string (lastNumber line)
            |> int)
|> Seq.sum
|> printfn "%d"


// Learn more about F# at http://fsharp.org

open CommandLine

type Options = {
    [<Option('r', "required", Required = true, HelpText = "Text displayed in help section.")>] required: string;
    [<Option('o', "optional", HelpText = "Text displayed in help section.")>] optional: string;
}

[<EntryPoint>]
let main argv =

    let start (res: ParserResult<Options>) = 
        match res with
        | :? Parsed<Options> as parsed -> printfn "%A" parsed.Value.required
        | :? NotParsed<Options> as notParsed -> printfn "%A" notParsed.Errors
        | _ -> printfn "Unable to process."

    CommandLine.Parser.Default.ParseArguments<Options>(argv) |> start

    0 // return an integer exit code
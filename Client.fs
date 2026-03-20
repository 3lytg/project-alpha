namespace ProjectAlpha
open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Templating
open ProjectAlpha.Data
[<JavaScript>]
module Client =
    type IndexTemplate = Template<"wwwroot/index.html", ClientLoad.FromDocument>
    let SearchTerm = Var.Create ""
    let FilteredAdditives =
        SearchTerm.View.Map (fun term ->
            if System.String.IsNullOrWhiteSpace(term) then
                AllAdditives
            else
                let lowerTerm = term.ToLower()
                AllAdditives |> List.filter (fun a -> 
                    a.Name.ToLower().Contains(lowerTerm) || 
                    a.ENumber.ToLower().Contains(lowerTerm)
                )
        )
    [<SPAEntryPoint>]
    let Main () =
        IndexTemplate.Main()
            .SearchInput(SearchTerm)
            .Doc()
        |> Doc.RunById "main"

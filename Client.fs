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
    let SelectedAdditive = Var.Create (None: Additive option)
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
    let RenderAdditive (a: Additive) =
        IndexTemplate.AdditiveItem()
            .Name(a.Name)
            .ENumber(a.ENumber)
            .Description(a.Description)
            .Select(fun _ -> SelectedAdditive.Value <- Some a)
            .Doc()
    [<SPAEntryPoint>]
    let Main () =
        IndexTemplate.Main()
            .SearchInput(SearchTerm)
            .Results(
                FilteredAdditives.DocSeqCached(RenderAdditive)
            )
            .Doc()
        |> Doc.RunById "main"

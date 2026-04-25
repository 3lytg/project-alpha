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

    let GetImpactColor level =
        match level with
        | Low -> "bg-green-100 text-green-800"
        | Moderate -> "bg-yellow-100 text-yellow-800"
        | High -> "bg-orange-100 text-orange-800"
        | Critical -> "bg-red-100 text-red-800"

    let ImpactTypeString t =
        match t with
        | Digestive -> "Digestive"
        | Neurological -> "Neurological"
        | Allergic -> "Allergic"
        | Carcinogenic -> "Carcinogenic"
        | Metabolic -> "Metabolic"
        | General -> "General"

    let ImpactLevelString l =
        match l with
        | Low -> "Low"
        | Moderate -> "Moderate"
        | High -> "High"
        | Critical -> "Critical"

    let RenderImpact (impactType, level, (description: string)) =
        IndexTemplate.ImpactItem()
            .Type(ImpactTypeString impactType)
            .Level(ImpactLevelString level)
            .Color(GetImpactColor level)
            .Description(description)
            .Doc()

    let RenderAdditive (a: Additive) =
        IndexTemplate.AdditiveItem()
            .Name(a.Name)
            .ENumber(a.ENumber)
            .Description(a.Description)
            .SafetyStatus(a.SafetyStatus)
            .SystemicReality(a.SystemicReality)
            .Impacts(
                a.Impacts |> List.map RenderImpact |> Doc.Concat
            )
            .Uses(
                a.CommonUses |> List.map (fun u -> IndexTemplate.UseItem().Text(u).Doc()) |> Doc.Concat
            )
            .Select(fun _ -> SelectedAdditive.Value <- Some a)
            .Doc()

    [<SPAEntryPoint>]
    let Main () =
        IndexTemplate.Main()
            .SearchInput(SearchTerm)
            .Results(
                FilteredAdditives.DocSeqCached(RenderAdditive)
            )
            .Details(
                SelectedAdditive.View.Map (function
                    | None -> Doc.Empty
                    | Some a ->
                        IndexTemplate.DetailsModal()
                            .Name(a.Name)
                            .ENumber(a.ENumber)
                            .Description(a.Description)
                            .SafetyStatus(a.SafetyStatus)
                            .SystemicReality(a.SystemicReality)
                            .Impacts(
                                a.Impacts |> List.map RenderImpact |> Doc.Concat
                            )
                            .Close(fun _ -> SelectedAdditive.Value <- None)
                            .Doc()
                ) |> Doc.EmbedView
            )
            .Doc()
        |> Doc.RunById "main"

namespace ProjectAlpha
open WebSharper
[<JavaScript>]
module Data =
    type ImpactLevel = 
        | Low 
        | Moderate 
        | High 
        | Critical
    type ImpactType = 
        | Digestive
        | Neurological
        | Allergic
        | Carcinogenic
        | Metabolic
        | General
    type Additive = {
        Id: string
        ENumber: string
        Name: string
        Description: string
        CommonUses: string list
        Impacts: (ImpactType * ImpactLevel * string) list
        SafetyStatus: string
        SystemicReality: string
    }
    let Additives = [
        {
            Id = "aspartame"
            ENumber = "E951"
            Name = "Aspartame"
            Description = "A non-saccharide artificial sweetener used as a sugar substitute in some foods and beverages."
            CommonUses = ["Diet sodas"; "Sugar-free gum"; "Low-calorie desserts"]
            Impacts = [
                (Neurological, Moderate, "Linked to headaches and dizziness in sensitive individuals.")
                (Carcinogenic, Low, "Classified as 'possibly carcinogenic to humans' (Group 2B) by IARC.")
                (Metabolic, Moderate, "May influence gut microbiota and glucose intolerance.")
            ]
            SafetyStatus = "Approved by FDA and EFSA, but remains controversial."
            SystemicReality = "Widespread use in 'diet' products masks the systemic issue of sugar addiction and metabolic dysfunction rather than solving it."
        }
        {
            Id = "msg"
            ENumber = "E621"
            Name = "Monosodium Glutamate"
            Description = "The sodium salt of glutamic acid, used as a flavor enhancer with an umami taste."
            CommonUses = ["Fast food"; "Canned vegetables"; "Soups"; "Processed meats"]
            Impacts = [
                (Neurological, Moderate, "Often associated with 'Chinese Restaurant Syndrome' (headaches, flushing).")
                (Metabolic, Low, "Potential links to obesity and metabolic syndrome in high doses.")
            ]
            SafetyStatus = "Generally Recognized as Safe (GRAS) by FDA."
            SystemicReality = "Used to make low-quality, nutrient-poor ingredients hyper-palatable, driving overconsumption of ultra-processed foods."
        }
        {
            Id = "titanium-dioxide"
            ENumber = "E171"
            Name = "Titanium Dioxide"
            Description = "A white pigment used to provide whiteness and opacity to foods."
            CommonUses = ["Candies"; "Pastries"; "Coffee creamers"; "Cake decorations"]
            Impacts = [
                (Digestive, Moderate, "Concerns regarding intestinal inflammation and gut barrier damage.")
                (Carcinogenic, Moderate, "Banned in the EU due to concerns about genotoxicity.")
            ]
            SafetyStatus = "Banned in EU (2022); still allowed in the US."
            SystemicReality = "Purely aesthetic additive with zero nutritional value, prioritizing product appearance over potential long-term cellular health."
        }
    ]
    let AdditionalAdditives = []
    let AllAdditives = (Additives @ AdditionalAdditives) |> List.distinctBy (fun a -> a.Id)

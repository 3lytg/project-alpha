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
        {
            Id = "high-fructose-corn-syrup"
            ENumber = "N/A"
            Name = "High Fructose Corn Syrup"
            Description = "A sweetener made from corn starch that has been processed by glucose isomerase to convert some of its glucose into fructose."
            CommonUses = ["Soft drinks"; "Breads"; "Cereals"; "Condiments"]
            Impacts = [
                (Metabolic, Critical, "Primary driver of non-alcoholic fatty liver disease (NAFLD) and insulin resistance.")
                (General, High, "Major contributor to the global obesity epidemic.")
            ]
            SafetyStatus = "Legal and ubiquitous, despite clear evidence of metabolic harm."
            SystemicReality = "A byproduct of industrial corn subsidies, HFCS represents the triumph of agricultural policy over public health."
        }
        {
            Id = "sodium-nitrite"
            ENumber = "E250"
            Name = "Sodium Nitrite"
            Description = "Used as a preservative and color fixative in cured meats and fish."
            CommonUses = ["Bacon"; "Hot dogs"; "Deli meats"; "Smoked fish"]
            Impacts = [
                (Carcinogenic, High, "Forms nitrosamines in the stomach, which are potent carcinogens.")
                (Digestive, Moderate, "Linked to increased risk of colorectal cancer.")
            ]
            SafetyStatus = "Regulated levels allowed, but health organizations recommend limiting intake."
            SystemicReality = "Enables the long-distance transport and shelf-life of low-grade meat products, externalizing health costs to the consumer."
        }
        {
            Id = "tartrazine"
            ENumber = "E102"
            Name = "Tartrazine (Yellow 5)"
            Description = "A synthetic lemon yellow azo dye used as a food coloring."
            CommonUses = ["Soft drinks"; "Chips"; "Puddings"; "Honey"; "Pickles"]
            Impacts = [
                (Allergic, High, "Known to cause hives and asthma-like symptoms in sensitive individuals.")
                (Neurological, Moderate, "Linked to hyperactivity in children (ADHD-like symptoms).")
            ]
            SafetyStatus = "Requires warning labels in the EU; widely used in the US."
            SystemicReality = "Used to simulate the appearance of natural ingredients in products that are entirely synthetic, deceiving the brain's nutritional signaling."
        }
    ]
    let AdditionalAdditives = []
    let AllAdditives = (Additives @ AdditionalAdditives) |> List.distinctBy (fun a -> a.Id)

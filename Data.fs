namespace ProjectAlpha

open WebSharper

[<JavaScript>]
module Data =
    type ImpactLevel = 
        | [<Constant "Low">] Low 
        | [<Constant "Moderate">] Moderate 
        | [<Constant "High">] High 
        | [<Constant "Critical">] Critical

    type ImpactType = 
        | [<Constant "Digestive">] Digestive
        | [<Constant "Neurological">] Neurological
        | [<Constant "Allergic">] Allergic
        | [<Constant "Carcinogenic">] Carcinogenic
        | [<Constant "Metabolic">] Metabolic
        | [<Constant "General">] General

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
        {
            Id = "carrageenan"
            ENumber = "E407"
            Name = "Carrageenan"
            Description = "A family of linear sulfated polysaccharides that are extracted from red edible seaweeds."
            CommonUses = ["Nut milks"; "Yogurts"; "Ice cream"; "Cottage cheese"]
            Impacts = [
                (Digestive, High, "Strong evidence of causing intestinal inflammation and IBS-like symptoms.")
                (General, Moderate, "Degraded carrageenan is a known carcinogen in animal models.")
            ]
            SafetyStatus = "Controversial; some health experts advise avoidance for those with digestive issues."
            SystemicReality = "Used to create 'mouthfeel' in low-fat or vegan alternatives, replacing natural fats with industrial thickeners that may irritate the gut."
        }
        {
            Id = "acesulfame-k"
            ENumber = "E950"
            Name = "Acesulfame Potassium"
            Description = "A calorie-free sugar substitute often used in combination with other sweeteners."
            CommonUses = ["Soda"; "Protein shakes"; "Frozen desserts"]
            Impacts = [
                (Metabolic, Moderate, "May disrupt metabolic processes and appetite regulation.")
                (General, Low, "Contains methylene chloride, a known carcinogen, used in the manufacturing process.")
            ]
            SafetyStatus = "Approved, but long-term human studies are limited."
            SystemicReality = "Part of the 'chemical cocktail' of sweeteners used to bypass sugar taxes while maintaining hyper-sweet flavor profiles."
        }
        {
            Id = "bha-bht"
            ENumber = "E320/E321"
            Name = "BHA & BHT"
            Description = "Antioxidants used to preserve fats and oils in food and prevent them from becoming rancid."
            CommonUses = ["Cereals"; "Chewing gum"; "Potato chips"; "Vegetable oils"]
            Impacts = [
                (Carcinogenic, Moderate, "BHA is classified as 'reasonably anticipated to be a human carcinogen'.")
                (Metabolic, Moderate, "Potential endocrine disruptors affecting hormone levels.")
            ]
            SafetyStatus = "Restricted in some countries; allowed in the US."
            SystemicReality = "Extends the shelf-life of ultra-processed foods to months or years, facilitating a globalized food system that prioritizes logistics over freshness."
        }
        {
            Id = "potassium-bromate"
            ENumber = "E924"
            Name = "Potassium Bromate"
            Description = "An oxidizing agent used as a flour improver to strengthen dough and allow for higher rising."
            CommonUses = ["Commercial breads"; "Buns"; "Flour"]
            Impacts = [
                (Carcinogenic, High, "Classified as a Group 2B carcinogen; known to cause kidney and thyroid tumors in animals.")
                (General, Moderate, "Can cause DNA damage in human cells.")
            ]
            SafetyStatus = "Banned in EU, Canada, Brazil, and China; still legal in the US."
            SystemicReality = "A relic of industrial baking that prioritizes volume and speed over safety, despite the availability of safer alternatives."
        }
    ]

    let AdditionalAdditives = [

        {
            Id = "bha"
            ENumber = "E320"
            Name = "Butylated Hydroxyanisole (BHA)"
            Description = "A synthetic antioxidant used to prevent fats in foods from going rancid."
            CommonUses = ["Cereal"; "Potato chips"; "Vegetable oils"; "Chewing gum"]
            Impacts = [
                (Carcinogenic, Moderate, "Classified as 'reasonably anticipated to be a human carcinogen' by the NTP.")
                (Metabolic, Moderate, "Potential endocrine disruptor affecting hormone signaling.")
            ]
            SafetyStatus = "Restricted in the EU and Japan; allowed in the US."
            SystemicReality = "Enables the extreme shelf-life of ultra-processed goods, facilitating a global supply chain that prioritizes logistics over nutritional freshness."
        }
        {
            Id = "polysorbate-80"
            ENumber = "E433"
            Name = "Polysorbate 80"
            Description = "An emulsifier used to improve the consistency of processed foods and prevent separation."
            CommonUses = ["Ice cream"; "Salad dressings"; "Shortening"; "Whipped toppings"]
            Impacts = [
                (Digestive, High, "Linked to changes in gut bacteria and intestinal inflammation.")
                (Metabolic, Moderate, "May contribute to metabolic syndrome and obesity by disrupting the gut barrier.")
            ]
            SafetyStatus = "Widely used, but emerging research suggests significant gut health implications."
            SystemicReality = "Used to create artificial textures in products that lack the natural structural integrity of whole foods."
        }
        {
            Id = "yellow-6"
            ENumber = "E110"
            Name = "Sunset Yellow FCF (Yellow 6)"
            Description = "A synthetic azo dye used to provide an orange-yellow color to foods."
            CommonUses = ["Snack foods"; "Soft drinks"; "Candies"; "Gelatin desserts"]
            Impacts = [
                (Neurological, Moderate, "Associated with hyperactivity in children.")
                (Allergic, Moderate, "Can cause allergic reactions in people with aspirin sensitivity.")
            ]
            SafetyStatus = "Banned in Norway and Finland; requires warning labels in the EU."
            SystemicReality = "A purely cosmetic additive used to make nutrient-void products visually appealing to children."
        }
        {
            Id = "sodium-benzoate"
            ENumber = "E211"
            Name = "Sodium Benzoate"
            Description = "A preservative used to prevent the growth of mold, bacteria, and yeast in acidic foods."
            CommonUses = ["Carbonated drinks"; "Fruit juices"; "Pickles"; "Condiments"]
            Impacts = [
                (Neurological, Moderate, "Linked to increased hyperactivity in children when combined with food dyes.")
                (General, Moderate, "Can convert into benzene, a known carcinogen, in the presence of Vitamin C.")
            ]
            SafetyStatus = "Generally recognized as safe, but concentration limits are strictly regulated."
            SystemicReality = "Allows for the mass production of liquid calories that can sit on shelves for years without spoiling."
        }
        {
            Id = "propyl-gallate"
            ENumber = "E310"
            Name = "Propyl Gallate"
            Description = "An antioxidant used to prevent the oxidation of fats and oils."
            CommonUses = ["Meat products"; "Microwave popcorn"; "Soup bases"; "Chewing gum"]
            Impacts = [
                (Carcinogenic, Low, "Some animal studies suggest a link to cancer, though evidence in humans is limited.")
                (Allergic, Moderate, "May cause skin rashes or breathing problems in sensitive individuals.")
            ]
            SafetyStatus = "Approved for use, but some health advocacy groups recommend caution."
            SystemicReality = "Used to stabilize industrial fats, masking the degradation of ingredients that would otherwise be unpalatable."
        }
        {
            Id = "guar-gum"
            ENumber = "E412"
            Name = "Guar Gum"
            Description = "A fiber extracted from guar beans, used as a thickener and stabilizer."
            CommonUses = ["Ice cream"; "Salad dressings"; "Gluten-free baking"; "Soups"]
            Impacts = [
                (Digestive, Moderate, "Can cause gas, bloating, and cramps in high amounts.")
                (General, Low, "May help lower cholesterol, but also interferes with the absorption of some nutrients.")
            ]
            SafetyStatus = "Generally safe, but can cause digestive distress in sensitive individuals."
            SystemicReality = "An industrial thickener that replaces the natural texture of whole foods, often used to make water-based mixtures feel creamy."
        }
        {
            Id = "sucralose"
            ENumber = "E955"
            Name = "Sucralose"
            Description = "An artificial sweetener that is about 600 times sweeter than sucrose."
            CommonUses = ["Diet drinks"; "Sugar-free snacks"; "Baking mixes"]
            Impacts = [
                (Digestive, Moderate, "May reduce the number of beneficial bacteria in the gut by up to 50%.")
                (Metabolic, Moderate, "Can affect insulin sensitivity and blood sugar response despite being calorie-free.")
            ]
            SafetyStatus = "Approved globally, but long-term effects on the gut microbiome are a growing concern."
            SystemicReality = "A chlorinated sugar derivative that allows the food industry to market 'zero calorie' health claims while potentially disrupting metabolic health."
        }
        {
            Id = "red-40"
            ENumber = "E129"
            Name = "Red 40 (Allura Red AC)"
            Description = "A synthetic red azo dye used as a food coloring."
            CommonUses = ["Candies"; "Soft drinks"; "Cereals"; "Pastries"]
            Impacts = [
                (Neurological, Moderate, "Linked to hyperactivity and ADHD-like symptoms in children.")
                (Allergic, Moderate, "May cause allergic reactions in some individuals.")
            ]
            SafetyStatus = "Requires warning labels in the EU; widely used in the US."
            SystemicReality = "Used to make synthetic food products look like they contain real fruit, specifically targeting children's visual preferences."
        }
    ]

    let AllAdditives = (Additives @ AdditionalAdditives) |> List.distinctBy (fun a -> a.Id)

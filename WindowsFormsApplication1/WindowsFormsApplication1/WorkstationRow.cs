using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    class WorkstationRow
    {
        public string LocationNum { get; private set; }
        public string BuildingNum { get; private set; }
        public string PhysBldgNum { get; private set; }
        public string SingleBldgNum { get; private set; }
        public string Street1 { get; private set; }
        public string Street2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string County { get; private set; }
        public string BuildingValue { get; }
        public string BusPersProp { get; }
        public string BusIncome { get; }
        public string MiscRealProp { get; }
        public string NumUnits { get; }
        public string BuildingDesc { get; }
        public string ConstrType { get; private set; }
        public string DistFireHydrant { get; }
        public string DistFireStation { get; }
        public string ProtCode { get; }
        public string NumStories { get; }
        public string NumBasements { get; }
        public string YearBuilt { get; }
        public string SqFootage { get; }
        public string WiringYear { get; private set; }
        public string PlumbingYear { get; private set; }
        public string HeatingYear { get; private set; }
        public string RoofingYear { get; private set; }
        public string BurgAlarmType { get; }
        public string FireAlarmType { get; }
        public string SprinkAlarmType { get; }
        public string SprinkWetDry { get; }
        public string SprinkExtent { get; }

        public WorkstationRow(
            string locNum = "", string bldgNum = "", string physBldgNum = "", string singleBldgNum = "", string street1 = "", string street2 = "",
            string city = "", string state = "", string zip = "", string county = "", string bv = "", string bpp = "", string bi = "", string mrp = "",
            string numUnits = "", string bldgDesc = "", string constrType = "", string hydrant = "", string station = "", string protCode = "",
            string yearBuilt = "", string sqftg = "", string wiring = "", string plumbing = "", string heating = "", string roofing = "",
            string burgAlarm = "", string fireAlarm = "", string sprinkAlarm = "", string wetDry = "", string extent = ""
            )
        {
            LocationNum = locNum;
            BuildingNum = bldgNum;
            PhysBldgNum = physBldgNum;
            SingleBldgNum = singleBldgNum;
            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            ZipCode = zip;
            County = county;
            BuildingValue = bv;
            BusPersProp = bpp;
            BusIncome = bi;
            MiscRealProp = mrp;
            NumUnits = numUnits;
            BuildingDesc = bldgDesc;
            ConstrType = constrType;
            DistFireHydrant = hydrant;
            DistFireStation = station;
            ProtCode = protCode;
            YearBuilt = yearBuilt;
            SqFootage = sqftg;
            WiringYear = wiring;
            PlumbingYear = plumbing;
            HeatingYear = heating;
            RoofingYear = roofing;
            BurgAlarmType = burgAlarm;
            FireAlarmType = fireAlarm;
            SprinkAlarmType = sprinkAlarm;
            SprinkWetDry = wetDry;
            SprinkExtent = extent;
        }

        /// <summary>
        /// Writes out common address abbreviations in their full form.
        /// </summary>
        public void ExpandShorthand()
        {
            // Establish dictionary of shorthand keys and their expanded values
            Dictionary<string, string> shorthand = new Dictionary<string, string>()
            {
                { "ave", "Avenue" }, { "ave.", "Avenue" }, { "ave,", "Avenue," },
                { "blvd", "Boulevard" }, { "blvd.", "Boulevard" }, { "blvd,", "Boulevard," }, { "blvd.,", "Boulevard,"},
                { "rd", "Road" }, { "rd.", "Road" }, { "rd,", "Road," }, { "rd.,", "Road,"},
                { "dr", "Drive" }, { "dr.", "Drive" }, { "dr,", "Drive," }, { "dr.,", "Drive,"},
                { "ln", "Lane" }, { "ln.", "Lane" }, { "ln,", "Lane," }, { "ln.,", "Lane,"}
            };
            // Create a new instance of the TextInfo class, which is a child class of CultureInfo.
            // This class instance will allow us to use the ToTitleCase method below.
            TextInfo txt = new CultureInfo("en-US", false).TextInfo;
            // Take the address, make it lowercase for identification, split the address up by spaces, and place the pieces in a list
            List<string> splitAddress = Street1.ToLower().Split(' ').ToList();
            foreach (var kvp in shorthand)
            {
                if (splitAddress.Contains(kvp.Key)) // If the shorthand from the dictionary exists in the address part list
                {
                    // Find it and update it
                    int pieceLocation = splitAddress.IndexOf(kvp.Key);
                    splitAddress[pieceLocation] = kvp.Value;
                }
            }
            // Rejoin the address and return it to proper case
            Street1 = string.Join(" ", splitAddress);
            Street1 = txt.ToTitleCase(Street1);
        }

        /// <summary>
        /// Expands the abbreviations for cardinal directions into their proper word form
        /// </summary>
        public void ExpandCardinalDir()
        {
            // Check if any of the cardinal directions are already expanded in the street and stop if need be
            bool needsExpansion = true;
            string[] directions = { "north", "east", "south", "west" };
            for (int i = 0; i < directions.Length; i++)
            {
                if (Street1.ToLower().Contains(directions[i]))
                {
                    needsExpansion = false;
                }
            }

            if (!needsExpansion)
            {
                return;
            }
            else
            {
                // Build the regex pattern, instantiate a new regex object, perform a match
                string regexPattern = @"(\s[neswNESW]$|\s[neswNESW]\s+)";
                Regex rgx = new Regex(regexPattern);
                Match match = Regex.Match(Street1, regexPattern);
                if (match.Success)
                {
                    switch (match.Value.ToLower())
                    {
                        /*
                         * Note: There should be a space either before or both before and after the cardinal direction letter.
                         * If there isn't, the method will function just fine: it'll just go to the default case of breaking out.
                         */
                        case " n":
                            Street1 = rgx.Replace(Street1, " North");
                            break;
                        case " e":
                            Street1 = rgx.Replace(Street1, " East");
                            break;
                        case " s":
                            Street1 = rgx.Replace(Street1, " South");
                            break;
                        case " w":
                            Street1 = rgx.Replace(Street1, " West");
                            break;
                        case " n ":
                            Street1 = rgx.Replace(Street1, " North ");
                            break;
                        case " e ":
                            Street1 = rgx.Replace(Street1, " East ");
                            break;
                        case " s ":
                            Street1 = rgx.Replace(Street1, " South ");
                            break;
                        case " w ":
                            Street1 = rgx.Replace(Street1, " West ");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// If the improvement years are missing, replace them with the year built. If the year is less than 4 digits, replace it
        /// with an empty string so the user can correct as necessary (meaning the OCR software did not correctly read the year).
        /// </summary>
        public void ImprovementYearCorrection()
        {
            string[] improvementYears = { WiringYear, PlumbingYear, HeatingYear, RoofingYear };
            for (int i = 0; i < improvementYears.Length; i++)
            {
                if (improvementYears[i].Equals(""))
                    improvementYears[i] = YearBuilt;
                if (improvementYears[i].Length < 4)
                    improvementYears[i] = "";
            }
            WiringYear = improvementYears[0];
            PlumbingYear = improvementYears[1];
            HeatingYear = improvementYears[2];
            RoofingYear = improvementYears[3];
        }

        /// <summary>
        /// Based on the construction type, append a number to the start of the construction type string
        /// so that it matches the expected input for the workstation.
        /// </summary>
        public void ConstrTypeMatchWorkstation()
        {
            Dictionary<string, string> workstationConstrType = new Dictionary<string, string>()
            {
                { "Frame", "1. Frame" },
                { "Joisted Masonry", "2. Joisted Masonry" },
                { "Non-Combustible", "3. Non-Combustible" },
                { "Masonry, Non-Combustible", "4. Masonry, Non-Combustible" },
                { "Modified Fire Resistive", "5. Modified Fire Resistive" },
                { "Fire Resistive", "6. Fire Resistive" },
                { "None Provided", "" }
            };

            foreach (var kvp in workstationConstrType)
            {
                if (ConstrType.Equals(kvp.Key))
                {
                    ConstrType = kvp.Value;
                }
            }
        }
    }
}

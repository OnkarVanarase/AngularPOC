using System.Text.RegularExpressions;

namespace NestedExpansionPOC
{
    internal class Program
    {
        static List<AcronymExpansion> acronymExpansions = new List<AcronymExpansion>();
        private static Dictionary<string, string> acronymDictionary = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            PopulateAcronyms(ref acronymExpansions);
            PopulateDictionary(acronymExpansions);
            foreach (AcronymExpansion expansion in acronymExpansions)
            {
                expansion.NestedExpansion = ExpandAcronyms(expansion.Expansion);
            }

            foreach (AcronymExpansion expansion in acronymExpansions)
            {
                string str = expansion.Acronym + "|" + expansion.Expansion + "|" + expansion.NestedExpansion;
                Console.WriteLine(str);
            }
            Console.ReadKey();
        }

        public static void PopulateAcronyms(ref List<AcronymExpansion> expansions)
        {
            if (expansions != null && expansions.Count == 0)
            {
                expansions.Add(new AcronymExpansion() { AcronymId = 1, Acronym = "BP", Expansion = "Blood Pressure" });
                expansions.Add(new AcronymExpansion() { AcronymId = 2, Acronym = "PIH", Expansion = "Pregnancy Induced Hypertension" });
                expansions.Add(new AcronymExpansion() { AcronymId = 3, Acronym = "PIHS", Expansion = "PIH with BP" });
                expansions.Add(new AcronymExpansion() { AcronymId = 4, Acronym = "C.H#S", Expansion = "Child heart syndrome" });
                expansions.Add(new AcronymExpansion() { AcronymId = 5, Acronym = "PCHS", Expansion = "C.H#S-PIH" });
            }
        }

        public static void PopulateDictionary(List<AcronymExpansion> expansions)
        {
            if (expansions != null && expansions.Count > 0)
            {
                foreach (AcronymExpansion expansion in expansions)
                {
                    acronymDictionary.Add(expansion.Acronym, expansion.Expansion);
                }
            }
        }

        //public static string ExpandAcronyms(string input)
        //{
        //    string[] words = input.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        //    List<string> expandedWords = new List<string>();

        //    foreach (string word in words)
        //    {
        //        string expandedWord = word;
        //        if (acronymDictionary.TryGetValue(word, out string expansion))
        //        {
        //            expandedWord = expansion;
        //        }
        //        expandedWords.Add(expandedWord);
        //    }

        //    return string.Join(" ", expandedWords);
        //}

        //public static string ExpandAcronyms(string input)
        //{
        //    StringBuilder result = new StringBuilder();
        //    StringBuilder currentWord = new StringBuilder();
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        char c = input[i];
        //        if (char.IsLetterOrDigit(c))
        //        {
        //            currentWord.Append(c);
        //        }
        //        else
        //        {
        //            if (currentWord.Length > 0)
        //            {
        //                string word = currentWord.ToString();
        //                if (acronymDictionary.TryGetValue(word, out string expansion))
        //                {
        //                    result.Append(expansion);
        //                }
        //                else
        //                {
        //                    result.Append(word);
        //                }
        //                currentWord.Clear();
        //            }
        //            result.Append(c);
        //        }
        //    }

        //    if (currentWord.Length > 0)
        //    {
        //        string lastWord = currentWord.ToString();
        //        if (acronymDictionary.TryGetValue(lastWord, out string expansion))
        //        {
        //            result.Append(expansion);
        //        }
        //        else
        //        {
        //            result.Append(lastWord);
        //        }
        //    }

        //    return result.ToString();
        //}

        public static string ExpandAcronyms(string input)
        {
            // Matches words containing letters, digits, #, or . (period)
            //string pattern = @"(?:\b[A-Za-z0-9#]+|\.[A-Za-z0-9#]+)+\b";
            //Regex regex = new Regex(pattern);

            //return regex.Replace(input, match =>
            //{
            //    string word = match.Value;
            //    if (acronymDictionary.TryGetValue(word, out string expansion))
            //    {
            //        return expansion;
            //    }
            //    return word;
            //});
            foreach (var entry in acronymDictionary)
            {
                string regexPattern = $@"(?<!\p{{L}}){Regex.Escape(entry.Key)}(?!{Regex.Escape(".")})";
                input = Regex.Replace(input, regexPattern, entry.Value);
            }
            return input;
        }


    }
}
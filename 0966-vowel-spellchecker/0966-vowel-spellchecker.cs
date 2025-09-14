using System.Text.RegularExpressions;

public class Solution {
    public string[] Spellchecker(string[] wordlist, string[] queries) {
        var words = new HashSet<string>(wordlist);
        var capital = new Dictionary<string, string>();  // normalise case
        var vowel = new Dictionary<string, string>();    // normalise vowels

        foreach (var word in wordlist) {
            string upper = word.ToUpper(), devowel = Regex.Replace(upper, "[AEIOU]", "#");
            if (!capital.ContainsKey(upper)) capital[upper] = word;
            if (!vowel.ContainsKey(devowel)) vowel[devowel] = word;
        }

        for (int i = 0; i < queries.Length; i++) {
            var query = queries[i];
            if (words.Contains(query)) continue; // no change needed

            string upper = query.ToUpper(), devowel = Regex.Replace(upper, "[AEIOU]", "#");
            if (capital.ContainsKey(upper))
                queries[i] = capital[upper];
            else if (vowel.ContainsKey(devowel))
                queries[i] = vowel[devowel];
            else
                queries[i] = "";
        }

        return queries;
    }
}
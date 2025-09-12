public class Solution {
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships) {
        var needToLearn = new HashSet<int>();
        foreach (var friendship in friendships) {
            int f0 = friendship[0] - 1, f1 = friendship[1] - 1; // convert to 0-based indexing

            // check if there is any common language
            var knownLang = new HashSet<int>(languages[f0]);
            bool matchFound = false;
            foreach (var lang in languages[f1]) {
                if (knownLang.Contains(lang)) {
                    matchFound = true;
                    break;
                }
            }

            if (matchFound) continue; // no effort needed
            needToLearn.Add(f0);
            needToLearn.Add(f1);
        }

        // find out language that most people speak, out of those who need to learn
        int maxCount = 0;
        var langCount = new int[n + 1]; // indicates how many people speak a language
        foreach (var f in needToLearn) {
            foreach (var lang in languages[f]) {
                langCount[lang]++;
                maxCount = Math.Max(maxCount, langCount[lang]);
            }
        }

        return needToLearn.Count - maxCount; // these many people need to learn the maxCount language
    }
}

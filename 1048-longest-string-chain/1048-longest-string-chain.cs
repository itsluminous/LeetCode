// copy paste
public class Solution
{
    public int LongestStrChain(string[] words)
    {
        HashSet<string> wordsAsHashSet = words.ToHashSet();
        Dictionary<string, int> dp = new();
        return words.Max(GetLongestChain);

        int GetLongestChain(string word)
        {
            int longestChain = 0;
            for (int index = 0; index < word.Length; index++)
            {
                string predecessor = word[..index] + word[(index + 1)..];
                if (wordsAsHashSet.Contains(predecessor) is false) continue;

                int chain = dp.ContainsKey(predecessor)
                    ? dp[predecessor]
                    : dp[predecessor] = GetLongestChain(predecessor);

                if (chain > longestChain) longestChain = chain;
            }

            return 1 + longestChain;
        }
    }
}
public class Solution {
    public IList<int> FindWordsContaining(string[] words, char x) {
        var ans = new List<int>();
        for(var i=0; i<words.Length; i++)
            if(words[i].Contains(x))
                ans.Add(i);
        return ans;
    }
}
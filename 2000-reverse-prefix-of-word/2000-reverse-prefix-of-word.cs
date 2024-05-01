// by converting string to char array
public class Solution {
    public string ReversePrefix(string word, char ch) {
        var idx = word.IndexOf(ch);
        if(idx == -1) return word;

        var chars = word.ToCharArray();
        Array.Reverse(chars, 0, idx+1);
        return new string(chars);
    }
}

// Accepted - using string builder
public class SolutionSB {
    public string ReversePrefix(string word, char ch) {
        // find the occurrence of ch
        var idx = word.IndexOf(ch);
        if(idx == -1) return word;

        // append all chars to left of idx in reverse, and on right as it is
        var ans = new StringBuilder();
        for(var i=idx; i>=0; i--) ans.Append(word[i]);
        for(var i=idx+1; i<word.Length; i++) ans.Append(word[i]);
        return ans.ToString();
    }
}
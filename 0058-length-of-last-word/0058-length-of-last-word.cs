public class Solution {
    public int LengthOfLastWord(string s) {
        int prevLen=0, len=0;
        for(var i=0; i<s.Length; i++){
            if(s[i] == ' ' && len > 0){
                prevLen = len;
                len = 0;
            }
            else if(s[i] == ' ') continue;
            else len++;
        }

        return len > 0 ? len : prevLen;
    }
}

// Accepted - Using inbuilt split
public class SolutionSplit {
    public int LengthOfLastWord(string s) {
        var words = s.Trim().Split();
        return words[words.Length-1].Length;
    }
}
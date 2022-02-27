public class Solution {
    public int MinSteps(string s, string t) {
        var letterS = new int[26];
        int steps = 0;
        
        foreach(var ch in s)
            letterS[ch-'a']++;
        
        foreach(var ch in t){
            if(letterS[ch-'a'] > 0)
                letterS[ch-'a']--;
            else
                steps++;
        }
        
        foreach(var val in letterS)
            steps += val;
        
        return steps;
    }
}
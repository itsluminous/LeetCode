public class Solution {
    public bool IsSubstringPresent(string s) {
        var reverse = new string(s.Reverse().ToArray());
        
        // for each possible substring, check match
        for(var i=0; i<s.Length-1; i++){
            var word = s.Substring(i, 2);
            if(s.Contains(word) && reverse.Contains(word))
                return true;
        }
        return false;
    }
}
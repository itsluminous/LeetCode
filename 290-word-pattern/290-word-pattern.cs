public class Solution {
    public bool WordPattern(string pattern, string s) {
        var charToString = new Dictionary<char, string>();
        var stringToChar = new Dictionary<string, char>();
        var words = s.Split(' ');
        
        if(words.Length != pattern.Length) return false;
        
        for(var i=0; i<words.Length; i++){
            if(!charToString.ContainsKey(pattern[i]))
                charToString[pattern[i]] = words[i];
            else if(charToString[pattern[i]] != words[i])
                return false;
            
            if(!stringToChar.ContainsKey(words[i]))
                stringToChar[words[i]] = pattern[i];
            else if(stringToChar[words[i]] != pattern[i])
                return false;
        }
        
        return true;
    }
}
public class Solution {
    public bool IsSubstringPresent(string s) {
        var reverse = new string(s.Reverse().ToArray());
        
        var words = new List<string>();
        for(var i=0; i<s.Length-1; i++)
            words.Add(s.Substring(i, 2));
        
        foreach(var word in words){
            if(s.Contains(word) && reverse.Contains(word))
                return true;
        }
        return false;
    }
}
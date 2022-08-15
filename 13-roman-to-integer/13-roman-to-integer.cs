public class Solution {
    public int RomanToInt(string s) {
        var dict = new Dictionary<char,int>();
        dict['I'] = 1; dict['V'] = 5; dict['X'] = 10; dict['L'] = 50;
        dict['C'] = 100; dict['D'] = 500; dict['M'] = 1000;
        
        var val = 0;
        for(var i=0; i<s.Length; i++){
            if(i+1 < s.Length && dict[s[i]] < dict[s[i+1]])
                val -= dict[s[i]];
            else
                val += dict[s[i]];
        }
        
        return val;
    }
}
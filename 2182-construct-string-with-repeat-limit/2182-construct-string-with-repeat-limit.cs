// My idea is to pick biggest char, add it till limit, then add next biggest char
// then continue with biggest char till it is exhausted. and then move to next biggest char for iteration
public class Solution {
    public string RepeatLimitedString(string s, int repeatLimit) {
        var chars = new int[26];
        foreach(var ch in s)
            chars[ch-'a']++;
        
        var sb = new StringBuilder();
        for(var ch='z'; ch >= 'a'; ch--){
            while(chars[ch-'a'] > 0){
                if(chars[ch-'a'] <= repeatLimit){
                    AppendChar(sb, ch, chars[ch-'a']);
                    chars[ch-'a'] = 0;
                }
                else{
                    AppendChar(sb, ch, repeatLimit);
                    chars[ch-'a'] -= repeatLimit;
                    var nextChar = GetNextChar(chars, ch);
                    if(nextChar < 'a') break;
                    sb.Append(nextChar);
                    chars[nextChar-'a']--;
                }
            }
        }
        
        return sb.ToString();
    }
    
    private void AppendChar(StringBuilder sb, char ch, int times){
        for(var i=0; i<times; i++)
            sb.Append(ch);
    }
    
    // this function can be more optimized if we keep a list of chars available, ordered from z to a
    private char GetNextChar(int[] chars, char ch){
        for(var curr = ch-1; curr >= 'a'; curr--){
            if(chars[curr-'a'] > 0)
                return (char)curr;
        }
        return 'Z';
    }
}
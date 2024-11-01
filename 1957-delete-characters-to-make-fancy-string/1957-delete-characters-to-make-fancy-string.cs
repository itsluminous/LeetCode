public class Solution {
    public string MakeFancyString(string s) {
        if(s.Length < 3) return s;

        char preprev = s[0];
        char prev = s[1];

        var sb = new StringBuilder();
        sb.Append(preprev).Append(prev);

        for(var i=2; i<s.Length; i++){
            var curr = s[i];
            if(curr == prev && curr == preprev) continue;
            
            sb.Append(curr);
            preprev = prev;
            prev = curr;
        }

        return sb.ToString();
    }
}
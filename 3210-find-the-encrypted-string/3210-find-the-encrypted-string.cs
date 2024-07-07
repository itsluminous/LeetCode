public class Solution {
    public string GetEncryptedString(string s, int k) {
        var n = s.Length;
        var sb = new StringBuilder();

        for(var i=0; i<n; i++){
            var substitute = (i + k) % n;
            sb.Append(s[substitute]);
        }

        return sb.ToString();
    }
}
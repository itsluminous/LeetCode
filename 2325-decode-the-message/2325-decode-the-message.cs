public class Solution {
    public string DecodeMessage(string key, string message) {
        var dict = new Dictionary<char, char>();
        dict[' '] = ' ';
        
        var val = 'a';
        foreach(var ch in key){
            if(dict.ContainsKey(ch)) continue;
            dict[ch] = val;
            val++;
            if(dict.Count == 27) break;
        }
        
        var sb = new StringBuilder();
        foreach(var ch in message){
            sb.Append(dict[ch].ToString());
        }
        
        return sb.ToString();
    }
}
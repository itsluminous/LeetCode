public class Solution {
    public string[] DivideString(string s, int k, char fill) {
        var n = s.Length;
        var groups = (n + k - 1) / k;   // how many groups can we make with s
        var ans = new string[groups];

        // split s into groups
        for(var i=0; i<groups; i++)
            ans[i] = s.Substring(i*k, Math.Min(n - i*k, k));
        
        // fill extra chars in last word if applicable
        if(ans[groups-1].Length < k){
            var sb = new StringBuilder();
            sb.Append(ans[groups-1]);
            for(var i=ans[groups-1].Length; i<k; i++)
                sb.Append(fill);
            ans[groups-1] = sb.ToString();
        }

        return ans;
    }
}
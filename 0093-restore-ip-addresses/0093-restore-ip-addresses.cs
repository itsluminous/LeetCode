public class Solution {
    List<string> ans;

    public IList<string> RestoreIpAddresses(string s) {
        ans = new ();
        Backtrack(s, new StringBuilder(), 4, 0);
        return ans;
    }

    private void Backtrack(string s, StringBuilder curr, int parts, int idx){
        var n = s.Length;
        if(idx == n || n < parts) return;
        if(parts == 1 && idx < n){
            var partStr = s.Substring(idx);
            if(partStr.Length > 3) return;
            var part = int.Parse(partStr);
            if(part > 255 || partStr != part.ToString()) return;
            
            var prevLength = curr.Length;
            curr.Append(partStr);
            ans.Add(curr.ToString());
            curr.Length = prevLength;
            return;
        }

        for(var i=1; i<=3 && idx+i < n; i++){
            var partStr = s.Substring(idx, i);
            var part = int.Parse(partStr);
            if(part > 255 || partStr != part.ToString()) continue;

            var prevLength = curr.Length;
            curr.Append(partStr);
            curr.Append(".");
            Backtrack(s, curr, parts-1, idx+i);
            curr.Length = prevLength;
        }
    }
}
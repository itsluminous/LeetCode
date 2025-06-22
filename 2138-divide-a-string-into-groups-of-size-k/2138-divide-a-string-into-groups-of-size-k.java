class Solution {
    public String[] divideString(String s, int k, char fill) {
        var n = s.length();
        var groups = (n + k - 1) / k;   // how many groups can we make with s
        var ans = new String[groups];

        // split s into groups
        for(var i=0; i<groups; i++)
            ans[i] = s.substring(i*k, Math.min(n, (i+1)*k));
        
        // fill extra chars in last word if applicable
        if(ans[groups-1].length() < k){
            var sb = new StringBuilder();
            sb.append(ans[groups-1]);
            for(var i=ans[groups-1].length(); i<k; i++)
                sb.append(fill);
            ans[groups-1] = sb.toString();
        }

        return ans;
    }
}
class Solution {
    public int minDeletionSize(String[] strs) {
        var len = strs[0].length();
        var dp = new int[len];  // length of columns that are correct starting from any idx
        Arrays.fill(dp, 1);

        for(var i=len-2; i>=0; i--){
            search: for(var j=i+1; j<len; j++){
                for(var row : strs)
                    if(row.charAt(i) > row.charAt(j))
                        continue search;
                dp[i] = Math.max(dp[i], 1+dp[j]);
            }
        }

        var keep = 0;
        for(var count : dp)
            keep = Math.max(keep, count);
        return len - keep;  // deleted cols
    }
}
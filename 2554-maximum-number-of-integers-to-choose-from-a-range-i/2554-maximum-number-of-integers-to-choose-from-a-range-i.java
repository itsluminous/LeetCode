class Solution {
    public int maxCount(int[] banned, int n, int maxSum) {
        var bnd = new HashSet<Integer>();
        for(var num : banned) bnd.add(num);

        var count = 0;
        for(var num=1; num<=n; num++){
            if(bnd.contains(num)) continue;
            if(maxSum - num < 0) break;
            maxSum -= num;
            count++;
        }
        
        return count;
    }
}
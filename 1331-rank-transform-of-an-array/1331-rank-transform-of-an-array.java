class Solution {
    public int[] arrayRankTransform(int[] arr) {
        var n = arr.length;
        if(n == 0) return new int[0];

        // clone the array and sort it
        var sorted = arr.clone();
        Arrays.sort(sorted);

        // assign rank to each number
        var rank = new HashMap<Integer, Integer>();
        rank.put(sorted[0], 1);
        for(int i=1, curr=1; i<n; i++){
            if(sorted[i] == sorted[i-1]) continue;
            rank.put(sorted[i],++curr);
        }

        // build the final output
        var ans = new int[n];
        for(var i=0; i<n; i++)
            ans[i] = rank.get(arr[i]);
        
        return ans;
    }
}
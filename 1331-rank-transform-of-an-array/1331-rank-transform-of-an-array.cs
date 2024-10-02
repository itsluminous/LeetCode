public class Solution {
    public int[] ArrayRankTransform(int[] arr) {
        var n = arr.Length;
        if(n == 0) return new int[0];

        // clone the array and sort it
        var sorted = (int[])arr.Clone();
        Array.Sort(sorted);

        // assign rank to each number
        var rank = new Dictionary<int, int>();
        rank[sorted[0]] = 1;
        for(int i=1, curr=1; i<n; i++){
            if(sorted[i] == sorted[i-1]) continue;
            rank[sorted[i]] = ++curr;
        }

        // build the final output
        var ans = new int[n];
        for(var i=0; i<n; i++)
            ans[i] = rank[arr[i]];
        
        return ans;
    }
}
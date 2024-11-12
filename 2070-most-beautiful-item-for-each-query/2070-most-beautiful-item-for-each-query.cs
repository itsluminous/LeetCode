public class Solution {
    public int[] MaximumBeauty(int[][] items, int[] queries) {
        // sort array based on price asc
        Array.Sort(items, (i1, i2) => i1[0] - i2[0]);

        // find max beauty corresponding to each index in items
        var n = items.Length;
        var beauty = new int[n];
        beauty[0] = items[0][1];
        for(var i=1; i<n; i++)
            beauty[i] = Math.Max(beauty[i-1], items[i][1]);
        
        // loop through queries and find appropriate beauty
        for(var i=0; i<queries.Length; i++){
            if(queries[i] < items[0][0]){
                queries[i] = 0;
                continue;
            }

            // binary search for appropriate index in queries, and then fetch corresponding beauty
            int low=0, high=n-1;
            while(low <= high){
                var mid = low + (high - low) / 2;
                if(items[mid][0] > queries[i]) high = mid-1;
                else low = mid+1;
            }
            queries[i] = beauty[low-1];
        }

        return queries;
    }
}
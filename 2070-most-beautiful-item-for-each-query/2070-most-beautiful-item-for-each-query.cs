public class Solution {
    public int[] MaximumBeauty(int[][] items, int[] queries) {
        // sort by price
        Array.Sort(items, (i1, i2) => i1[0].CompareTo(i2[0]));
        var n = items.Length;

        // find max beauty for each index
        var beauty = new int[n];
        beauty[0] = items[0][1];
        for(var i=1; i<n; i++)
            beauty[i] = Math.Max(beauty[i-1], items[i][1]);

        // evaluate the query
        // find the appropriate index in items arr using binary search
        // then find the corresponding max beauty value in beauty array
        for(var i=0; i<queries.Length; i++){
            // if the query is lower than lowest price, then ans will be 0
            if(items[0][0] > queries[i]){
                queries[i] = 0;
                continue;
            }

            // binary search
            int low=0, high=n-1;
            while(low <= high){
                var mid = low + (high-low)/2;
                if(items[mid][0] > queries[i]) high = mid-1;
                else low = mid+1;
            }
            queries[i] = beauty[low-1];
        }

        return queries;
    }
}
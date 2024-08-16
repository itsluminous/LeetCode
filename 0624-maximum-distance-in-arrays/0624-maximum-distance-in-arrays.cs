public class Solution {
    public int MaxDistance(IList<IList<int>> arrays) {
        int smallest = 10001, biggest = -10001, maxDist = 0;
        foreach(var arr in arrays){
            maxDist = Math.Max(maxDist, biggest - arr[0]);
            maxDist = Math.Max(maxDist, arr[arr.Count-1] - smallest);
            smallest = Math.Min(smallest, arr[0]);
            biggest = Math.Max(biggest, arr[arr.Count-1]);
        }

        return maxDist;
    }
}
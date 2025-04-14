public class Solution {
    public int CountGoodTriplets(int[] arr, int a, int b, int c) {
        int n = arr.Length, triplets = 0;

        for(var i=0; i<n-2; i++){
            for(var j=i+1; j<n-1; j++){
                if(Math.Abs(arr[i] - arr[j]) > a) continue;
                for(var k=j+1; k<n; k++){
                    if(Math.Abs(arr[j] - arr[k]) > b) continue;
                    if(Math.Abs(arr[i] - arr[k]) > c) continue;
                    triplets++;
                }
            }
        }

        return triplets;
    }
}
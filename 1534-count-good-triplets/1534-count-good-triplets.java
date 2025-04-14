class Solution {
    public int countGoodTriplets(int[] arr, int a, int b, int c) {
        int n = arr.length, triplets = 0;

        for(var i=0; i<n-2; i++){
            for(var j=i+1; j<n-1; j++){
                if(Math.abs(arr[i] - arr[j]) > a) continue;
                for(var k=j+1; k<n; k++){
                    if(Math.abs(arr[j] - arr[k]) > b) continue;
                    if(Math.abs(arr[i] - arr[k]) > c) continue;
                    triplets++;
                }
            }
        }

        return triplets;
    }
}
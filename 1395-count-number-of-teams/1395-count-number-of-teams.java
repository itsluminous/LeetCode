// for each number in array, count how many on left are smaller & how many on right are greater
// do opposite for descending sequence
class Solution {
    public int numTeams(int[] rating) {
        int count = 0, n = rating.length;

        for(var i=1; i<n-1; i++){
            int[] smaller = new int[2], greater = new int[2];
            for(var j=0; j<n; j++){
                if(i == j) continue;
                if(rating[i] < rating[j]){
                    if(j > i) smaller[1]++;
                    else smaller[0]++;
                }
                else{
                    if(j > i) greater[1]++;
                    else greater[0]++;
                }
            }

            count += (smaller[0] * greater[1]) + (greater[0] * smaller[1]);
        }
        return count;
    }
}
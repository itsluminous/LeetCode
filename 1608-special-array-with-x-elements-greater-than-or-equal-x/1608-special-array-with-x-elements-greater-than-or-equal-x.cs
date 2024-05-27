public class Solution {
    public int SpecialArray(int[] nums) {
        var n = nums.Length;

        // bucket sort - count[i] means how many numbers are equal to i
        var count = new int[n+1];
        foreach(var num in nums){
            if(num > n) count[n]++;
            else count[num]++;
        }

        // from reverse, find the first idx where nums >= idx are idx
        var greaterThanCurr = 0;
        for(var idx=n; idx>0; idx--){
            greaterThanCurr += count[idx];
            if(greaterThanCurr == idx) return idx;
        }

        return -1;
    }
}
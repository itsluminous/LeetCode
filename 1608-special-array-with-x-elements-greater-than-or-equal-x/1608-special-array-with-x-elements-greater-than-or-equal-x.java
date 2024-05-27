class Solution {
    public int specialArray(int[] nums) {
        var n = nums.length;

        // bucket sort - count[i] means how many numbers are equal to i
        var count = new int[n+1];
        for(var num : nums){
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
public class Solution {
    public int MinOrAfterOperations(int[] nums, int k) {
        var n = nums.Length;
        // assume that final ans is all bits 0, later we will add bits which cannot be removed
        var minOr = 0;
        var allBitsSet = (1 << 30) -1;   //this is basically all last 29 bits set to 1

        // iterate from most significant bit to least
        for(var i=30; i>=0; i--){
            var cnt = 0; // count of elements with 0 at jth bit

            // we will now try to find numbers which have 0 at the i-th bit (i.e. they are not contributing to the i-th bit in final OR)
            var target = minOr | ((1 << i) -1);     // i-th bit is 0, and 0 to i are 1.
            var cur = allBitsSet;     // this variable will store OR of all elements

            foreach(var num in nums){
                cur &= num;
                // check if this num impacts final bit output
                if((cur | target) == target){
                    cnt++;
                    cur = allBitsSet;     // reset cur to all last 29 bits set to 1
                }
            }

            // cnt is numbers which have i-th bit 0, so numbers which contribute to i-th bit are (n-cnt)
            // if there are more than k numbers setting i-th bit, then it will be present in final ans
            if(n-cnt > k)
                minOr |= (1 << i);
        }

        return minOr;
    }
}
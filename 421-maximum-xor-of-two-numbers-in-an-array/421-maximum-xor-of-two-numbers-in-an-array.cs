// Explaination - https://leetcode.com/problems/maximum-xor-of-two-numbers-in-an-array/discuss/91049/Java-O(n)-solution-using-bit-manipulation-and-HashMap/95535
public class Solution {
    public int FindMaximumXOR(int[] nums) {
        int max = 0, mask = 0;
        for(var i=31; i>=0; i--){
            mask = mask | (1 << i);
            
            // with current mask, find all possible numbers
            var set = new HashSet<int>();
            foreach(var num in nums)
                set.Add(num & mask);
            
            // now find max
            var temp = max | (1 << i);
            foreach(var num in set){
                if(set.Contains(temp ^ num)){
                    max = temp;
                    break;
                }
            }
        }
        return max;
    }
}
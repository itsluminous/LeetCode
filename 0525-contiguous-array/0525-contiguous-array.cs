/*
O(n) approach using Hashmap/Dictionary

1. Keep a variable called runningSum
2. Keep a Hashmap called seen which will store index of first time a runningSum was seen
3. set runningSum[0] = -1. meaning, that without picking any element, running sum is 0.
4. Start traversing the array
5. Everytime you encounter a 0, subtract 1, and when you encounter 1, then add 1 to the runningSum
6. If the current runningSum exists in dictionary, then it means that all zeroes and ones between current index and the first time we saw this runningSum are equal. Update max length if (currIdx - seen.get(runningSum) > max length)
7. If the current runningSum does not exists in dictionary, then add it with current index as value
8. At the end of loop, you will have answer
*/

public class Solution {
    public int FindMaxLength(int[] nums) {
        var n = nums.Length;
        int runningSum = 0, maxLen = 0;
        
        var seen = new Dictionary<int,int>();
        seen[0] = -1;

        for (var i = 0; i < n; i++) {
            runningSum += nums[i] == 0 ? -1 : 1;

            if(seen.ContainsKey(runningSum)) {
                var lastSeen = seen[runningSum];
                maxLen = Math.Max(maxLen, i-lastSeen);
            }
            else
                seen[runningSum] = i;
        }
        
        return maxLen;
    }
}
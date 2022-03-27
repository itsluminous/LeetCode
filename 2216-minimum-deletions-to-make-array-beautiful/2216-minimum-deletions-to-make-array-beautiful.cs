public class Solution {
    public int MinDeletion(int[] nums) {
        int del = 0, prev = -1;
        foreach(var num in nums){
            if(num == prev)
                del++;
            else
                prev = prev < 0 ? num : -1;    // so that alternatively prev is -1 or a number, to take care of even/odd
        }
        
        if(prev < 0) return del;    // if even numbers
        return del + 1;             // if odd numbers
    }
}

// Accepted - space O(n)
public class Solution1 {
    public int MinDeletion(int[] nums) {
        if(nums.Length == 0) return 0;
        if(nums.Length == 1) return 1;
        
        var numList = new List<int>();
        var even = true;
        for(var i=0; i<nums.Length-1; i++){
            if(even && nums[i] == nums[i+1])
                continue;
            numList.Add(nums[i]);
            even = !even;
        }
        
        if(numList.Count % 2 == 0)
            return nums.Length - numList.Count;
        else
            return nums.Length - numList.Count - 1;
    }
}
// Using O(1) space - Boyer-Moore Voting Algorithm
public class Solution {
    public int MajorityElement(int[] nums) {
        int candidate = -1, count = 0;
        
        foreach(var num in nums){
            if(count == 0) candidate = num;
            count += num == candidate ? 1 : -1;
        }
        
        return candidate;
    }
}

// Using O(n) space
public class Solution1 {
    public int MajorityElement(int[] nums) {
        var majority = nums.Length/2;
        var dict = new Dictionary<int,int>();
        
        foreach(var num in nums){
            if(!dict.ContainsKey(num)) dict[num] = 0;
            dict[num]++;
            
            if(dict[num] > majority) return num;
        }
        
        return nums[0];
    }
}
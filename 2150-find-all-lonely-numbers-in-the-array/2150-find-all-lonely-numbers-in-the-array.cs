// Using dictionary - O(n)
public class Solution {
    public IList<int> FindLonely(int[] nums) {
        var dict = new Dictionary<int, int>();  // to count frequency of each number
        foreach(var num in nums){
            if(!dict.ContainsKey(num)) dict[num] = 0;
            dict[num]++;
        }
        
        // check for loneliness of each number
        var lonely = new List<int>();
        foreach(var num in nums){
            if(dict[num] > 1 || dict.ContainsKey(num-1) || dict.ContainsKey(num+1))
                continue;
            lonely.Add(num);
        }
        
        return lonely;
    }
}

// Accepted - O(nlogn)
public class Solution1 {
    public IList<int> FindLonely(int[] nums) {
        // base case
        if(nums.Length == 1) return new List<int>{nums[0]};
        
        Array.Sort(nums);
        var n = nums.Length;
        var lonely = new List<int>();
        
        // loop through all items except first and last and check if they are lonely based on neighbours
        for(var i=1; i<n-1; i++){
            // if any neighbour is same, then it is not lonely
            if(nums[i-1] == nums[i] || nums[i+1] == nums[i]) continue;
            // if any neighbour has val-1 or val+1 then it is not lonely
            if(nums[i-1] == nums[i]-1 || nums[i+1] == nums[i]+1) continue;
            // else it is lonely
            lonely.Add(nums[i]);
        }
        
        // check if first and last numbers are lonely
        if(nums[0] != nums[1] && nums[0]+1 != nums[1]) lonely.Add(nums[0]);
        if(nums[n-1] != nums[n-2] && nums[n-1]-1 != nums[n-2]) lonely.Add(nums[n-1]);
        
        return lonely;
    }
}
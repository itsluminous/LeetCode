// using backtracking with DP
public class Solution {
    int visited = 0;
    HashSet<int>[] seen;  // track if this bitmask has been seen or not (for given k)

    public bool CanPartitionKSubsets(int[] nums, int k) {
        if(nums.Length < k) return false;

        var totalSum = nums.Sum();
        if(totalSum % k != 0) return false;  // it can never be divided in 4

        // sort array in descending
        Array.Sort(nums);
        Array.Reverse(nums);

        var sideSum = totalSum / k;              // allowed sum of each side
        if(nums[0] > sideSum) return false;  // one stick cannot exceed sideSum

        // try to split the nums into k groups
        seen = new HashSet<int>[nums.Length+1];
        for(var i=0; i<=nums.Length; i++) seen[i] = new HashSet<int>();
        return CanPartitionKSubsets(nums, k, sideSum, 0, 0);
    }

    private bool CanPartitionKSubsets(int[] nums, int k, int targetSum, int currSum, int idx){
        // if we have already seen this mask, then useless
        if(seen[k].Contains(visited)) return false;
        seen[k].Add(visited);

        // all pending nums can be put in one side, if we need only one side
        if(k == 1) return true; 
        
        // if current side is done, then look for other sides
        if(currSum == targetSum) return CanPartitionKSubsets(nums, k-1, targetSum, 0, 0);

        // try to fit every remaining matchstick one by one to match targetSum
        for(var i=idx; i<nums.Length; i++){
            var mask = 1 << i;
            if((visited & mask) == mask || (currSum + nums[i]) > targetSum) continue;
            visited |= mask;
            if(CanPartitionKSubsets(nums, k, targetSum, currSum + nums[i], idx+1)) return true;
            visited ^= mask;
        }

        // not possible to make square with current setup
        return false;
    }
}
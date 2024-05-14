// using backtracking with DP
class Solution {
    int visited = 0;
    HashSet<Integer>[] seen;  // track if this bitmask has been seen or not (for given k)

    public boolean canPartitionKSubsets(int[] nums, int k) {
        if(nums.length < k) return false;

        var totalSum = 0;
        for(var ms : nums) totalSum += ms;
        if(totalSum % k != 0) return false;  // it can never be divided in 4

        // sort array in descending
        nums = Arrays.stream(nums)
                            .sorted()
                            .boxed()
                            .sorted((a, b) -> Integer.compare(b, a))
                            .mapToInt(Integer::intValue)
                            .toArray();

        var sideSum = totalSum / k;              // allowed sum of each side
        if(nums[0] > sideSum) return false;  // one stick cannot exceed sideSum

        // try to split the nums into k groups
        seen = new HashSet[nums.length+1];
        for(var i=0; i<=nums.length; i++) seen[i] = new HashSet<>();
        return canPartitionKSubsets(nums, k, sideSum, 0, 0);
    }

    private boolean canPartitionKSubsets(int[] nums, int k, int targetSum, int currSum, int idx){
        // if we have already seen this mask, then useless
        if(seen[k].contains(visited)) return false;
        seen[k].add(visited);

        // all pending nums can be put in one side, if we need only one side
        if(k == 1) return true; 
        
        // if current side is done, then look for other sides
        if(currSum == targetSum) return canPartitionKSubsets(nums, k-1, targetSum, 0, 0);

        // try to fit every remaining matchstick one by one to match targetSum
        for(var i=idx; i<nums.length; i++){
            var mask = 1 << i;
            if((visited & mask) == mask || (currSum + nums[i]) > targetSum) continue;
            visited |= mask;
            if(canPartitionKSubsets(nums, k, targetSum, currSum + nums[i], idx+1)) return true;
            visited ^= mask;
        }

        // not possible to make square with current setup
        return false;
    }
}
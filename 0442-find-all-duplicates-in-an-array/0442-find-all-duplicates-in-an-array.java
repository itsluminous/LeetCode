// no extra space needed
// mark a particular index as negative if we see it first time
class Solution {
    public List<Integer> findDuplicates(int[] nums) {
        var result = new ArrayList<Integer>();
        for(var num : nums){
            var abs = Math.abs(num);
            if(nums[abs-1] < 0) result.add(abs);
            else nums[abs-1]  *= -1;
        }
        return result;
    }
}

// Accepted - using extra array
class SolutionArr {
    public List<Integer> findDuplicates(int[] nums) {
        var found = new boolean[1_00_001];
        var result = new ArrayList<Integer>();
        for(var num : nums){
            if(found[num]) result.add(num);
            else found[num] = true;
        }
        return result;
    }
}
class Solution {
    List<List<Integer>> ans;

    public List<List<Integer>> subsets(int[] nums) {
        ans = new ArrayList<>();
        ans.add(new ArrayList<Integer>());

        subsets(nums, 0, new ArrayList<Integer>());
        return ans;
    }

    public void subsets(int[] nums, int idx, List<Integer> curr) {
        if(idx == nums.length) return;
        
        // don't include current
        subsets(nums, idx+1, curr);

        // include current
        curr.add(nums[idx]);
        List<Integer> newList = new ArrayList<>(curr);  // clone
        ans.add(newList);
        subsets(nums, idx+1, curr);
        curr.remove(curr.size() - 1);
    }
}
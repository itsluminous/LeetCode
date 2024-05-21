class Solution {
    List<List<Integer>> ans;

    public List<List<Integer>> permute(int[] nums) {
        ans = new ArrayList<>();
        permute(nums, new ArrayList<Integer>());
        return ans;
    }

    private void permute(int[] nums, List<Integer> list){
        if(list.size() == nums.length){
            ans.add(new ArrayList<Integer>(list));
            return;
        }

        for(var i=0; i<nums.length; i++){
            if(list.contains(nums[i])) continue;
            list.add(nums[i]);
            permute(nums, list);
            list.remove(list.size() - 1);
        }
    }
}
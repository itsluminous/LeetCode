class Solution {
    List<List<Integer>> ans;

    public List<List<Integer>> combinationSum(int[] candidates, int target) {
        Arrays.sort(candidates);
        ans = new ArrayList<>();
        combinationSum(candidates, target, new ArrayList<Integer>(), 0);
        return ans;
    }

    public void combinationSum(int[] candidates, int target, List<Integer> list, int idx) {
        if(target < 0) return;
        if(target == 0){
            ans.add(new ArrayList<Integer>(list));
            return;
        }
        for(var i=idx; i<candidates.length && candidates[i] <= target; i++){
            list.add(candidates[i]);
            combinationSum(candidates, target-candidates[i], list, i);
            list.remove(list.size() - 1);
        }
    }
}
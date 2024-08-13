class Solution {
    List<List<Integer>> combinations;

    public List<List<Integer>> combinationSum2(int[] candidates, int target) {
        Arrays.sort(candidates);
        combinations = new ArrayList<List<Integer>>();
        backtrack(candidates, target, 0, new ArrayList<Integer>());
        return combinations;
    }

    private void backtrack(int[] candidates, int target, int idx, List<Integer> combination) {
        if(target < 0) return;
        if(target == 0){
            combinations.add(new ArrayList<Integer>(combination));
            return;
        }

        for(var i=idx; i<candidates.length; i++){
            if(i > idx && candidates[i] == candidates[i-1]) continue;
            combination.add(candidates[i]);
            backtrack(candidates, target - candidates[i], i+1, combination);
            combination.remove(combination.size() - 1);
        }
    }
}
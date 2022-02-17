public class Solution {
    IList<IList<int>> result = new List<IList<int>>();
    
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Array.Sort(candidates);
        Backtrack(new List<int>(), candidates, target, 0);
        return result;
    }
    
    private void Backtrack(IList<int> temp, int[] candidates, int remaining, int start){
        if(remaining < 0) return;          // this can never give correct result
        else if(remaining == 0) result.Add(new List<int>(temp));     // we found a match
        else {
            for(int i=start; i< candidates.Length && remaining >= candidates[i]; i++){
                temp.Add(candidates[i]);
                Backtrack(temp, candidates, remaining-candidates[i], i);
                temp.RemoveAt(temp.Count -1);
            }
        }
    }
}
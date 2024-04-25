public class Solution {
    List<List<Integer>> ans;

    public List<List<Integer>> combinationSum3(int k, int n) {
        ans = new ArrayList<List<Integer>>();
        combinationSum3(k, n, 1, new ArrayList<Integer>());
        return ans;
    }

    private void combinationSum3(int k, int n, int start, List<Integer> comb){
        if(comb.size() > k || n < 0) return;
        if(comb.size() == k && n == 0){
            ans.add(new ArrayList<>(comb));
            return;
        }
        for(var i=start; i<=9; i++){
            comb.add(i);
            combinationSum3(k, n-i, i+1, comb);
            comb.remove(comb.size()-1);
        }
    }
}
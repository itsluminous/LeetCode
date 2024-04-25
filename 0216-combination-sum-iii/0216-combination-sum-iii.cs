public class Solution {
    IList<IList<int>> ans;

    public IList<IList<int>> CombinationSum3(int k, int n) {
        ans = new List<IList<int>>();
        CombinationSum3(k, n, 1, new List<int>());
        return ans;
    }

    private void CombinationSum3(int k, int n, int start, List<int> comb){
        if(comb.Count > k || n < 0) return;
        if(comb.Count == k && n == 0){
            ans.Add(comb.ToList());
            return;
        }
        for(var i=start; i<=9; i++){
            comb.Add(i);
            CombinationSum3(k, n-i, i+1, comb);
            comb.RemoveAt(comb.Count-1);
        }
    }
}
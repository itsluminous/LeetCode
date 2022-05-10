public class Solution {
    IList<IList<int>> result = new List<IList<int>>();
    
    public IList<IList<int>> CombinationSum3(int k, int n) {
        CombinationSum3(0, 1, new List<int>(), k, n);
        return result;
    }
    
    private void CombinationSum3(int sum, int curr, List<int> list, int k, int n){
        if(k == 0 && sum != n) return;
        if(k == 0 && sum == n){
            result.Add(new List<int>(list));
            return;
        }
        
        for(var i=curr; i<10; i++){
            if(sum + i > n) break;
            
            list.Add(i);
            CombinationSum3(sum+i, i+1, list, k-1, n);
            list.RemoveAt(list.Count -1);
        }
    }
}
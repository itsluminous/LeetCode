public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        Array.Sort(arr);
        var result = new List<IList<int>>();
        var diff = int.MaxValue;
        
        for(var i=1; i<arr.Length; i++){
            // if we found a pair with lesser difference, then we start a new list with this difference
            if(arr[i] - arr[i-1] < diff){
                diff = arr[i] - arr[i-1];
                result = new List<IList<int>>();
                result.Add(new List<int>{arr[i-1], arr[i]});
            }
            // if the current pair difference matches min diff, then add it to result
            else if(arr[i] - arr[i-1] == diff)
                result.Add(new List<int>{arr[i-1], arr[i]});
            
        }
        
        return result;
    }
}

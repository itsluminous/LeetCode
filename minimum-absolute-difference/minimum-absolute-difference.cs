public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        Array.Sort(arr);
        var result = new List<IList<int>>();
        var diff = arr[1] - arr[0];
        for(var i=1; i<arr.Length; i++){
            // if we found a pair with lesser difference, then we start a new list with this difference
            if(arr[i] - arr[i-1] < diff){
                diff = arr[i] - arr[i-1];
                result = new List<IList<int>>();
            }
            
            if(arr[i] - arr[i-1] == diff)
                result.Add(new List<int>{arr[i-1], arr[i]});
        }
        
        return result;
    }
}
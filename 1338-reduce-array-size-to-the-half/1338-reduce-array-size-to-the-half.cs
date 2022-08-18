public class Solution {
    public int MinSetSize(int[] arr) {
        // count occurence of each number
        var dict =  new Dictionary<int,int>();
        foreach(var num in arr){
            if(dict.ContainsKey(num)) dict[num]++;
            else dict[num] = 1;
        }
        
        // sort the counts
        var sorted = dict.Select(d => d.Value).OrderByDescending(v => v).ToArray();
        
        // find min numbers needed
        int n = arr.Length, minSize = 0, len = 0;
        foreach(var count in sorted){
            minSize++;
            len += count;
            if(len >= n/2) break;
        }
        
        return minSize;
    }
}
public class Solution {
    public int FindPairs(int[] nums, int k) {
        var dict = new Dictionary<int,int>();
        
        foreach(var num in nums){
            if(!dict.ContainsKey(num)) dict[num] = 0;
            dict[num]++;  
        }
        
        var pairs = 0;
        foreach(var num in dict.Keys){
            if(k == 0 && dict[num] > 1) pairs++;
            if(k != 0 && dict.ContainsKey(num-k)) pairs++;
        }
        return pairs;
    }
}
public class Solution {
    public int MaxOperations(int[] nums, int k) {
        // Count occurrence of each number
        var dict = new Dictionary<int,int>();
        foreach(var num in nums){
            if(num >= k) continue;  // it can never have a pair
            
            if(!dict.ContainsKey(num))
                dict[num] = 1;
            else
                dict[num]++;
        }
        
        // count number of pairs possible
        var pairs = 0;
        foreach(var num in dict.Keys){
            var numCount = dict[num];
            if(numCount == 0) continue;
            var comp = k - num; // compliment of num
            
            if(comp == num){
                pairs += (dict[num] / 2);
                continue;
            }
            else if(dict.ContainsKey(comp)){
                pairs += Math.Min(dict[num], dict[comp]);
                dict[comp] = 0;
            }
            dict[num] = 0;
        }
        
        return pairs;
    }
}
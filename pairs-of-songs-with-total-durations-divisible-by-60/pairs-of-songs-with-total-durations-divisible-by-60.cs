public class Solution {
    public int NumPairsDivisibleBy60(int[] time) {
        var total = 0;
        var dict = new Dictionary<int,int>();   // for each num, how many indexes are there
        foreach(var t in time){
            var mod60 = t % 60;
            // check if we have pair
            if(dict.ContainsKey(60 - mod60)){
                total += dict[60 - mod60];
            }
            // handle number 60, 120, 180....
            mod60 = mod60 == 0 ? 60 : mod60;
            // add current number in dictionary
            if(dict.ContainsKey(mod60))
                dict[mod60]++;
            else
                dict[mod60] = 1;
        }
        return total;
    }
}
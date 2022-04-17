public class Solution {
    public int MinimumRounds(int[] tasks) {
        var n = tasks.Length;
        
        // count frequency of each number
        var dict = new Dictionary<int, int>();
        foreach(var t in tasks){
            if(dict.ContainsKey(t)) dict[t]++;
            else dict[t] = 1;
        }
        
        int rounds = 0;
        foreach(var k in dict.Keys){
            var count = dict[k];
            if(count < 2) return -1;
            
            rounds += count/3;
            if(count % 3 != 0) rounds++;
        }
        
        return rounds;
    }
}
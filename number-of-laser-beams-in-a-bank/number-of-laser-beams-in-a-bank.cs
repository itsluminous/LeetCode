public class Solution {
    public int NumberOfBeams(string[] bank) {
        int total = 0, prev = 0;
        foreach(var str in bank){
            var curr = str.Count(c => c == '1');
            total += prev*curr;
            if(curr != 0) prev = curr;
        }
        return total;
    }
}
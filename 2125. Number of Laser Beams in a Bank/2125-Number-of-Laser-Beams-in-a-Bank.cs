public class Solution {
    public int NumberOfBeams(string[] bank) {
        int prev = 0, curr = 0, sum = 0;
        for(var i=0; i<bank.Length; i++){
            curr = bank[i].Count(c => c == '1');
            sum += curr*prev;
            if(curr != 0)
                prev = curr;
        }
        return sum;
    }
}
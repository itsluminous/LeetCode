public class Solution {
    public int FinalValueAfterOperations(string[] operations) {
        var ans = 0;
        foreach(var op in operations)
            if(op == "X++" || op == "++X") ans++;
            else ans--;
        return ans;
    }
}
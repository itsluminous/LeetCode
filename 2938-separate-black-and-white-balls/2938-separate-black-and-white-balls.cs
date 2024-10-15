public class Solution {
    public long MinimumSteps(string s) {
        var n = s.Length;
        long swaps = 0;
        
        for(int left=n-1, right=n-1; left >= 0; left--){
            if(s[left] == '1'){
                swaps += (right - left);
                right--;
            }
        }

        return swaps;
    }
}
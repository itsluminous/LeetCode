class Solution {
    public long minimumSteps(String s) {
        var n = s.length();
        long swaps = 0;
        
        for(int left=n-1, right=n-1; left >= 0; left--){
            if(s.charAt(left) == '1'){
                swaps += (right - left);
                right--;
            }
        }

        return swaps;
    }
}
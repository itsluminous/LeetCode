class Solution {
    public int[] minOperations(String boxes) {
        var n = boxes.length();
        var ans = new int[n];

        int ballsOnLeft = 0, ballsOnRight = 0;
        int movesFromLeft = 0, movesFromRight = 0;

        // count moves from left & right side
        for(var i=0; i<n; i++){
            ans[i] +=  movesFromLeft;
            ballsOnLeft += boxes.charAt(i) == '0' ? 0 : 1;
            movesFromLeft += ballsOnLeft;

            var j = n - i - 1;
            ans[j] += movesFromRight;
            ballsOnRight += boxes.charAt(j) == '0' ? 0 : 1;
            movesFromRight += ballsOnRight;
        }   
        
        return ans;
    }
}
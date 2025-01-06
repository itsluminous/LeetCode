public class Solution {
    public int[] MinOperations(string boxes) {
        var n = boxes.Length;
        var ans = new int[n];

        int ballsOnLeft = 0, ballsOnRight = 0;
        int movesFromLeft = 0, movesFromRight = 0;

        // count moves from left & right side
        for(var i=0; i<n; i++){
            ans[i] +=  movesFromLeft;
            ballsOnLeft += boxes[i] == '0' ? 0 : 1;
            movesFromLeft += ballsOnLeft;

            var j = n - i - 1;
            ans[j] += movesFromRight;
            ballsOnRight += boxes[j] == '0' ? 0 : 1;
            movesFromRight += ballsOnRight;
        }   
        
        return ans;
    }
}
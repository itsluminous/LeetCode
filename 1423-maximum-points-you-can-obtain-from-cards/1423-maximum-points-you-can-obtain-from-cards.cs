// basically idea is to find a subarray of size n-k which can be removed
public class Solution {
    public int MaxScore(int[] cardPoints, int k) {
        int n = cardPoints.Length, min = 0, sum = cardPoints.Sum();
        
        int kk = n-k, curr = 0;
        // get sum of first kk numbers in array
        for(var i=0; i<kk; i++) curr += cardPoints[i];
        min = curr;
        // now shift this window of size kk one by one and find min sum
        for(var i=0; i < k; i++){
            curr -= cardPoints[i];
            curr += cardPoints[i+kk];
            min = Math.Min(min, curr);
        }
        
        return sum-min;
    }
}


// TLE - DP
public class Solution1 {
    int max = 0;
    public int MaxScore(int[] cardPoints, int k) {
        MaxScore(cardPoints, 0, cardPoints.Length-1, 0, k);
        return max;
    }
    
    private void MaxScore(int[] points, int l, int r, int curr, int k) {
        if(k == 0){
            max = Math.Max(max, curr);
            return;
        }
        if(l > r) return;
        
        MaxScore(points, l+1, r, curr + points[l], k-1);
        if(l != r) MaxScore(points, l, r-1, curr + points[r], k-1);
    }
}
// Binary search
public class Solution {
    public int FindKthNumber(int m, int n, int k) {
        // IDEA : we have to find a no. num such that there are only k-1 no. smaller than it. then this no. will be kth smallest
        // in code below, we try to locate that num using binary search. so mid in code is the num we are talking about
        int lo = 0 , hi = m * n;
        
        while(lo < hi){
            int mid = (lo + hi) / 2, count = 0;
            // check how many numbers are smaller than mid
            for(int i=1; i<= m; i++)
                count += Math.Min(n, mid/i);
            
            // adjust lo and hi values for next binary search
            if(count >= k)  // if there are more than k numbers which are lower than mid, we want to shift left, else right
                hi = mid;
            else
                lo = mid+1;
                
        }
        
        return lo;
    }
}

// Brute force - Out of memory
public class Solution1 {
    public int FindKthNumber(int m, int n, int k) {
        var matrix = new int[m*n];
        for(var i=1; i<=m; i++){
            for(var j=1; j<=n; j++){
                matrix[(i-1)*n + j - 1] = i*j;
            }
        }
        
        Array.Sort(matrix);
        return matrix[k-1];
    }
}
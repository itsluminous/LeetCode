// let k be max any store can hold.
// We try k between 1, 10^5 and find the min value which allows us to distribute all products
public class Solution {
    public int MinimizedMaximum(int n, int[] quantities) {
        int low = 1, high = 100000;
        while(low < high){
            var mid = low + (high - low) / 2;
            if(CanDistribute(n, quantities, mid))
                high = mid;
            else
                low = mid+1;
        }
        return high;
    }
    
    private bool CanDistribute(int n, int[] quantities, int k){
        foreach(var q in quantities){
            var parts = (q + k -1) / k;    // same as ceil(q / k). ceil because if any remainder is left, that goes to a new store
            if(n < parts) return false;
            n -= parts;
        }
        return true;
    }
}
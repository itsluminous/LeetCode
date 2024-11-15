// the array after removing something will either start at 0, or end at n-1, or both
// so at least one end will be there for sure
public class Solution {
    public int FindLengthOfShortestSubarray(int[] arr) {
        int n = arr.Length, lidx = 0, ridx = n-1;
        if(n == 1) return 0;    // already sorted
        
        // find index of where decreasing arr starting at n-1 ends
        while(ridx > 0 && arr[ridx] >= arr[ridx-1]) ridx--;

        // find optimal idx in right part, to merge with left part
        var removalLen = ridx;
        while(lidx < ridx && (lidx == 0 || arr[lidx-1] <= arr[lidx])){
            while(ridx < n && arr[lidx] > arr[ridx])
                ridx++;
            removalLen = Math.Min(removalLen, ridx - lidx - 1);
            lidx++;
        }

        return removalLen;
    }
}

// Accepted - binary search
// the array after removing something will either start at 0, or end at n-1, or both
// so at least one end will be there for sure
public class SolutionBS {
    public int FindLengthOfShortestSubarray(int[] arr) {
        int n = arr.Length, lidx = 0, ridx = n-1;
        if(n == 1) return 0;    // already sorted
        
        // find index of where increasing arr starting at 0 ends
        while(lidx < n-1 && arr[lidx+1] >= arr[lidx]) lidx++;

        // full arr is ascending
        if(lidx == n-1) return 0;
        
        // find index of where decreasing arr starting at n-1 ends
        while(arr[ridx] >= arr[ridx-1]) ridx--;

        // best case - right array fits just next to left array
        if(arr[ridx] >= arr[lidx]) return ridx - lidx - 1;

        // find optimal idx in right part, to merge with left part
        var sortedLen = lidx + 1;
        for(var i=ridx; i<n; i++){
            var len = GetMaxLen(arr, lidx, i);
            sortedLen = Math.Max(sortedLen, len);
        }

        // remove anything which is not part of sorted array
        return n - sortedLen;
    }

    private int GetMaxLen(int[] arr, int end, int idx){
        int n = arr.Length, start = 0;
        var rightLen = n - idx;

        if(arr[idx] >= arr[end]) return (end + 1) + rightLen;
        if(arr[idx] < arr[start]) return rightLen;
        
        while(start < end){
            var mid = start + (end - start) / 2;
            if(arr[mid] <= arr[idx]) start = mid+1;
            else end = mid;
        }
        return start + rightLen;
    }
}
class Solution {
    public int FindInMountainArray(int target, MountainArray mountainArr) {
        var n = mountainArr.Length();

        // find out the peak of mountain
        int l=1, r=n-1;
        while(l<r){
            var mid = (l+r) >> 1;
            int midVal = mountainArr.Get(mid), nextVal = mountainArr.Get(mid+1);
            if( midVal < nextVal){
                if(midVal == target) return mid;
                if(nextVal == target) return mid+1;
                l = mid+1;
            }
            else r = mid;
        }
        var peak = l;

        // search on left of peak
        l=0; r=peak;
        while(l<r){
            var mid = (l+r) >> 1;
            var mVal = mountainArr.Get(mid);
            if(mVal == target) return mid;
            if(mVal > target) r=mid;
            else l=mid+1;
        }

        // search on right side of peak
        l=peak; r=n;
        while(l<r){
            var mid = (l+r) >> 1;
            var mVal = mountainArr.Get(mid);
            if(mVal == target) return mid;
            if(mVal > target) l=mid+1;
            else r=mid;
        }
        return -1;
    }
}

/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */
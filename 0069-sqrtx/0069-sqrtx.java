class Solution {
    public int mySqrt(int x) {
        if(x <= 1) return x;

        int left = 1, right = x/2;
        while(true){
            var mid = left + (right - left)/2;
            if(mid > x / mid)
                right = mid - 1;
            else if(mid+1 > x / (mid+1) )
                    return mid;
            else
                left = mid + 1;
        }
    }
}
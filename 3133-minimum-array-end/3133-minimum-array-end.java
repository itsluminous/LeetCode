// Accepted - O(n)
public class Solution {
    public long minEnd(int n, int x) {
        long ans = x;    // start with x, because that is the smallest number we can have
        while(--n > 0){
            ans++;      // increment ans
            ans |= x;   // OR with x to keep the required bits always 1
        }
        return ans;
    }
}
public class Solution {
    public int NumberOfSubstrings(string s) {
        var n = s.Length;;
        var count = 0;

        // create prefix array to count 1's till any index
        var pre = new int[n+1]; 
        for(var i=0; i<n; i++)
            pre[i+1] = pre[i] + (s[i] == '1' ? 1 : 0);
        
        // fix the starting point, and expand the end point on right
        for(var l=0; l<n; l++){
            for(var r=l; r<n; r++){
                var one = pre[r+1] - pre[l];
                var zero = (r - l + 1) - one;

                // zero is dominant
                // shift r by x index, such that we are sure that in next x index zero will stay dominant
                if(zero * zero > one){
                    var onesNeeded = zero * zero - one;
                    r += onesNeeded - 1;    // -1 because loop will increment r by 1
                }

                // perfectly balanced - nothing to skip
                else if(zero * zero == one)
                    count++;
                
                // one is dominant
                // we can make some extra subarrays
                else if(zero * zero < one){
                    count++;

                    // try to expand to right
                    var extraOnes = (int)Math.Sqrt(one) - zero;
                    var nextR = r + extraOnes;
                    if(nextR >= n) nextR = n-1;     // edge case - if r crosses len of string
                    count += nextR - r;     // we can definitely make these many substrings

                    r = nextR;
                }
            }
        }

        return count;
    }
}
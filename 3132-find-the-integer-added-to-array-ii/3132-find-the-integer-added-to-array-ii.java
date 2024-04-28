// after sorting, the diff has to be one of these [nums2[0] - nums1[0], nums2[0] - nums1[1], nums2[0] - nums1[2]]
// for each of these diff, just check which fits the other numbers
public class Solution {
    public int minimumAddedInteger(int[] nums1, int[] nums2) {
        Arrays.sort(nums1);
        Arrays.sort(nums2);
        var ans = Integer.MAX_VALUE;

        // one by one skip first 3 indexes in nums1
        for(var i=0; i<3; i++){
            var currDiff = nums2[0] - nums1[i];
            var skip = i;   // we can skip only 2 elements. so if more than 2 are skipped, it is not an ans
            for(var j=i+1; skip<3 && j < nums2.length+skip; j++){
                if(currDiff != nums2[j - skip] - nums1[j])
                    skip++;
            }

            if(skip < 3)
                ans = Math.min(ans, currDiff);
        }
        return ans;
    }
}
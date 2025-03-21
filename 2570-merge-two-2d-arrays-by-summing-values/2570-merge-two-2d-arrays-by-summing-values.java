class Solution {
    public int[][] mergeArrays(int[][] nums1, int[][] nums2) {
        int len1 = nums1.length, len2 = nums2.length;
        int idx1 = 0, idx2 = 0;
        var ans = new ArrayList<int[]>();

        while(idx1 < len1 && idx2 < len2){
            if(nums1[idx1][0] == nums2[idx2][0]){
                ans.add(new int[]{nums1[idx1][0], nums1[idx1][1] + nums2[idx2][1]});
                idx1++;
                idx2++;
            }
            else if(nums1[idx1][0] < nums2[idx2][0]){
                ans.add(nums1[idx1]);
                idx1++;
            }
            else{
                ans.add(nums2[idx2]);
                idx2++;
            }
        }

        while(idx1 < len1){
            ans.add(nums1[idx1]);
            idx1++;
        }

        while(idx2 < len2){
            ans.add(nums2[idx2]);
            idx2++;
        }

        return ans.toArray(new int[0][]);
    }
}
public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int pos = m+n-1, i = m-1, j=n-1;
        while(i>=0 && j>=0){
           if(nums1[i] < nums2[j])
               nums1[pos--] = nums2[j--];
            else
               nums1[pos--] = nums1[i--];
        }
        
        while(j >= 0)
            nums1[pos--] = nums2[j--];
    }
}
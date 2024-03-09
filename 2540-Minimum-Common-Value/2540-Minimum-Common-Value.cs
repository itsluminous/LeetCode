public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) {
        int n1=0, n2=0;
        while(n1 < nums1.Length && n2 < nums2.Length){
            if(nums1[n1] == nums2[n2]) 
                return nums1[n1];
            
            if(nums1[n1] < nums2[n2]) 
                n1++;
            else 
                n2++;
        }
        return -1;
    }
}
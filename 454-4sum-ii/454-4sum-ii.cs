public class Solution {
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
        var n = nums1.Length;
        Dictionary<int, int> dict12 = new Dictionary<int, int>();
        
        // first we find all possible totals for nums1 and nums2
        for(var i=0; i<n; i++)
            for(var j=0; j<n; j++){
                var tot = nums1[i] + nums2[j];
                if(!dict12.ContainsKey(tot)) dict12[tot] = 1;
                else dict12[tot]++;
            }
        
        // then we find all possible totals of nums3 and nums4
        // and we parallelly check if any number in dict can make it 0
        var zeroes = 0;
        for(var i=0; i<n; i++)
            for(var j=0; j<n; j++){
                var negTot = -1 * (nums3[i] + nums4[j]);
                if(dict12.ContainsKey(negTot))
                    zeroes += dict12[negTot];
            }
        
        return zeroes;
    }
}
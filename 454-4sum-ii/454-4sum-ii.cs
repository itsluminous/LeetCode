public class Solution {
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
        var n = nums1.Length;
        Dictionary<int, int> dict12 = new Dictionary<int, int>(), dict34 = new Dictionary<int, int>();
        for(var i=0; i<n; i++)
            for(var j=0; j<n; j++){
                var tot = nums1[i] + nums2[j];
                if(!dict12.ContainsKey(tot)) dict12[tot] = 1;
                else dict12[tot]++;
            }
        
        for(var i=0; i<n; i++)
            for(var j=0; j<n; j++){
                var tot = nums3[i] + nums4[j];
                if(!dict34.ContainsKey(tot)) dict34[tot] = 1;
                else dict34[tot]++;
            }
        
        var zeroes = 0;
        foreach(var d12Key in dict12.Keys)
            foreach(var d34Key in dict34.Keys){
                if(d12Key + d34Key == 0){
                    zeroes += dict12[d12Key]*dict34[d34Key];
                }
            }
        
        return zeroes;
    }
}
public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        var freq = new int[1001];
        foreach(var num in nums1)
            freq[num]++;
        
        var ans = new List<int>();
        foreach(var num in nums2){
            if(freq[num] > 0){
                ans.Add(num);
                freq[num]--;
            }
        }

        return ans.ToArray();
    }
}
public class Solution {
    public int[] FrequencySort(int[] nums) {
        // count freq of each number
        var freq = new int[201];
        foreach(var num in nums)
            freq[num + 100]++;
        
        // sort the numbers based on logic
        Array.Sort(nums, (n1, n2) => {
            if(freq[n1+100] == freq[n2+100]) return n2.CompareTo(n1);
            return freq[n1+100].CompareTo(freq[n2+100]);
        });

        // return the sorted nums
        return nums;
    }
}
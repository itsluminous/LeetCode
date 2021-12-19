public class Solution {
    public int KIncreasing(int[] arr, int k) {
        var operations = 0;
        for(var start=0; start<k; start++){
            // make a new list for the numbers at index start, start+1k, start+2k, .....
            var list = new List<int>();
            for(var i=start;i<arr.Length; i+=k) list.Add(arr[i]);
            // any number which is not part of LIS will have to be modified
            operations += list.Count - LIS(list);
        }
        
        return operations;
    }
    
    // LongestNonDecreasingSubsequence - https://leetcode.com/problems/longest-increasing-subsequence/discuss/1326308
    private int LIS(List<int> list){
        var subSeq = new List<int>();
        foreach(var num in list){
            // Append to LIS if new element is >= last element in LIS
            if(subSeq.Count == 0 || subSeq[subSeq.Count-1] <= num)
                subSeq.Add(num);
            else{
                // Find the index of the smallest number which is greater than current num
                var idx = subSeq.BinarySearch(num+1);
                var idxGreaterThanNum = idx < 0 ? ~idx : idx;
                // Replace that number with current num
                subSeq[idxGreaterThanNum] = num;
            }
        }
        
        return subSeq.Count;
    }
}
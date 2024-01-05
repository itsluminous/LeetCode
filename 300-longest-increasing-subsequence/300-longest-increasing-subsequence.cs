// Greedy with binary search
// https://leetcode.com/problems/longest-increasing-subsequence/solutions/1326308/c-python-dp-binary-search-bit-segment-tree-solutions-picture-explain-o-nlogn/?envType=daily-question&envId=2024-01-05
public class Solution {
    public int LengthOfLIS(int[] nums) {
		List<int> lst = new(nums.Length);
        foreach(var num in nums){
            if(lst.Count == 0 || lst[lst.Count-1] < num)
                lst.Add(num);
            else{
                var idx = lst.BinarySearch(num);
                // idx will be >= 0 if exact match is found
                // bitwise complement to find the first number greater than num
                if (idx < 0) idx = ~idx;
                lst[idx] = num;
            }
        }
        return lst.Count;
    }
}

// https://www.youtube.com/watch?v=mouCn3CFpgg
public class SolutionDP {
    public int LengthOfLIS(int[] nums) {
        var n = nums.Length;
        if(n <= 1) return n;
        
        // lis array keeps track of what is idx of i-th element in longest subseq in which it is present
        var lis = new int[n];
        // for any single digit, Length of LIS will be just 1
        for(var i=0; i<n; i++) lis[i] = 1;   
        
        var max = 1;
        for(var i=1; i<n; i++){
            for(var j=0; j<i; j++){
                // if nums[i] is greater than nums[j] 
                // and i is currently part of a different subseq where len(i's subseq) <= len(j's subseq)
                // then we add i to the same subsequence as j
                if(nums[i] > nums[j] && lis[i] <= lis[j]){
                    lis[i] = lis[j] + 1;
                    max = Math.Max(max, lis[i]);
                }
            }
        }
        
        return max;
    }
}
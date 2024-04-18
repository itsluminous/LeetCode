public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var rand = new Random();
        var pivot = nums[rand.Next(nums.Length)];

        List<int> left = new List<int>(), right = new List<int>(), mid = new List<int>();
        foreach(var num in nums){
            if(num < pivot) right.Add(num);
            else if(num > pivot) left.Add(num);
            else mid.Add(num);
        }

        int l = left.Count, m = mid.Count;
        if(l >= k)
            return FindKthLargest(left.ToArray(), k);
        if(l + m < k)
            return FindKthLargest(right.ToArray(), k-(l+m));
        return mid[0];
    }
}

// Accepted - O(n logn)
public class SolutionSort {
    public int FindKthLargest(int[] nums, int k) {
        var n = nums.Length;
        Array.Sort(nums);
        return nums[n-k];
    }
}
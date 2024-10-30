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
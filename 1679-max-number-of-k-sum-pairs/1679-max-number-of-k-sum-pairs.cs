// O(n) - using extra space
public class Solution {
    public int MaxOperations(int[] nums, int k) {
        var dict = new Dictionary<int, int>();
        var ops = 0;
        foreach(var num in nums){
            if(dict.ContainsKey(num)){
                ops++;
                dict[num]--;

                if(dict[num] == 0) dict.Remove(num);
            }
            else{
                var compliment = k - num;
                if(dict.ContainsKey(compliment)) dict[compliment]++;
                else dict[compliment] = 1;
            }
        }
        return ops;
    }
}

// Accepted, using no space - O(NlogN)
public class SolutionSort {
    public int MaxOperations(int[] nums, int k) {
        Array.Sort(nums);
        int l = 0, r = nums.Length-1, ops = 0;
        
        while(l < r){
            var sum = nums[l] + nums[r];
            if(sum == k){
                ops++;
                l++;
                r--;
            }
            else if(sum < k) l++;
            else r--;

        }
        return ops;
    }
}
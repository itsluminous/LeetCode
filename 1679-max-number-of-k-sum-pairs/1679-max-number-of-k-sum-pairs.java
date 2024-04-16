// O(n) - using extra space
public class Solution {
    public int maxOperations(int[] nums, int k) {
        var map = new HashMap<Integer, Integer>();
        var ops = 0;
        for(var num : nums){
            if(map.containsKey(num)){
                ops++;
                map.put(num, map.get(num) - 1);
                if(map.get(num) == 0) map.remove(num);
            }
            else{
                var compliment = k - num;
                map.put(compliment, map.getOrDefault(compliment, 0) + 1);
            }
        }
        return ops;
    }
}

// Accepted, using no space - O(NlogN)
class SolutionSort {
    public int maxOperations(int[] nums, int k) {
        Arrays.sort(nums);
        int l = 0, r = nums.length-1, ops = 0;
        
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
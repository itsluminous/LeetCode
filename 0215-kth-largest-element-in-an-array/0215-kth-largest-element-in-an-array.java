// quick select
class Solution {
    public int findKthLargest(int[] nums, int k) {
        var arrList = Arrays.stream(nums).boxed().collect(Collectors.toList());
        return helper(arrList, k);
    }

    public int helper(List<Integer> nums, int k) {
        var rand = new Random();
        var pivot = nums.get(rand.nextInt(nums.size()));

        List<Integer> left = new ArrayList<>(), right = new ArrayList<>(), mid = new ArrayList<>();
        for(var num : nums){
            if(num < pivot) right.add(num);
            else if(num > pivot) left.add(num);
            else mid.add(num);
        }

        int l = left.size(), m = mid.size();
        if(l >= k)
            return helper(left, k);
        if(l + m < k)
            return helper(right, k-(l+m));
        return mid.get(0);
    }
}

class SolutionSort {
    public int findKthLargest(int[] nums, int k) {
        var n = nums.length;
        Arrays.sort(nums);
        return nums[n-k];
    }
}
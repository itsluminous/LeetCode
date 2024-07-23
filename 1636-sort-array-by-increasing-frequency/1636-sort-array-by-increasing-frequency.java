class Solution {
    public int[] frequencySort(int[] nums) {
        // count freq of each number
        var freq = new int[201];
        for(var num : nums)
            freq[num + 100]++;
        
        // sort the numbers based oon logic
        var numsObj = Arrays.stream(nums).boxed().toArray(Integer[]::new);
        Arrays.sort(numsObj, (n1, n2) -> {
            if(freq[n1+100] == freq[n2+100]) return Integer.compare(n2, n1);
            return Integer.compare(freq[n1+100], freq[n2+100]);
        });

        // return the sorted nums
        for(var i=0; i<nums.length; i++)
            nums[i] = numsObj[i];
        return nums;
    }
}
class Solution {
    public int[] findIntersectionValues(int[] nums1, int[] nums2) {
        HashSet<Integer> num1Set = new HashSet<>(), num2Set = new HashSet<>();
        int count1 = 0, count2 = 0;

        for(var num : nums1) num1Set.add(num);
        for(var num : nums2) num2Set.add(num);

        for(var num : nums1)
            if(num2Set.contains(num)) count1++;

        for(var num : nums2)
            if(num1Set.contains(num)) count2++;

        return new int[]{count1, count2};
    }
}
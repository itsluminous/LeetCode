class Solution {
    public int[] nextGreaterElement(int[] nums1, int[] nums2) {
        var greater = findAllGreater(nums2);
        for(var i = 0; i < nums1.length; i++)
            nums1[i] = greater[nums1[i]];
        
        return nums1;
    }

    private int[] findAllGreater(int[] nums){
        var greater = new int[10001];
        var stack = new Stack<Integer>();

        for(var i = nums.length - 1; i >= 0; i--){
            var curr = nums[i];
            while(!stack.isEmpty() && stack.peek() < curr)
                stack.pop();
            
            if(stack.isEmpty())
                greater[curr] = -1;
            else
                greater[curr] = stack.peek();
            
            stack.push(curr);
        }

        return greater;
    }
}

public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var greater = FindAllGreater(nums2);
        for(var i = 0; i < nums1.Length; i++)
            nums1[i] = greater[nums1[i]];
        
        return nums1;
    }

    private int[] FindAllGreater(int[] nums){
        var greater = new int[10001];
        var stack = new Stack<int>();

        for(var i = nums.Length - 1; i >= 0; i--){
            var curr = nums[i];
            while(stack.Count > 0 && stack.Peek() < curr)
                stack.Pop();
            
            if(stack.Count == 0)
                greater[curr] = -1;
            else
                greater[curr] = stack.Peek();
            
            stack.Push(curr);
        }

        return greater;
    }
}

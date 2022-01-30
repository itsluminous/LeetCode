public class Solution1 {
    public void Rotate(int[] nums, int k) {
        var n = nums.Length;
        k = k % n;
        var temp = new int[k];
        for(var i=0; i<k; i++)
            temp[i] =  nums[i+n-k];
        
        for(var i=n-1; i>=k; i--)
            nums[i] = nums[i-k];
        
        for(var i=0; i<k; i++)
            nums[i] = temp[i];
    }
}

// without using extra space
public class Solution {
    public void Rotate(int[] nums, int k) {
        var length = nums.Length;
        k %= length;
        reverse(nums, 0, length - 1);
        reverse(nums, 0, k - 1);
        reverse(nums, k, length - 1);
    }
    
    public void reverse(int[] nums, int left, int right) {
        while (left <= right) {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
            left++;
            right--;
        }
    }
}
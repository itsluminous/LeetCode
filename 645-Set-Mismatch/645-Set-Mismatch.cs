public class Solution {
    public int[] FindErrorNums(int[] nums) {
        int n = nums.Length, duplicate = -1;
        var present = new bool[n+1];
        
        for(int i=0; i<n; i++)
            if(present[nums[i]]) duplicate=nums[i];
            else present[nums[i]] = true;
        
        for(int m=1; m<n+1; m++)
            if(!present[m])
                return new[]{duplicate,m};
        
        return new int[2];
    }
}
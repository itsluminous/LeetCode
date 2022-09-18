// same soln as below without using extra space
public class Solution {
    public int Trap(int[] height) {
        int l = 0, r = height.Length -1;
        int lMax = 0, rMax = 0;
        int rain = 0;
        
        while(l < r){
            if(height[l] <= height[r]){
                if(lMax < height[l]) lMax = height[l];
                else rain += lMax-height[l];
                l++;
            }
            else{
                if(rMax < height[r]) rMax = height[r];
                else rain += rMax-height[r];
                r--;
            }
        }
        
        return rain;
    }
}

// accepted
public class Solution1 {
    public int Trap(int[] height) {
        var l = height.Length;
        var lMaxArr = new int[l];
        var rMaxArr = new int[l];
        lMaxArr[0] = height[0];
        rMaxArr[l-1] = height[l-1];
        int rain = 0;
        
        for(int i=1; i<l; i++)
            lMaxArr[i] = Math.Max(height[i], lMaxArr[i-1]);
        
        for(int i=l-2; i>= 0; i--)
            rMaxArr[i] = Math.Max(height[i], rMaxArr[i+1]);
        
        for(int i=1; i<l-1; i++)
            rain += Math.Min(lMaxArr[i], rMaxArr[i]) - height[i];
        
        return rain;
    }
}
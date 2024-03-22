public class Solution {
    public int Jump(int[] nums) {
        var n = nums.Length;
        
        var minJump = new int[n];
        for(var i=1; i<n; i++)
            minJump[i] = Int32.MaxValue;

        for(var i=0; i<n; i++){
            if(minJump[i] == Int32.MaxValue) continue;  // we cannot reach this step
            for(var j=1; j<=nums[i] && i+j<n; j++){
                minJump[i+j] = Math.Min(minJump[i+j], minJump[i] + 1);
            }
        }

        return minJump[n-1];
    }
}

// Accepted
public class Solution2 {
    public int Jump(int[] nums) {
        // ALGORITHM
        // Consider each nums value to be a separate ladder
        // we will switch ladder only when current ladder ends
        // return value will be number of switches we make
        int maxPos = 0, currMaxPos = 0, steps = 0;
        for(var i=0; i<nums.Length; i++){
            if(currMaxPos < i){     // we need to switch to different ladder now
                currMaxPos = maxPos;
                steps++;
            }
            maxPos = Math.Max(maxPos, i+nums[i]);
        }
        
        return steps;
    }
 }   

// Accepted
public class Solution1 {
    public int Jump(int[] nums) {
        var currEnd = 0;
        var farthest = 0;
        var steps = 0;
        
        for(int i=0; i<nums.Length-1; i++){
            farthest = Math.Max(farthest, i + nums[i]);
            if(currEnd == i){
                steps++;
                currEnd = farthest;
                
                // if our current ladder reaches final already, we can break loop
                if(currEnd >= nums.Length)
                    return steps;
            }
        }
        return steps;
    }
}
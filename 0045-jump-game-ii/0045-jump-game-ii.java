class Solution {
    public int jump(int[] nums) {
        var n = nums.length;
        
        var minJump = new int[n];
        for(var i=1; i<n; i++)
            minJump[i] = Integer.MAX_VALUE;

        for(var i=0; i<n; i++){
            if(minJump[i] == Integer.MAX_VALUE) continue;  // we cannot reach this step
            for(var j=1; j<=nums[i] && i+j<n; j++){
                minJump[i+j] = Math.min(minJump[i+j], minJump[i] + 1);
            }
        }

        return minJump[n-1];
    }
}

// Accepted
class Solution2 {
    public int jump(int[] nums) {
        // ALGORITHM
        // Consider each nums value to be a separate ladder
        // we will switch ladder only when current ladder ends
        // return value will be number of switches we make
        int maxPos = 0, currMaxPos = 0, steps = 0;
        for(var i=0; i<nums.length; i++){
            if(currMaxPos < i){     // we need to switch to different ladder now
                currMaxPos = maxPos;
                steps++;
            }
            maxPos = Math.max(maxPos, i+nums[i]);
        }
        
        return steps;
    }
 }   

// Accepted
class Solution1 {
    public int jump(int[] nums) {
        int currEnd = 0, farthest = 0, steps = 0;
        
        for(int i=0; i<nums.length-1; i++){
            farthest = Math.max(farthest, i + nums[i]);
            if(currEnd == i){
                steps++;
                currEnd = farthest;
                
                // if our current ladder reaches final already, we can break loop
                if(currEnd >= nums.length)
                    return steps;
            }
        }
        return steps;
    }
}
public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        var n = nums.Length;
        int first = int.MaxValue, second = int.MaxValue;

        foreach(var num in nums){
            if(num <= first) first = num;           // first element of sequence found
            else if(num <= second) second = num;    // second element of sequence found
            else return true;                       // third element of sequence found
        }

        return false;
    }
}

// Accepted - using additional space
public class SolutionExtraSpace {
    public bool IncreasingTriplet(int[] nums) {
        var n = nums.Length;
        var smallest = new int[n];

        var curr = nums[0];
        for(var i=1; i<n; i++){
            smallest[i] = Math.Min(curr, nums[i-1]);
            curr = smallest[i];
        }

        curr = nums[n-1];
        for(var i=n-2; i>0; i--){
            curr = Math.Max(curr, nums[i+1]);
            if(smallest[i] < nums[i] && nums[i] < curr)
                return true;
        }

        return false;
    }
}
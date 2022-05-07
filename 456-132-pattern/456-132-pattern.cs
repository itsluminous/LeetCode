public class Solution {
    public bool Find132pattern(int[] nums) {
        var numk = int.MinValue;
        var stack = new Stack<int>();   // to keep track of max num till now (i.e. numj)
        
        // traverse in reverse
        for(var i=nums.Length-1; i>=0; i--){
            var numi = nums[i];
            if(numi < numk)     // and stack top i.e. numj is already greater than numk
                return true;
            else{
                while(stack.Count > 0 && numi > stack.Peek())
                    numk = stack.Pop();
            }
            stack.Push(numi);   // new numj
        }
        
        return false;
    }
}

public class SolutionForSubstring {
    public bool Find132pattern(int[] nums) {
        var n = nums.Length;
        if(n < 3) return false;
        
        int numi = nums[0], numj = nums[1], numk;
        for(var i=2; i<n; i++){
            numk = nums[i];
            if(Pattern(numi, numj, numk))
                return true;
            numi = numj;
            numj = numk;
        }
        
        return false;
    }
    
    private bool Pattern(int numi, int numj, int numk){
        if(numi < numk && numk < numj)
            return true;
        return false;
    }
}
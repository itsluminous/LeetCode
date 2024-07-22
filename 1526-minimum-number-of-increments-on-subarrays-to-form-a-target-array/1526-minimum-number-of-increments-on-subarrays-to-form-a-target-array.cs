public class Solution {
    public int MinNumberOperations(int[] target) {
        int ops = 0, incr = 0;
        foreach(var num in target){
            if(num > incr)
                ops += (num - incr);
            incr = num;
        }

        return ops;
    }
}
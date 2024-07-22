class Solution {
    public int minNumberOperations(int[] target) {
        int ops = 0, incr = 0;
        for(var num : target){
            if(num > incr)
                ops += (num - incr);
            incr = num;
        }

        return ops;
    }
}
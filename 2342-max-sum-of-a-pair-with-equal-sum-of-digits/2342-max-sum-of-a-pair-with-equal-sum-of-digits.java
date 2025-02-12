class Solution {
    public int maximumSum(int[] nums) {
        var maxsum = -1;
        var sumMap = new HashMap<Integer, Integer>();    // key = sum of digits, val = biggest no. for given digit sum
        
        for(var num : nums){
            var s = NumSum(num);
            if(sumMap.containsKey(s)){
                maxsum = Math.max(maxsum, num + sumMap.get(s));
                sumMap.put(s, Math.max(sumMap.get(s), num));
            }
            else
                sumMap.put(s, num);
        }
        
        return maxsum;
    }

    private int NumSum(int num){
        var s = 0;
        while(num > 0){
            s += num % 10;
            num /= 10;
        }
        return s;
    }
}
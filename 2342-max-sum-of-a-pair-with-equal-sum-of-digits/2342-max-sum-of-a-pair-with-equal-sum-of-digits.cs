public class Solution {
    public int MaximumSum(int[] nums) {
        int NumSum(int num){
            var s = 0;
            while(num > 0){
                s += num % 10;
                num /= 10;
            }
            return s;
        }

        var maxsum = -1;
        var sumMap = new Dictionary<int, int>();    // key = sum of digits, val = biggest no. for given digit sum
        
        foreach(var num in nums){
            var s = NumSum(num);
            if(sumMap.ContainsKey(s)){
                maxsum = Math.Max(maxsum, num + sumMap[s]);
                sumMap[s] = Math.Max(sumMap[s], num);
            }
            else
                sumMap[s] = num;
        }
        
        return maxsum;
    }
}
public class Solution {
    public int CountLargestGroup(int n) {
        var maxSize = 0;
        var map = new Dictionary<int, int>();
        for(var num=1; num<=n; num++){
            var digitSum = GetDigitSum(num);
            if(!map.ContainsKey(digitSum)) map[digitSum] = 1;
            else map[digitSum] = 1 + map[digitSum];
            maxSize = Math.Max(maxSize, map[digitSum]);
        }

        var count = 0;
        foreach(var size in map.Values)
            if(size == maxSize) count++;

        return count;
    }

    private int GetDigitSum(int num){
        var digitSum = 0;
        while(num > 0){
            digitSum += num % 10;
            num /= 10;
        }
        return digitSum;
    }
}
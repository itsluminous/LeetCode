class Solution {
    public int countLargestGroup(int n) {
        var maxSize = 0;
        var map = new HashMap<Integer, Integer>();
        for(var num=1; num<=n; num++){
            var digitSum = getDigitSum(num);
            map.put(digitSum, 1 + map.getOrDefault(digitSum, 0));
            maxSize = Math.max(maxSize, map.get(digitSum));
        }

        var count = 0;
        for(var size : map.values())
            if(size == maxSize) count++;

        return count;
    }

    private int getDigitSum(int num){
        var digitSum = 0;
        while(num > 0){
            digitSum += num % 10;
            num /= 10;
        }
        return digitSum;
    }
}
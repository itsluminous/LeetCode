public class Solution {
    public long SumDigitDifferences(int[] nums) {
        var n = nums.Length;
        var d = nums[0].ToString().Length;

        long totalDiff = 0;

        for (var pos = 0; pos < d; pos++)
        {
            // count freq of each digit in all nums
            var freq = new int[10];
            for(var i=0; i<n; i++){
                var digit = nums[i] % 10;
                freq[digit]++;
                nums[i] /= 10;      // remove last digit which is already processed
            }
            
            // count the other digits that need to be changed because of each digit
            for (var digit = 0; digit < 10; digit++)
            {
                var count = freq[digit];
                totalDiff += count * (n - count) * 1;  // Each pair contributes exactly 1 to the difference
            }
        }

        return totalDiff / 2;   // we are doing double counting above, so div by 2
    }
}
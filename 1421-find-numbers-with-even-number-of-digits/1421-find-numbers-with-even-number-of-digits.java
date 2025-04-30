// using logarithm
// All x such that 10^k ≤ x < 10^k+1 have k+1 digits where k ≥ 0.
// Applying log10 on both side : k ≤ log x < k+1
// taking care of decimal, count of digits in a num = ceil( log10(num) ) = k+1
// but if log10(num) has 0 decimal, then ceil( log10(num) ) = k
// so, we use floor. Hence, count of digits = floor( log10(num) ) + 1
class Solution {
    public int findNumbers(int[] nums) {
        var count = 0;
        for(var num : nums){
            var digits = (int) Math.floor(Math.log10(num) + 1);
            if((digits & 1) == 0) count++;
        }
        return count;
    }
}

// Accepted - simple if else
class Solutionif {
    public int findNumbers(int[] nums) {
        var count = 0;
        for(var num : nums){
            if(num < 10) continue;
            else if(num < 1_00) count++;
            else if(num < 10_00) continue;
            else if(num < 1_00_00) count++;
            else if(num == 10_00_00) count++;
        }

        return count;
    }
}
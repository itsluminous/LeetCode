public class Solution {
    public int SumFourDivisors(int[] nums) {
        var ans = 0;
        foreach(var num in nums){
            var div = 0;
            for(var i=2; i <= Math.Sqrt(num); i++){
                if(num % i == 0)
                    if(div == 0) div = i;   // no other divisor
                else{
                    // if number has more than one divisor, then it will have more than 4 total divisors
                    // because num itself + 1 + prev_div + num / prev_div is already 4
                    div = 0;
                    break;
                }
            }
            
            if(div > 0 && div != num / div) // div and num/div same means it is total 3 divisors
                ans += num + 1 + div + num / div;
        }

        return ans;
    }
}
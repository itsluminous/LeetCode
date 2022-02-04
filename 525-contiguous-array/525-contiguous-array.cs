// Using Dictionary - O(n)
// for every 0 we get, we will do count--, and for 1 we do count++
public class Solution {
    public int FindMaxLength(int[] nums) {
        int n = nums.Length, max = 0, count = 0;
        var dict = new Dictionary<int,int>();
        // before starting loop, count is 0. Hence, dict[0] is a non existing index
        dict[count] = -1;
        
        for(var i=0; i<n; i++){
            if(nums[i] == 0) count--;
            else count++;
            
            // if we encountered this count earlier, then from that idx till current, we have equal 0 & 1
            if(dict.ContainsKey(count))
                max = Math.Max(max, i-dict[count]);
            else
                dict[count] = i;
        }
        return max;
    }
}

// TLE - O(n^2)
public class Solution1 {
    public int FindMaxLength(int[] nums) {
        int n = nums.Length, max = 0;
        for(var i=0; i<n; i++){
            int zeroes = 0, ones = 0;
            for(var j=i; j<n; j++){
                if(nums[j] == 0) zeroes++;
                else ones++;
                
                if(zeroes == ones)
                    max = Math.Max(max, j-i+1);
            }
        }
        return max;
    }
}
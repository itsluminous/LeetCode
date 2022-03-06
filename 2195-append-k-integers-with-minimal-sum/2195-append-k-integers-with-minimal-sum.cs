// Accepted : sum first k numbers, then remove all existing nums and add replacement nums
public class Solution {
    public long MinimalKSum(int[] nums, int k) {
        long n = k, sum = n * (n+1) / 2;
        Array.Sort(nums);
        var hs = new HashSet<int>();    // using hashset so that we process each number only once
        
        foreach(var num in nums){
            if(num > n) break;
            
            if(hs.Add(num)){
                n++;
                sum -= num;
                sum += n;
            }
        }
        
        return sum;
    }
}

// cases with k < nums.Length failing :  sum all nums, sum all k, subtract sum of nums from sum of k
public class Solution2 {
    public long MinimalKSum(int[] nums, int k) {
        var hs = new HashSet<int>();
        long sum = 0;
        long count = 0;
        foreach(var num in nums){
            if(hs.Add(num)){
                
                sum += num;
                count++;
            }
        }
        
        long n = k+count;
        long totSum = n * (n+1) / 2;
        
        return totSum - sum;
    }
}

// Some test cases failing : keep adding numbers till max of nums, then add remaining numbers
public class Solution1 {
    public long MinimalKSum(int[] nums, int k) {
        Array.Sort(nums);
        long sum = 0;
        int idx = 0, count = 0, i = 1;
        
        while(count < k && idx < nums.Length){
            if(idx > 0 && nums[idx] == nums[idx-1]){
                idx++;
                continue;
            }
            
            if(nums[idx] == i)
                idx++;
            else{
                sum += i;
                count++;
            }
            
            i++;
        }
        
        if(count != k){
            var n = k-count;
            var a = i;
            sum += ( n/2 * (2*a + (n-1)) );
        }
        
        return sum;
    }
}
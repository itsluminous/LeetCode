// O(n * sqrt(k))
// It can be shown that if n1 * n2 % k == 0, then gcd(n1, k) * gcd(n2, k) % k == 0
// We will use this intution to solve this problem
public class Solution {
    public long CountPairs(int[] nums, int k) {
        long count = 0;
        var gcdDict = new Dictionary<int,int>();    // count occurence of each gcd
        
        foreach(var num in nums){
            var currGcd = FindGcd(num, k);
            foreach(var gcdKey in gcdDict.Keys){
                if((long)currGcd * gcdKey % k == 0)
                    count += gcdDict[gcdKey];
            }
            
            if(!gcdDict.ContainsKey(currGcd)) gcdDict[currGcd] = 0;
            gcdDict[currGcd]++;
        }
        
        return count;
    }
    
    private int FindGcd(int a, int b){
        while (a != 0 && b != 0){
            if (a > b) a %= b;
            else b %= a;
        }
        return a | b;
    }
}

// TLE - Brute Force
public class Solution1 {
    public long CoutPairs(int[] nums, int k) {
        int n = nums.Length, count = 0;
        for(var i=0; i<n; i++){
            for(var j=i+1; j<n; j++){
                double prod = nums[i]*nums[j];
                if(prod % k == 0)
                    count++;
            }
        }
        
        return count;
    }
}
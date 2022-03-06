public class Solution {
    public IList<int> ReplaceNonCoprimes(int[] nums) {
        var result = new List<int>();
        
        foreach(var num in nums){
            var curr = num;
            do{
                var prev = result.Count == 0 ? 1 : result[result.Count-1];
                var gcd = GCD(prev, curr);
                if(gcd == 1) break; // co-prime
                
                result.RemoveAt(result.Count - 1);
                curr = LCM(curr, prev, gcd);
            } while(true);  // break out when gcd == 1, i.e. coprime numbers found
            
            result.Add(curr);
        }
        
        return result;
    }
    
    private int GCD(int a, int b) {
        return b > 0 ? GCD(b, a % b) : a;
    }

    // LCM(a,b) * GCD(a,b) = a * b therefore LCM(a,b) = (a * b) / GCD(a,b).
    private int LCM(int a, int b, int gcd) => a * (b / gcd);
}

// Accepted
public class Solution1 {
    public IList<int> ReplaceNonCoprimes(int[] nums) {
        var result = new List<int>();
        result.Add(nums[0]);
        
        for(var i=1; i<nums.Length; i++){
            var prev = result[result.Count-1];
            var curr = nums[i];
            var gcd = GCD(prev, curr);
            if(gcd > 1){
                var lcm = LCM(prev, curr, gcd);
                result[result.Count-1] = lcm;
                CheckLastTwoInList(result);
            }
            else{
                result.Add(curr);
            }
        }
        
        return result;
    }
    
    private void CheckLastTwoInList(List<int> result){
        if(result.Count <= 1) return;
        
        var prev = result[result.Count-1];
        var curr = result[result.Count-2];
        var gcd = GCD(prev, curr);
        
        if(gcd > 1){
            result.RemoveAt(result.Count - 1);
            var lcm = LCM(prev, curr, gcd);
            result[result.Count-1] = lcm;
            CheckLastTwoInList(result);
        }
    }
    
    private int GCD(int a, int b){
        while (a != 0 && b != 0){
            if (a > b) a %= b;
            else b %= a;
        }

        return a | b;
    }

    // LCM(a,b) * GCD(a,b) = a * b therefore LCM(a,b) = (a * b) / GCD(a,b).
    private int LCM(int a, int b, int gcd) => a * b / gcd;
}
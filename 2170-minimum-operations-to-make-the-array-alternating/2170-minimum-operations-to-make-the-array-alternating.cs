public class Solution {
    public int MinimumOperations(int[] nums) {
        var n = nums.Length;
        if(n <= 1) return 0;
        
        Dictionary<int,int> dictOdd = new Dictionary<int,int>(), dictEven = new Dictionary<int,int>();
        int oddMax = nums[1], evenMax = nums[0];
        
        // make hasmap with freq of each number & also save what is max number
        for(var i=0; i<n; i++){
            if(i%2 == 0){
                if(!dictEven.ContainsKey(nums[i])) dictEven[nums[i]] = 0;
                dictEven[nums[i]]++;
                if(dictEven[nums[i]] > dictEven[evenMax]) evenMax = nums[i];
            }
            else{
                if(!dictOdd.ContainsKey(nums[i])) dictOdd[nums[i]] = 0;
                dictOdd[nums[i]]++;
                if(dictOdd[nums[i]] > dictOdd[oddMax]) oddMax = nums[i];
            }
        }
        
        int evenCount = n/2, oddCount = n/2;
        if(n%2 == 1) evenCount++;
        
        // if both even and odd max are same, and both have just one element, then...
        if(oddMax == evenMax && dictOdd.Count == 1 && dictEven.Count == 1)
            if(dictOdd[oddMax] < dictEven[evenMax]) return oddCount + evenCount - dictEven[evenMax];
            else return evenCount + oddCount - dictOdd[oddMax];
            
        // if both even and odd max are same, amd one of them has more than 1 val, then find 2nd max
        if(oddMax == evenMax && dictEven[evenMax] > dictOdd[oddMax] && dictOdd.Count > 1){
            oddMax = -1;
            foreach(var k in dictOdd.Keys){
                if(k != evenMax && (oddMax == -1 || dictOdd[oddMax] < dictOdd[k]))
                    oddMax = k;
            }
        }
        else if(oddMax == evenMax && dictEven.Count > 1){
            evenMax = -1;
            foreach(var k in dictEven.Keys){
                if(k != oddMax && (evenMax == -1 || dictEven[evenMax] < dictEven[k]))
                    evenMax = k;
            }
        }
        
        // return appropriate result
        if(evenMax == -1) return evenCount + oddCount - dictOdd[oddMax];
        else if (oddMax == -1) return oddCount + evenCount - dictEven[evenMax];
            
        return evenCount - dictEven[evenMax] + oddCount - dictOdd[oddMax];
    }
}
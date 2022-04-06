public class Solution {
    public int ThreeSumMulti(int[] arr, int target) {
        int MOD  = 1_000_000_007, n = arr.Length;
        long ans = 0;
        
        Array.Sort(arr);
        // for each number in array, find twoSum
        for(var i=0; i<n; i++){
            var newTarget = target - arr[i];
            int l=i+1, r=n-1;
            
            while(l < r){
                var curr = arr[l] + arr[r];
                if(curr < newTarget)
                    l++;
                else if(curr > newTarget)
                    r--;
                else if(arr[l] != arr[r]){
                    // if numbers are not same, we need to count total occurences of those numbers
                    int leftCount = 1, rightCount = 1;
                    while(l+1 < r && arr[l+1] == arr[l]){
                        l++;
                        leftCount++;
                    }
                    while(r-1 > l && arr[r-1] == arr[r]){
                        r--;
                        rightCount++;
                    }
                    
                    ans += leftCount*rightCount;
                    ans %= MOD;
                    
                    l++;
                    r--;
                }
                else{
                    // when arr[l] + arr[r] == newTarget and both l & r are same
                    var repeatations = r-l+1;
                    ans += (repeatations * (repeatations-1))/ 2;    // if repeatation = 3, then 3, for 4 its 6, for 5 its 10.....
                    ans %= MOD;
                    break;      // if both are same then there is nothing left between them
                }
            }
        }
        
        return Convert.ToInt32(ans);
    }
}
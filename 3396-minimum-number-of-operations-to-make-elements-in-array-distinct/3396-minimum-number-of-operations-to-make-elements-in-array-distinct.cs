// O(n) - reverse traversal
public class Solution {
    public int MinimumOperations(int[] nums) {
        var freq = new int[101];
        for(var i=nums.Length-1; i>=0; i--){
            var num = nums[i];
            freq[num]++;

            // when we find first duplicate, delete everything till this point
            if(freq[num] == 2)
                return (i + 3) / 3;
        }
        return 0;   // in case of no duplicates
    }
}


// Accepted - O(n) - 2 pointer
public class Solution2p {
    public int MinimumOperations(int[] nums) {
        var freq = new int[101];
        int ops = 0, duplicates = 0;    // duplicates = how many nums b/w l & r are duplicate

        for(int l=0, r=0; r < nums.Length; r+= 3){
            duplicates += CountThree(nums, freq, r);        // add up freq of next 3 numbers
            while(duplicates > 0){                          // till there are duplicates
                duplicates -= RemoveThree(nums, freq, l);   // remove first 3, and reduce freq
                ops++;
                l += 3;
            }
        }

        return ops;
    }

    private int CountThree(int[] nums, int[] freq, int idx){
        var duplicates = 0;
        for(var i=idx; i < idx+3 && i < nums.Length; i++){
            var num = nums[i];
            freq[num]++;
            if(freq[num] == 2) duplicates++;
        }
        return duplicates;
    }

    private int RemoveThree(int[] nums, int[] freq, int idx){
        var removed = 0;
        for(var i=idx; i < idx+3 && i < nums.Length; i++){
            var num = nums[i];
            freq[num]--;
            if(freq[num] == 1) removed++;
        }
        return removed;
    }
}
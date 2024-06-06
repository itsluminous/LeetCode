// by sorting
public class Solution {
    public bool IsPossibleDivide(int[] nums, int k) {
        if (nums.Length % k != 0) return false;

        // count freq of each number
        Array.Sort(nums);
        var freq = new Dictionary<int, int>();
        foreach (var num in nums) {
            if (freq.ContainsKey(num)) freq[num]++;
            else freq[num] = 1;
        }
        
        // try to make groups of k
        foreach (var num in nums) {
            if (freq[num] == 0) continue;

            for(var hand = num; hand < num+k; hand++){
                if(!freq.ContainsKey(hand) || freq[hand] == 0) return false;
                freq[hand]--;
            }
        }
        return true;
    }
}

// Accepted - using dictionary
public class SolutionDict {
    public bool IsPossibleDivide(int[] nums, int k) {
        var len = nums.Length;
        if(len % k != 0) return false;

        // count freq of each number, sorted by key asc
        var freq = new SortedDictionary<int, int>();
        foreach(var num in nums)
            if(!freq.TryAdd(num, 1))
                freq[num]++;

        // try to make groups of k
        while(freq.Count > 0){
            var smallest = freq.First().Key;
            for(var hand = smallest; hand < smallest+k; hand++){
                if(!freq.ContainsKey(hand)) return false;
                
                var val = freq[hand];
                if(val == 1) freq.Remove(hand);
                else freq[hand] = val - 1;
            }
        }
        
        return true;
    }
}
public class Solution {
    List<IList<int>> result = new List<IList<int>>();
    
    public IList<IList<int>> PermuteUnique(int[] nums) {
        // counter to count number of occurrences of each digit
        var counter = new Dictionary<int, int>();
        foreach(var num in nums){
            if(counter.ContainsKey(num)) counter[num]++;
            else counter[num] = 1;
        }
        
        // start backtracking to explore all permutations
        Backtrack(nums.Length, counter, new List<int>());
        return result;
    }
    
    private void Backtrack(int len, Dictionary<int, int> counter, List<int> curr){
        // if current list has same length as nums, then we have a valid permutation
        if(curr.Count == len){
            result.Add(new List<int>(curr));
            return;
        }
        
        // we iterate on keys (and not original array) to avoid duplicates
        foreach(var num in counter.Keys){
            var count = counter[num];
            if(count == 0) continue;    // this number cannot be added to output
            
            // Backtracking logic
            curr.Add(num);
            counter[num]--;
            Backtrack(len, counter, curr);
            counter[num]++;
            curr.RemoveAt(curr.Count-1);
        }
    }
}
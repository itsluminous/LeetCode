// log(k) - use AI to understand why this works
public class Solution {
    public char KthCharacter(int k) {
        // we just need to shift 'a' by count of number of 1s in k-1
        var ones = BitOperations.PopCount((uint)(k-1));
        return (char)('a' + ones);
    }
}

// accepted - O(k)
public class SolutionLinear {
    public char KthCharacter(int k) {
        var chars = new List<char>();
        chars.Add('a');

        while(chars.Count < k){
            var len = chars.Count;
            for(var i=0; i<len && chars.Count < k; i++)
                chars.Add((char)(chars[i] + 1));
        }

        return chars[^1];
    }
}
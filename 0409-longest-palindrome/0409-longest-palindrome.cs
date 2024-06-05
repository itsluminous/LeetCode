// same idea as hashmap
// whenever a char is inserted again, then it is automatically even, so we Remove it
class Solution {
    public int LongestPalindrome(string s) {
        var evenCount = 0;
        var chars = new HashSet<char>();

        foreach(var ch in s){
            if(!chars.Add(ch)){
                chars.Remove(ch);
                evenCount++;
            }
        }

        evenCount *= 2;
        if(chars.Count > 0) return evenCount + 1;
        return evenCount; 
    }
}

// accepted - using hash map
class SolutionHM {
    public int LongestPalindrome(string s) {
        var oddCount = 0;
        var freq = new Dictionary<char, int>();

        foreach(var ch in s){
            if(freq.ContainsKey(ch)) freq[ch]++;
            else freq[ch] = 1;
            if(freq[ch] % 2 == 1) oddCount++;
            else oddCount--;
        }

        if(oddCount > 1)    // we can have at max 1 odd in palindrome
            return s.Length - oddCount + 1;
        return s.Length;
    }
}
// same idea as hashmap
// whenever a char is inserted again, then it is automatically even, so we remove it
class Solution {
    public int longestPalindrome(String s) {
        var evenCount = 0;
        var chars = new HashSet<Character>();

        for(var ch : s.toCharArray()){
            if(!chars.add(ch)){
                chars.remove(ch);
                evenCount++;
            }
        }

        evenCount *= 2;
        if(!chars.isEmpty()) return evenCount + 1;
        return evenCount; 
    }
}

// accepted - using hash map
class SolutionHM {
    public int longestPalindrome(String s) {
        var oddCount = 0;
        var freq = new HashMap<Character, Integer>();

        for(var ch : s.toCharArray()){
            freq.put(ch, freq.getOrDefault(ch, 0) + 1);
            if(freq.get(ch) % 2 == 1) oddCount++;
            else oddCount--;
        }

        if(oddCount > 1)    // we can have at max 1 odd in palindrome
            return s.length() - oddCount + 1;
        return s.length();
    }
}
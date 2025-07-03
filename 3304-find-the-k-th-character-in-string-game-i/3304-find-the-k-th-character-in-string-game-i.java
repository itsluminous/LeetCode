// log(k) - use AI to understand why this works
class Solution {
    public char kthCharacter(int k) {
        // we just need to shift 'a' by count of number of 1s in k-1
        var ones = Integer.bitCount(k-1);
        return (char)('a' + ones);
    }
}

// accepted - O(k)
class SolutionLinear {
    public char kthCharacter(int k) {
        var chars = new ArrayList<Character>();
        chars.add('a');

        while(chars.size() < k){
            var len = chars.size();
            for(var i=0; i<len && chars.size() < k; i++)
                chars.add((char)(chars.get(i) + 1));
        }

        return chars.get(chars.size() - 1);
    }
}
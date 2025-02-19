class Solution {
    public String getHappyString(int n, int k) {
        var maxPossible = 3 * Math.pow(2, n-1);
        if(maxPossible < k) return "";

        // map to find unused char based on prev value
        Map<Character, String> lookup = Map.of('z', "abc", 'a', "bc", 'b', "ac", 'c', "ab");

        var ans = new StringBuilder();
        var prev = 'z';

        for(var i=1; ans.length() < n; i++){
            var mul = (int)Math.pow(2, n-i);
            var q = (k - 1) / mul;      // because k is 1-indexed (1st happy string = 0th in list)
            k = (k - 1) % mul + 1;      // adding 1 to keep k as 1-indexed
            
            var curr = lookup.get(prev).charAt(q);
            ans.append(curr);
            prev = curr;
        }
            
        return ans.toString();
    }
}
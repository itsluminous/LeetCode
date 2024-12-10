class Solution {
    public int maximumLength(String s) {
        // frequency of each string of a len with a repeated char
        var count = new HashMap<Pair<Character, Integer>, Integer>();
        int n = s.length(), len = 0;

        for(var start=0; start<n; start++){
            var ch = s.charAt(start);
            len = 0;
            for(var end=start; end < n; end++){
                if(ch == s.charAt(end)){
                    len++;
                    var key = new Pair<>(ch, len);
                    count.put(key, count.getOrDefault(key, 0) + 1);
                }
                else
                    break;
            }
        }

        var ans = 0;
        for(var entry : count.entrySet()){
            var ln = entry.getKey().getValue();
            if(entry.getValue() >= 3 && ln > ans)
                ans = ln;
        }

        return ans == 0 ? -1 : ans;
    }
}
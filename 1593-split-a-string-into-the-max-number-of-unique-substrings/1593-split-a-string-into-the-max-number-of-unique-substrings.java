class Solution {
    int count = 0;

    public int maxUniqueSplit(String s) {
        split(s, new HashSet<String>(s.length()), 0);
        return count;
    }

    private void split(String s, HashSet<String> set, int start){
        if(start == s.length()) {
            count = Math.max(count, set.size());
            return;
        }

        for(var end=start+1; end<=s.length(); end++){
            var substr = s.substring(start, end);
            if(!set.add(substr)) continue;
            split(s, set, end);
            set.remove(substr);
        }
    }
}
class Solution {
    public List<Integer> partitionLabels(String s) {
        var n = s.length();

        // store last occurence of a character
        var last = new int[26];
        for(var i=0; i<n; i++){
            var idx = s.charAt(i) - 'a';
            last[idx] = i;
        }

        var ans = new ArrayList<Integer>();
        int start = 0, end = 0;
        for(var i=0; i<n; i++){
            var idx = s.charAt(i) - 'a';
            if(end < i) {
                ans.add(end - start + 1);
                start = i;
            }
            end = Math.max(end, last[idx]);    
        }

        ans.add(end - start + 1);
        return ans;
    }
}
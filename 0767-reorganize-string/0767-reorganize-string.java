class Solution {
    public String reorganizeString(String s) {
        var n = s.length();
        var half = (n+1)/2;
        
        // count freq of each char
        var freq = new int[26];
        for(var ch : s.toCharArray()){
            freq[ch-'a']++;
            if(freq[ch-'a'] > half) return "";
        }

        // arrange these chars in desc order based on freq count
        var list = new ArrayList<int[]>();
        for(var i=0; i<26; i++){
            if(freq[i] == 0) continue;
            list.add(new int[]{i, freq[i]});
        }
        // list.sort((l1, l2) -> Integer.compare(l2[1], l1[1]));    // this also works
        list.sort((l1, l2) -> l2[1]-l1[1]);

        // now build the ans
        var ans = new char[n];
        var idx = 0;
        for(var item : list){
            var ch = (char)('a' + item[0]);
            var frq = item[1];

            for(var i=0; i<frq; i++){
                ans[idx] = ch;
                idx += 2;
                if(idx >= n) idx = 1;
            }
        }

        return new String(ans);
    }
}
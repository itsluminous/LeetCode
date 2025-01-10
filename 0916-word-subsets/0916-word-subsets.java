class Solution {
    public List<String> wordSubsets(String[] words1, String[] words2) {
        // find max freq of each char from words2
        var freq = new int[26];
        for(var word : words2){
            var map = new HashMap<Character, Integer>();
            for(var ch : word.toCharArray()){
                map.put(ch, map.getOrDefault(ch, 0) + 1);
                
                // update the freq of curr char
                freq[ch-'a'] = Math.max(freq[ch-'a'], map.get(ch));
            }
        }

        // find words which satisfy all conditions of freq
        var ans = new ArrayList<String>();
        for(var word : words1){
            var frq = freq.clone();
            for(var ch : word.toCharArray()){
                if(frq[ch-'a'] == 0) continue;  // this char is not needed
                frq[ch-'a']--;
            }

            // check if all chars were covered
            if(Arrays.stream(frq).sum() == 0) ans.add(word);
        }

        return ans;
    }
}
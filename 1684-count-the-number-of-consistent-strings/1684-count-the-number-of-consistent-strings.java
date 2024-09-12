class Solution {
    public int countConsistentStrings(String allowed, String[] words) {
        var letters = new boolean[26];
        for(var ch : allowed.toCharArray())
            letters[ch - 'a'] = true;
        
        var consistent = 0;
        for(var word : words){
            consistent++;
            for(var ch : word.toCharArray()){
                if(!letters[ch - 'a']){
                    consistent--;
                    break;
                }
            }
        }

        return consistent;
    }
}
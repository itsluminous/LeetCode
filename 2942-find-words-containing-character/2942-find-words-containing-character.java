class Solution {
    public List<Integer> findWordsContaining(String[] words, char x) {
        var ans = new ArrayList<Integer>();
        for(var i=0; i<words.length; i++)
            if(words[i].contains(String.valueOf(x)))
                ans.add(i);
        return ans;
    }
}
class Solution {
    public String[] uncommonFromSentences(String s1, String s2) {
        var s1sets = makeSets(s1);
        var s2sets = makeSets(s2);

        s1sets.once.removeAll(s2sets.words);
        s2sets.once.removeAll(s1sets.words);
        s1sets.once.addAll(s2sets.once);
        
        return s1sets.once.toArray(new String[0]);
    }

    private Sets makeSets(String s){
        Set<String> words = new HashSet<>(), once = new HashSet<>();

        for(var word : s.split(" "))
            if(once.contains(word))
                once.remove(word);
            else if(words.add(word))
                once.add(word);

        return new Sets(words, once);
    }

    private static class Sets {
        Set<String> words;
        Set<String> once;

        Sets(Set<String> words, Set<String> once) {
            this.words = words;
            this.once = once;
        }
    }
}
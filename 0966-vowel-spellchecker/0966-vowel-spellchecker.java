class Solution {
    public String[] spellchecker(String[] wordlist, String[] queries) {
        var words = new HashSet<String>(Arrays.asList(wordlist));
        var capital = new HashMap<String, String>();    // normalise case
        var vowel = new HashMap<String, String>();      // normalise vowels

        for(var word : wordlist){
            String upper = word.toUpperCase(), devowel = upper.replaceAll("[AEIOU]", "#");
            capital.putIfAbsent(upper, word);
            vowel.putIfAbsent(devowel, word);
        }

        for(var i=0; i<queries.length; i++){
            var query = queries[i];
            if(words.contains(query)) continue; // no change needed
            String upper = query.toUpperCase(), devowel = upper.replaceAll("[AEIOU]", "#");
            if(capital.containsKey(upper))
                queries[i] = capital.get(upper);
            else if(vowel.containsKey(devowel))
                queries[i] = vowel.get(devowel);
            else
                queries[i] = "";
        }

        return queries;
    }
}
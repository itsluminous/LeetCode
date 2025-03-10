class Solution {
    public long countOfSubstrings(String word, int k) {
        var n = word.length();
        Map<Character, Integer> vowels = new HashMap<>();
        for (var c : "aeiou".toCharArray()) vowels.put(c, 0);
        int v = 0, c = 0;   // count of distinct vowels and count of consonants
        long ans = 0; 

        // find pos of first consonant on right of each index
        var nextConsonant = new int[n];
        var lastConsonant = n;
        for(var i=n-1; i>=0; i--){
            nextConsonant[i] = lastConsonant;
            if(!isVowel(word.charAt(i))) lastConsonant = i;
        }

        for(int l=0, r=0; r < n; r++){
            // expand window on right
            var ch = word.charAt(r);
            if(isVowel(ch)){
                vowels.put(ch, vowels.get(ch) + 1);
                if(vowels.get(ch) == 1) v++;    // found new vowel
            }
            else c++;

            // shrink window on left
            while(c > k){
                var ch1 = word.charAt(l++);
                if(isVowel(ch1)){
                    vowels.put(ch1, vowels.get(ch1) - 1);
                    if(vowels.get(ch1) == 0) v--;    // lost a vowel
                }
                else c--;
            }

            // count matching strings
            while(v == 5 && c == k){
                ans += nextConsonant[r] - r;
                var ch1 = word.charAt(l++);
                if(isVowel(ch1)){
                    vowels.put(ch1, vowels.get(ch1) - 1);
                    if(vowels.get(ch1) == 0) v--;    // lost a vowel
                }
                else c--;
            }
        }

        return ans;
    }

    private boolean isVowel(char ch){
        return (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u');
    }
}
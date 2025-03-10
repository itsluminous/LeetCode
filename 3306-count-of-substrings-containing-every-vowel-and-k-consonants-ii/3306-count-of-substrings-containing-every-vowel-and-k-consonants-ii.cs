public class Solution {
    public long CountOfSubstrings(string word, int k) {
        var n = word.Length;
        var vowels = new Dictionary<char, int>{{'a', 0}, {'e', 0}, {'i', 0}, {'o', 0}, {'u', 0}};
        int v = 0, c = 0;   // count of distinct vowels and count of consonants
        long ans = 0; 

        // find pos of first consonant on right of each index
        var nextConsonant = new int[n];
        var lastConsonant = n;
        for(var i=n-1; i>=0; i--){
            nextConsonant[i] = lastConsonant;
            if(!IsVowel(word[i])) lastConsonant = i;
        }

        for(int l=0, r=0; r < n; r++){
            // expand window on right
            var ch = word[r];
            if(IsVowel(ch)){
                vowels[ch]++;
                if(vowels[ch] == 1) v++;    // found new vowel
            }
            else c++;

            // shrink window on left
            while(c > k){
                var ch1 = word[l++];
                if(IsVowel(ch1)){
                    vowels[ch1]--;
                    if(vowels[ch1] == 0) v--;    // lost a vowel
                }
                else  c--;
            }

            // count matching strings
            while(v == 5 && c == k){
                ans += nextConsonant[r] - r;
                var ch1 = word[l++];
                if(IsVowel(ch1)){
                    vowels[ch1]--;
                    if(vowels[ch1] == 0) v--;    // lost a vowel
                }
                else  c--;
            }
        }

        return ans;
    }

    private bool IsVowel(char ch){
        return (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u');
    }
}
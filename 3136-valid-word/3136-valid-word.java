class Solution {
    public boolean isValid(String word) {
        if(word.length() < 3) return false;
        
        Set<Character> vowels = new HashSet<>();
        for (char c : "aeiouAEIOU".toCharArray()) vowels.add(c);

        boolean vowel = false, consonant = false;
        for(var ch : word.toCharArray()){
            if(ch < '0' || (ch > '9' && ch < 'A') || (ch > 'Z' && ch < 'a') || ch > 'z') return false;
            if(vowels.contains(ch)) vowel = true;
            else if(ch > '9') consonant = true;
        }
        
        return vowel && consonant;
    }
}
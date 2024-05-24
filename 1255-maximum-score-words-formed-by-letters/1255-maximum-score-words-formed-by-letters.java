class Solution {
    public int maxScoreWords(String[] words, char[] letters, int[] score) {
        var freq = new int[26]; // frequency of each char in letters
        for(var ch : letters) freq[ch-'a']++;

        return wordScore(words, freq, score, 0);
    }

    private int wordScore(String[] words, int[] freq, int[] score, int wIdx){
        if(wIdx == words.length) return 0;
        var origFreq = freq.clone();

        var notMakeCurrWord = wordScore(words, freq, score, wIdx+1);
        freq = origFreq;
        
        var makeCurrWord = makeWord(words, freq, score, wIdx);
        if(makeCurrWord != -1)
            makeCurrWord += wordScore(words, freq, score, wIdx+1);
        freq = origFreq;
        
        var maxScore = Math.max(notMakeCurrWord, makeCurrWord);
        return maxScore == -1 ? 0 : maxScore;
    }

    // if a word can be formed, then return its score and modify freq array
    private int makeWord(String[] words, int[] freq, int[] score, int wIdx) {
        var totalScore = 0;
        for(var ch : words[wIdx].toCharArray()){
            if(freq[ch-'a'] == 0) return -1;
            freq[ch-'a']--;
            totalScore += score[ch-'a'];
        }

        return totalScore;
    }
}
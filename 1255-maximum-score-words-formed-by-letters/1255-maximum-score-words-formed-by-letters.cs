public class Solution {
    public int MaxScoreWords(string[] words, char[] letters, int[] score) {
        var freq = new int[26]; // frequency of each char in letters
        foreach(var ch in letters) freq[ch-'a']++;

        return WordScore(words, freq, score, 0);
    }

    private int WordScore(string[] words, int[] freq, int[] score, int wIdx){
        if(wIdx == words.Length) return 0;
        var origFreq = (int[])freq.Clone();

        var notMakeCurrWord = WordScore(words, freq, score, wIdx+1);
        freq = origFreq;
        
        var makeCurrWord = MakeWord(words, freq, score, wIdx);
        if(makeCurrWord != -1)
            makeCurrWord += WordScore(words, freq, score, wIdx+1);
        freq = origFreq;
        
        var maxScore = Math.Max(notMakeCurrWord, makeCurrWord);
        return maxScore == -1 ? 0 : maxScore;
    }

    // if a word can be formed, then return its score and modify freq array
    private int MakeWord(string[] words, int[] freq, int[] score, int wIdx) {
        var totalScore = 0;
        foreach(var ch in words[wIdx]){
            if(freq[ch-'a'] == 0)
                return -1;
            freq[ch-'a']--;
            totalScore += score[ch-'a'];
        }

        return totalScore;
    }
}
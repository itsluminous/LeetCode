public class Solution {
    public int UniqueMorseRepresentations(string[] words) {
        var morse = new []{".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
        var set = new HashSet<string>();
        foreach(var word in words){
            var trans = new StringBuilder();
            foreach(var ch in word)
                trans.Append(morse[ch-'a']);
            set.Add(trans.ToString());
        }
        return set.Count;
    }
}
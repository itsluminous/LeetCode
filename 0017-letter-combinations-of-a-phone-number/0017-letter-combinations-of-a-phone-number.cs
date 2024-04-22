public class Solution {
    IList<string> combination;
    public IList<string> LetterCombinations(string digits) {
        var keypad = new []{"", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
        combination = new List<string>();
        LetterCombinations(keypad, digits, 0, new StringBuilder());
        return combination;
    }

    public void LetterCombinations(string[] keypad, string digits, int idx, StringBuilder sb) {
        if(idx == digits.Length) return;
        foreach(var ch in keypad[digits[idx]-'0']){
            sb.Append(ch);
            if(idx == digits.Length-1) combination.Add(sb.ToString());
            else LetterCombinations(keypad, digits, idx+1, sb);
            sb.Length--;
        }
    }
}
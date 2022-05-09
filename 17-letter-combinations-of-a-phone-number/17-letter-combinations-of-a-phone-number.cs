public class Solution {
    string[] keypad = new []{"-", "-", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
    List<string> result = new List<string>();
    
    public IList<string> LetterCombinations(string digits) {
        if(digits.Length < 1) return result;
        
        LetterCombinations(digits, 0, new StringBuilder());
        return result;
    }
    
    private void LetterCombinations(string digits, int idx, StringBuilder sb){
        // if length is same as input, we have created a valid string, add it to result
        if(idx == digits.Length){
            result.Add(sb.ToString());
            return;
        }
        
        var digit = digits[idx] - '0';  // digits will give us char, we want int value
        foreach(var ch in keypad[digit]){
            sb.Append(ch);
            LetterCombinations(digits, idx+1, sb);
            sb.Length--;
        }
    }
}
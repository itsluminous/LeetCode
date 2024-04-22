public class Solution {
    List<String> combination;
    public List<String> letterCombinations(String digits) {
        var keypad = new String[]{"", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
        combination = new ArrayList<String>();
        letterCombinations(keypad, digits, 0, new StringBuilder());
        return combination;
    }

    public void letterCombinations(String[] keypad, String digits, int idx, StringBuilder sb) {
        if(idx == digits.length()) return;
        for(var ch : keypad[digits.charAt(idx)-'0'].toCharArray()){
            sb.append(ch);
            if(idx == digits.length()-1) combination.add(sb.toString());
            else letterCombinations(keypad, digits, idx+1, sb);
            sb.setLength(sb.length() -1);
        }
    }
}
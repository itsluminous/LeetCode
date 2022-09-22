public class Solution {
    public string ReverseWords(string s) {
        var words = s.Split(" ");
        for(var i = 0; i<words.Length; i++){
            var charArray = words[i].ToCharArray();
            Array.Reverse(charArray);
            words[i] =  new string(charArray);
        }
        return string.Join(" ", words);
    }
}
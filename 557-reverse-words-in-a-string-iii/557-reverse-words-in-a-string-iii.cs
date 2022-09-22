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

// Accepted
public class Solution1 {
    public string ReverseWords(string s) {
        var wEnd = 0;
        var wStart = 0;
        var sb = new StringBuilder();
        
        while(wEnd < s.Length){
            if(s[wEnd] == ' '){
                sb.Append(ReverseWord(s.Substring(wStart, wEnd-wStart).ToCharArray()));
                sb.Append(' ');
                wStart = wEnd+1;
            }
            wEnd++;
        }
        
        sb.Append(ReverseWord(s.Substring(wStart, wEnd-wStart).ToCharArray()));
        return sb.ToString();
    }
    
    private string ReverseWord(char[] s){
        for(int start=0, end=s.Length-1;start < end;start++,end--){
            var temp = s[start];
            s[start] = s[end];
            s[end] = temp;
        }
        return new string(s);
    }
}
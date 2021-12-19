public class Solution {
    public string DecodeString(string s) {
        var stack = new Stack<string>();
        StringBuilder str = new StringBuilder(), num = new StringBuilder();
        
        foreach(var ch in s){
            if(ch == '['){
                stack.Push(str.ToString());
                stack.Push(num.ToString());
                str = new StringBuilder();
                num = new StringBuilder();
            }
            else if(ch == ']'){
                var prevNum = int.Parse(stack.Pop());
                var prevStr = stack.Pop();
                str = DecodeString(prevStr, str.ToString(), prevNum);
            }
            else if(char.IsDigit(ch)){
                num.Append(ch);
            }
            else{   // ch is alphabet
                str.Append(ch);
            }
        }
        return str.ToString();
    }
    
    private StringBuilder DecodeString(string prevStr, string currStr, int num){
        // linq version
        return new StringBuilder(prevStr + string.Concat(Enumerable.Repeat(currStr, num)));
        
        // simplified version
        var sb = new StringBuilder(prevStr);
        for(var i=0; i<num; i++)
            sb.Append(currStr);
        
        return sb;
    }
}
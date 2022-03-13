public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        for(int i=0; i<s.Length; i++){
            if(s[i] == '(') stack.Push(')');
            else if(s[i] == '{') stack.Push('}');
            else if(s[i] == '[') stack.Push(']');
            else if(stack.Count == 0 || s[i] != stack.Pop()) return false;
        }
        
        return stack.Count == 0;
    }
}

// Accepted
public class Solution1 {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        
        foreach(var ch in s){
            if(ch == ')' || ch == '}' || ch == ']'){
                if(stack.Count == 0) return false;
                var top = stack.Pop();
                
                if(ch == ')'){
                    if(top != '(') return false;
                }
                else if(ch == '}'){
                    if(top != '{') return false;
                }
                else{
                    if(top != '[') return false;
                }
            }
            else
                stack.Push(ch);
        }
        
        return stack.Count == 0;
    }
}
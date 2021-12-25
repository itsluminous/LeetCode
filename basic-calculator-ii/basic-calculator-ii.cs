public class Solution {
    public int Calculate(string s) {
        s = s + '+';  // add any arbitrary operation at the end, so that last number is also evaluated in equation
        char operation = '+';   // by default + because we want to simply push the first number
        var num = 0;
        var stack = new Stack<int>();
        
        foreach(var ch in s){
            if(char.IsDigit(ch))
                num = num*10 + ch-'0';
            else if(ch == ' ')
                continue;
            else{
                // for plus
                if(operation == '+')
                    stack.Push(num);
                // for minus, save negative of number, so that it can be added later
                else if(operation == '-')
                    stack.Push(-num);
                // if division, do it immediately
                if(operation == '/')
                    stack.Push(stack.Pop() / num);
                // if multiplication, do it immediately
                else if(operation == '*')
                    stack.Push(stack.Pop() * num);
                num = 0;
                operation = ch;
            }
        }
        
        // pop items and calculate result
        var result = 0;
        while(stack.Count > 0){
            result += stack.Pop();
        }
        
        return result;
    }
}
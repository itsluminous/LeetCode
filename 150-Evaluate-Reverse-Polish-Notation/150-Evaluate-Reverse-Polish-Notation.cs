public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        foreach(var token in tokens){
            if(int.TryParse(token, out var n)){
                stack.Push(n);
                continue;
            }
            if(stack.Count < 2) throw new ArgumentException("Invalid polish notation");
            var num2 = stack.Pop();
            var num1 = stack.Pop();
            switch(token){
                case "+":
                    stack.Push(num1 + num2);
                    break;
                case "-":
                    stack.Push(num1 - num2);
                    break;
                case "*":
                    stack.Push(num1 * num2);
                    break;
                case "/":
                    stack.Push(num1 / num2);
                    break;
                default:
                    throw new ArgumentException("Invalid operator");
            }
        }

        return stack.Pop();
    }
}
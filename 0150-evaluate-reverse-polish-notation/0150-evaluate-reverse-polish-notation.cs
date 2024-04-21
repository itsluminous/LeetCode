public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        foreach(var str in tokens){
            if(int.TryParse(str, out var num)){
                stack.Push(num);
                continue;
            }

            var num2 = stack.Pop();
            var num1 = stack.Pop();

            if(str == "+") num1 += num2;
            else if(str == "-") num1 -= num2;
            else if(str == "*") num1 *= num2;
            else if(str == "/") num1 /= num2;

            stack.Push(num1);
        }

        return stack.Pop();
    }
}
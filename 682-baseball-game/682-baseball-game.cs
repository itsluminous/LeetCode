public class Solution {
    public int CalPoints(string[] ops) {
        var stack = new Stack<int>();
        foreach(var op in ops){
            if(op == "+"){
                var prev = stack.Pop();
                var prePrev = stack.Peek();
                
                stack.Push(prev);   // put back the number popped
                stack.Push(prev + prePrev);
            }
            else if(op == "D"){
                var prev = stack.Peek();
                stack.Push(2*prev);
            }
            else if(op == "C"){
                stack.Pop();
            }
            else{
                stack.Push(Convert.ToInt32(op));
            }
        }
        
        var result = 0;
        while(stack.Count > 0)
            result += stack.Pop();
        
        return result;
    }
}
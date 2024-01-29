public class MyQueue {

    Stack<int> stack;
    public MyQueue() {
        stack = new Stack<int>();
    }
    
    public void Push(int x) {
        var tmp = new Stack<int>();
        while(stack.Count > 0) tmp.Push(stack.Pop());
        stack.Push(x);
        while(tmp.Count > 0) stack.Push(tmp.Pop());

    }
    
    public int Pop() {
        return stack.Pop();
    }
    
    public int Peek() {
        return stack.Peek();
    }
    
    public bool Empty() {
        return stack.Count == 0;
    }
}
class MinStack {
    Stack<MinItem> stack;

    public MinStack() {
        stack = new Stack<>();
    }
    
    public void push(int val) {
        if(stack.isEmpty())
            stack.push(new MinItem(val, val));
        else{
            var minNum = Math.min(val, stack.peek().min);
            stack.push(new MinItem(val, minNum));
        }
    }
    
    public void pop() {
        stack.pop();
    }
    
    public int top() {
        return stack.peek().num;
    }
    
    public int getMin() {
        return stack.peek().min;
    }
}

class MinItem {
    int num;
    int min; 

    MinItem(int n, int m){
        num = n;
        min = m;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.push(val);
 * obj.pop();
 * int param_3 = obj.top();
 * int param_4 = obj.getMin();
 */
class CustomStack {
    Node head, tail;
    int currSize, maxSize;

    public CustomStack(int maxSize) {
        head = null;
        tail = null;
        currSize = 0;
        this.maxSize = maxSize;
    }
    
    public void push(int x) {
        if(currSize == maxSize) return;

        var node = new Node(x);
        if(head == null)
            head = tail = node;
        else{
            node.right = head;
            head.left = node;
            head = node;
        }
        currSize++;
    }
    
    public int pop() {
        if(currSize == 0) return -1;

        var val = head.val;
        if(currSize == 1)
            head = tail = null;
        else {
            head = head.right;
            head.left = null;
        }

        currSize--;
        return val;
    }
    
    public void increment(int k, int val) {
        for(var node = tail; node != null && k > 0; node = node.left, k--)
            node.val += val;
    }
}

class Node {
    int val;
    Node left, right;

    public Node(int val){
        this.val = val;
    }
}

/**
 * Your CustomStack object will be instantiated and called as such:
 * CustomStack obj = new CustomStack(maxSize);
 * obj.push(x);
 * int param_2 = obj.pop();
 * obj.increment(k,val);
 */
class MyCircularDeque {
    Node front, rear;
    int max, curr;

    public MyCircularDeque(int k) {
        front = null; rear = null;
        max = k;
    }
    
    public boolean insertFront(int value) {
        if(curr == max) return false;

        var node = new Node(value);
        if(front != null){
            node.right = front;
            front.left = node;
            front = node;
        }
        else{
            front = node;
            rear = node;
        }
        curr++;
        return true;
    }
    
    public boolean insertLast(int value) {
        if(curr == max) return false;

        var node = new Node(value);
        if(rear != null){
            node.left = rear;
            rear.right = node;
            rear = node;
        }
        else{
            front = node;
            rear = node;
        }
        curr++;
        return true;
    }
    
    public boolean deleteFront() {
        if(front == null) return false;

        if(front.right == null){
            front = null; rear = null;
        }
        else {
            front.right.left = null;
            front = front.right;
        }
        curr--;
        return true;
    }
    
    public boolean deleteLast() {
        if(rear == null) return false;

        if(rear.left == null){
            rear = null; front = null;
        }
        else {
            rear.left.right = null;
            rear = rear.left;
        }
        curr--;
        return true;
    }
    
    public int getFront() {
        if(front == null) return -1;
        return front.val;
    }
    
    public int getRear() {
        if(rear == null) return -1;
        return rear.val;
    }
    
    public boolean isEmpty() {
        return curr == 0;
    }
    
    public boolean isFull() {
        return curr == max;
    }
}

class Node {
    int val;
    Node left;
    Node right;

    public Node(int v){
        val = v;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * boolean param_1 = obj.insertFront(value);
 * boolean param_2 = obj.insertLast(value);
 * boolean param_3 = obj.deleteFront();
 * boolean param_4 = obj.deleteLast();
 * int param_5 = obj.getFront();
 * int param_6 = obj.getRear();
 * boolean param_7 = obj.isEmpty();
 * boolean param_8 = obj.isFull();
 */
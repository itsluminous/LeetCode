public class MyCircularDeque {
    Node front, rear;
    int max, curr;

    public MyCircularDeque(int k) {
        front = null; rear = null;
        max = k;
    }
    
    public bool InsertFront(int value) {
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
    
    public bool InsertLast(int value) {
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
    
    public bool DeleteFront() {
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
    
    public bool DeleteLast() {
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
    
    public int GetFront() {
        if(front == null) return -1;
        return front.val;
    }
    
    public int GetRear() {
        if(rear == null) return -1;
        return rear.val;
    }
    
    public bool IsEmpty() {
        return curr == 0;
    }
    
    public bool IsFull() {
        return curr == max;
    }
}

class Node {
    public int val;
    public Node left;
    public Node right;

    public Node(int v){
        val = v;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */
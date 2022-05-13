// Accepted - Iterative
public class Solution {
    public Node Connect(Node root) {
        var head = root;
        while(root != null){
            var tempChild = new Node(0);
            var curr = tempChild;
            while(root != null){
                if(root.left != null){
                    curr.next = root.left;
                    curr = curr.next;
                }
                if(root.right != null){
                    curr.next = root.right;
                    curr = curr.next;
                }
                root = root.next;
            }
            root = tempChild.next;
        }
        
        return head;
    }
}

/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/
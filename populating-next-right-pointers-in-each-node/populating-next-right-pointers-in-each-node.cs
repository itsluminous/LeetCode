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

// without using queue
public class Solution {
    public Node Connect(Node root) {
        var prev = root;
        Node cur = null;
        while(prev != null && prev.left != null){   // if prev.left is null, then there are no child for prev
            cur = prev;
            while(cur != null){
                cur.left.next = cur.right;
                if(cur.next != null)
                    cur.right.next = cur.next.left;
                
                cur = cur.next;
            }
            prev = prev.left;
        }
        
        return root;
    }
}

// using queue
public class Solution1 {
    public Node Connect(Node root) {
        if(root == null) return root;
        
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        
        while(queue.Count > 0){
            var curr = queue.Dequeue();
            if(curr.left != null){
                curr.left.next = curr.right;
                queue.Enqueue(curr.left);
            }
                
            if(curr.right != null) {
                if(curr.next != null) curr.right.next = curr.next.left;
                queue.Enqueue(curr.right);
            }
                
        }
        
        return root;
    }
}
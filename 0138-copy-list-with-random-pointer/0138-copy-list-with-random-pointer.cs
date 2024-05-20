public class Solution {
    public Node CopyRandomList(Node head) {
        // Make copy of all nodes - in place
        for(var itr = head; itr!= null; itr = itr.next.next){
            var node = new Node(itr.val);
            node.next = itr.next;
            itr.next = node;
        }
        
        // Assign random pointers for the copy nodes.
        for(var itr = head; itr!= null; itr = itr.next.next){
            if(itr.random != null)
                itr.next.random = itr.random.next;
        }
        
        // Split original and copy list
        Node cloneHead = new Node(-1);
        for(Node itr = head, cloneItr = cloneHead; itr!= null; itr = itr.next, cloneItr = cloneItr.next){
            cloneItr.next = itr.next;
            itr.next = itr.next.next;
        }
        
        return cloneHead.next;
    }
}

/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/
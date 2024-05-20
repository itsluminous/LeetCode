class Solution {
    public Node copyRandomList(Node head) {
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
class Node {
    int val;
    Node next;
    Node random;

    public Node(int val) {
        this.val = val;
        this.next = null;
        this.random = null;
    }
}
*/
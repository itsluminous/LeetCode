class AllOne {
    HashMap<String, Node> keyToNode;
    Node head, tail;    // head is min freq, tail is max freq

    public AllOne() {
        keyToNode = new HashMap<>();
        head = null;
        tail = null;
    }
    
    public void inc(String key) {
        if(keyToNode.containsKey(key)){
            var currNode = keyToNode.get(key);
            currNode.keys.remove(key);  // it will be promoted to next freq node
            var newNode = new Node(currNode.freq + 1, key);

            if(currNode.right == null){
                tail = newNode;
                currNode.right = newNode;
                newNode.left = currNode;
                keyToNode.put(key, newNode);
            }
            else if(currNode.right.freq == currNode.freq + 1) {
                currNode.right.keys.add(key);
                keyToNode.put(key, currNode.right);
            }
            else {
                currNode.right.left = newNode;
                newNode.right = currNode.right;
                newNode.left = currNode;
                currNode.right = newNode;
                keyToNode.put(key, newNode);
            }

            if(currNode.keys.size() == 0) removeNode(currNode);
        }
        else {
            var node = new Node(1, key);
            if(head == null)
                head = tail = node;
            else if(head.freq == 1)
                head.keys.add(key);
            else {
                node.right = head;
                head.left = node;
                head = node;
            }
            keyToNode.put(key, head);
        }
    }
    
    public void dec(String key) {
        if(!keyToNode.containsKey(key)) return;
        var currNode = keyToNode.get(key);
        currNode.keys.remove(key);  // it will be demoted to lesser freq node
        var newNode = new Node(currNode.freq - 1, key);

        if(currNode.freq == 1)
            keyToNode.remove(key);
        else if(currNode == head) {
            newNode.right = head;
            head.left = newNode;
            head = newNode;
            keyToNode.put(key, newNode);
        }
        else if(currNode.left.freq == currNode.freq - 1) {
            currNode.left.keys.add(key);
            keyToNode.put(key, currNode.left);
        }
        else {
            currNode.left.right = newNode;
            newNode.left = currNode.left;
            newNode.right = currNode;
            currNode.left = newNode;
            keyToNode.put(key, newNode);
        }

        if(currNode.keys.size() == 0) removeNode(currNode);
    }
    
    public String getMaxKey() {
        if(tail == null) return "";
        return tail.keys.iterator().next();
    }
    
    public String getMinKey() {
        if(head == null) return "";
        return head.keys.iterator().next();
    }

    private void removeNode(Node node) {
        if(node == head) {
            head = head.right;
            if(head != null) head.left = null;
        }
        else if(node == tail) {
            tail = tail.left;
            if(tail != null) tail.right = null;
        }
        else {
            node.left.right = node.right;
            node.right.left = node.left;
        }
    }
}

class Node {
    int freq;
    HashSet<String> keys;
    Node left, right;

    public Node(int freq, String key){
        this.freq = freq;
        keys = new HashSet<>();
        keys.add(key);
    }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.inc(key);
 * obj.dec(key);
 * String param_3 = obj.getMaxKey();
 * String param_4 = obj.getMinKey();
 */
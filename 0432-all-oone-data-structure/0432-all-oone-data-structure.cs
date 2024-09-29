public class AllOne {
    Dictionary<string, Node> keyToNode;
    Node head, tail;    // head is min freq, tail is max freq

    public AllOne() {
        keyToNode = new();
        head = null;
        tail = null;
    }
    
    public void Inc(string key) {
        if(keyToNode.ContainsKey(key)){
            var currNode = keyToNode[key];
            currNode.keys.Remove(key);  // it will be promoted to next freq node
            var newNode = new Node(currNode.freq + 1, key);

            if(currNode.right == null){
                tail = newNode;
                currNode.right = newNode;
                newNode.left = currNode;
                keyToNode[key] = newNode;
            }
            else if(currNode.right.freq == currNode.freq + 1) {
                currNode.right.keys.Add(key);
                keyToNode[key] = currNode.right;
            }
            else {
                currNode.right.left = newNode;
                newNode.right = currNode.right;
                newNode.left = currNode;
                currNode.right = newNode;
                keyToNode[key] = newNode;
            }

            if(currNode.keys.Count == 0) RemoveNode(currNode);
        }
        else {
            var node = new Node(1, key);
            if(head == null)
                head = tail = node;
            else if(head.freq == 1)
                head.keys.Add(key);
            else {
                node.right = head;
                head.left = node;
                head = node;
            }
            keyToNode[key] = head;
        }
    }
    
    public void Dec(string key) {
        if(!keyToNode.ContainsKey(key)) return;
        var currNode = keyToNode[key];
        currNode.keys.Remove(key);  // it will be demoted to lesser freq node
        var newNode = new Node(currNode.freq - 1, key);

        if(currNode.freq == 1)
            keyToNode.Remove(key);
        else if(currNode == head) {
            newNode.right = head;
            head.left = newNode;
            head = newNode;
            keyToNode[key] = newNode;
        }
        else if(currNode.left.freq == currNode.freq - 1) {
            currNode.left.keys.Add(key);
            keyToNode[key] = currNode.left;
        }
        else {
            currNode.left.right = newNode;
            newNode.left = currNode.left;
            newNode.right = currNode;
            currNode.left = newNode;
            keyToNode[key] = newNode;
        }

        if(currNode.keys.Count == 0) RemoveNode(currNode);
    }
    
    public string GetMaxKey() {
        if(tail == null) return "";
        return tail.keys.First();
    }
    
    public string GetMinKey() {
        if(head == null) return "";
        return head.keys.First();
    }

    private void RemoveNode(Node node) {
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
    public int freq;
    public HashSet<string> keys;
    public Node left, right;

    public Node(int freq){
        this.freq = freq;
        keys = new();
    }

    public Node(int freq, string key){
        this.freq = freq;
        keys = new();
        keys.Add(key);
    }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */
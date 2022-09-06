// BFS
public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        var result = new List<IList<int>>();
        if(root == null) return result;
        
        var q = new Queue<Node>();
        q.Enqueue(root);
        
        while(q.Count > 0){
            var len = q.Count;
            var level = new List<int>();
            
            for(var i=0; i<len; i++){
                var node = q.Dequeue();
                level.Add(node.val);
                
                if(node.children == null) continue;
                foreach(var ch in node.children) q.Enqueue(ch);
            }
            result.Add(level);
        }
        
        return result;
    }
}

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/
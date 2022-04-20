// Using stack to reduce space complexity
public class BSTIterator {

    Stack<TreeNode> parents = new Stack<TreeNode>();
    
    public BSTIterator(TreeNode root) {
        while(root != null){
            parents.Push(root);
            root = root.left;
        }
    }
    
    public int Next() {
        var curr = parents.Pop();
        // now push all nodes betwee curr, and its parent
        var node = curr.right;
        while(node != null){
            parents.Push(node);
            node = node.left;
        }
        
        return curr.val;
    }
    
    public bool HasNext() {
        return parents.Count > 0;
    }
}

// Accepted, but uses more space
public class BSTIterator1 {

    List<int> inorder = new List<int>();
    int idx = -1;
    
    public BSTIterator1(TreeNode root) {
        TraverseInOrder(root);
    }
    
    public int Next() {
        idx++;
        return inorder[idx];
    }
    
    public bool HasNext() {
        if(idx == inorder.Count-1)
            return false;
        return true;
    }
    
    private void TraverseInOrder(TreeNode node){
        if(node == null) return;
        TraverseInOrder(node.left);
        inorder.Add(node.val);
        TraverseInOrder(node.right);
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
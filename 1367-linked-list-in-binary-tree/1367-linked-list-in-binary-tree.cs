public class Solution {
    public bool IsSubPath(ListNode head, TreeNode root) {
        if(head == null) return true;       // reached end of linked list
        if(root == null) return false;      // reached end of tree
        return DFS(head, root) || IsSubPath(head, root.left) || IsSubPath(head, root.right);
    }

    private bool DFS(ListNode head, TreeNode root) {
        if(head == null) return true;       // reached end of linked list
        if(root == null) return false;      // reached end of tree
        
        if(head.val != root.val) return false;
        return DFS(head.next, root.left) || DFS(head.next, root.right);
    }
}

// Accepted
public class SolutionStringMatch {
    public bool IsSubPath(ListNode head, TreeNode root) {
        var ll = LinkedListToString(head);
        return SearchStringInTree(root, ll, new StringBuilder());
    }

    private string LinkedListToString(ListNode head){
        var sb = new StringBuilder();
        while(head != null){
            sb.Append(head.val + ".");
            head = head.next;
        }
        return sb.ToString();
    }

    private bool SearchStringInTree(TreeNode root, string ll, StringBuilder path) {
        if(root == null) 
            return path.ToString().Contains(ll);
        
        var len = path.Length;
        path.Append(root.val + ".");
        if(SearchStringInTree(root.left, ll, path)) return true;
        if(SearchStringInTree(root.right, ll, path)) return true;
        path.Length = len;

        return false;
    }
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
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
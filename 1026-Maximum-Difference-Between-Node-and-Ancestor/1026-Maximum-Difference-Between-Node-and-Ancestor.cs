public class Solution {
    int maxDiff = 0;
    public int MaxAncestorDiff(TreeNode root) {
        DFS(root, root.val);
        return maxDiff;
    }

    private (int,int) DFS(TreeNode node, int parentVal){
        if(node == null) return (parentVal, parentVal);
        var (maxL,minL) = DFS(node.left, node.val);
        var (maxR,minR) = DFS(node.right, node.val);
        var max = Math.Max(maxL, maxR);
        var min = Math.Min(minL, minR);
        var maxVal = Math.Max(Math.Abs(max-node.val), Math.Abs(node.val - min));
        maxDiff = Math.Max(maxDiff, maxVal);

        max = Math.Max(max, node.val);
        min = Math.Min(min, node.val);
        return(max, min);
    }
}

// this also passess
public class Solution1 {
    public int MaxAncestorDiff(TreeNode root) {
        if(root == null) return 0;
        return MaxAncestorDiff(root, root.val, root.val);
    }
    
    private int MaxAncestorDiff(TreeNode node, int currMax, int currMin) {
        // return max-min when we encounter leaves
        if(node == null)
            return currMax - currMin;
        
        // update max and min based on current node
        currMax = Math.Max(currMax, node.val);
        currMin = Math.Min(currMin, node.val);
        
        // calculate max diff for left and right subtree
        var leftSide = MaxAncestorDiff(node.left, currMax, currMin);
        var rightSide = MaxAncestorDiff(node.right, currMax, currMin);
        
        // return maximum of left and right subtree
        return Math.Max(leftSide, rightSide);
    }
}
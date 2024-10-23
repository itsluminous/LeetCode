public class Solution {
    public TreeNode ReplaceValueInTree(TreeNode root) {
        root.val = 0;
        var level = new List<TreeNode>();
        level.Add(root);

        while(level.Count > 0){
            // total sum of this level
            var levelSum = 0;
            foreach(var node in level){
                if(node.left != null) levelSum+= node.left.val;
                if(node.right != null) levelSum+= node.right.val;
            }

            // assign cousin values and store new level
            var nextLevel = new List<TreeNode>();
            foreach(var node in level){
                // sum of values of both children of node
                var siblingSum = 0;
                if(node.left != null) siblingSum+= node.left.val;
                if(node.right != null) siblingSum+= node.right.val;

                // set new value for both children of node
                if(node.left != null){
                    node.left.val = levelSum - siblingSum;
                    nextLevel.Add(node.left);
                }
                if(node.right != null){
                    node.right.val = levelSum - siblingSum;
                    nextLevel.Add(node.right);
                }

            }
            level = nextLevel;
        }

        return root;
    }
}

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
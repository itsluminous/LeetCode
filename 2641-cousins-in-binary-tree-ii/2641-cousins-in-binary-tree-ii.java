class Solution {
    public TreeNode replaceValueInTree(TreeNode root) {
        root.val = 0;
        var level = new ArrayList<TreeNode>();
        level.add(root);

        while(level.size() > 0){
            // total sum of this level
            var levelSum = 0;
            for(var node : level){
                if(node.left != null) levelSum+= node.left.val;
                if(node.right != null) levelSum+= node.right.val;
            }

            // assign cousin values and store new level
            var nextLevel = new ArrayList<TreeNode>();
            for(var node : level){
                // sum of values of both children of node
                var siblingSum = 0;
                if(node.left != null) siblingSum+= node.left.val;
                if(node.right != null) siblingSum+= node.right.val;

                // set new value for both children of node
                if(node.left != null){
                    node.left.val = levelSum - siblingSum;
                    nextLevel.add(node.left);
                }
                if(node.right != null){
                    node.right.val = levelSum - siblingSum;
                    nextLevel.add(node.right);
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
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
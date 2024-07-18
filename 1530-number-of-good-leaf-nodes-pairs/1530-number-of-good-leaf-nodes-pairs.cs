public class Solution {
    int pairCount = 0;
    int maxDist = 11;

    public int CountPairs(TreeNode root, int distance) {
        CountLeavesAtDistance(root, distance);
        return pairCount;
    }

    private int[] CountLeavesAtDistance(TreeNode node, int distance) {
        var currCount = new int[maxDist];
        
        if(node == null) return currCount;
        if(node.left == null && node.right == null){
            currCount[1]++;
            return currCount;
        }

        // get count of nodes at each distance in left & right sub-tree
        var leftCount = CountLeavesAtDistance(node.left, distance);
        var rightCount = CountLeavesAtDistance(node.right, distance);

        // figure out how many pairs can be formed in the sub-tree
        for(var i=1; i<=distance; i++)
            for(var j=1; j<=(distance - i); j++)
                pairCount += leftCount[i] * rightCount[j];

        // update the count of nodes at i distance
        for(var i=2; i<maxDist; i++)
            currCount[i] = leftCount[i-1] + rightCount[i-1];
        
        return currCount;
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
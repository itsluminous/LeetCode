public class Solution {
    public int[] TreeQueries(TreeNode root, int[] queries) {
        var depths = new Dictionary<int, int>();
        var heights = new Dictionary<int, int>();
        
        // find depth and height of each node
        // depth is nodes from root till curr node
        // height is no. of nodes from curr to leaf
        FindDepthAndHeight(root, depths, heights, 0);

        // group nodes with same depth
        var cousins = GroupCousins(depths, heights);

        // evaluate answer
        return Evaluate(depths, heights, cousins, queries);
    }

    private int[] Evaluate(Dictionary<int, int> depths, Dictionary<int, int> heights, Dictionary<int, List<int>> cousins, int[] queries){
        for(var i=0; i<queries.Length; i++){
            var depth = depths[queries[i]];

            // if no cousin for this node, then max height is curr depth - 1
            if(cousins[depth].Count == 1)
                queries[i] = depth-1;
            
            // the removed node has largest height among cousins
            else if(cousins[depth][1] == heights[queries[i]])
                queries[i] = depth + cousins[depth][0];
            
            // return node with largest height
            else
                queries[i] = depth + cousins[depth][1];
        }

        return queries;
    }

    private Dictionary<int, List<int>> GroupCousins(Dictionary<int, int> depths, Dictionary<int, int> heights){
        var cousins = new Dictionary<int, List<int>>();
        foreach(var nodeVal in depths.Keys){
            var depth = depths[nodeVal];

            if(cousins.ContainsKey(depth)){
                cousins[depth].Add(heights[nodeVal]);
                cousins[depth].Sort();

                // we need to track max 2 nodes. Remove node with smallest height
                if(cousins[depth].Count == 3)
                    cousins[depth].RemoveAt(0); 
            }
            else {
                cousins[depth] = new List<int>{heights[nodeVal]};
            }
        }

        return cousins;
    }

    private int FindDepthAndHeight(TreeNode node, Dictionary<int, int> depths, Dictionary<int, int> heights, int currDepth){
        if(node == null) return -1;
        depths[node.val] = currDepth;

        var leftHeight = FindDepthAndHeight(node.left, depths, heights, currDepth+1);
        var rightHeight = FindDepthAndHeight(node.right, depths, heights, currDepth+1);
        var height = 1 + Math.Max(leftHeight, rightHeight);
        heights[node.val] = height;
        return height;
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
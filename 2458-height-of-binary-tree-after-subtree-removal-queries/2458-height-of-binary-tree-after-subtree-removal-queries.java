
class Solution {
    public int[] treeQueries(TreeNode root, int[] queries) {
        var depths = new HashMap<Integer, Integer>();
        var heights = new HashMap<Integer, Integer>();
        
        // find depth and height of each node
        // depth is nodes from root till curr node
        // height is no. of nodes from curr to leaf
        findDepthAndHeight(root, depths, heights, 0);

        // group nodes with same depth
        var cousins = groupCousins(depths, heights);

        // evaluate answer
        return evaluate(depths, heights, cousins, queries);
    }

    private int[] evaluate(HashMap<Integer, Integer> depths, HashMap<Integer, Integer> heights, HashMap<Integer, ArrayList<Integer>> cousins, int[] queries){
        for(var i=0; i<queries.length; i++){
            var depth = depths.get(queries[i]);

            // if no cousin for this node, then max height is curr depth - 1
            if(cousins.get(depth).size() == 1)
                queries[i] = depth-1;
            
            // the removed node has largest height among cousins
            else if(cousins.get(depth).get(1) == heights.get(queries[i]))
                queries[i] = depth + cousins.get(depth).get(0);
            
            // return node with largest height
            else
                queries[i] = depth + cousins.get(depth).get(1);
        }

        return queries;
    }

    private HashMap<Integer, ArrayList<Integer>> groupCousins(HashMap<Integer, Integer> depths, HashMap<Integer, Integer> heights){
        var cousins = new HashMap<Integer, ArrayList<Integer>>();
        for(var nodeVal : depths.keySet()){
            var depth = depths.get(nodeVal);

            if(cousins.containsKey(depth)){
                cousins.get(depth).add(heights.get(nodeVal));
                Collections.sort(cousins.get(depth));

                // we need to track max 2 nodes. Remove node with smallest height
                if(cousins.get(depth).size() == 3)
                    cousins.get(depth).remove(0); 
            }
            else {
                var list = new ArrayList<Integer>();
                list.add(heights.get(nodeVal));
                cousins.put(depth, list);
            }
        }

        return cousins;
    }

    private int findDepthAndHeight(TreeNode node, HashMap<Integer, Integer> depths, HashMap<Integer, Integer> heights, int currDepth){
        if(node == null) return -1;
        depths.put(node.val, currDepth);

        var leftHeight = findDepthAndHeight(node.left, depths, heights, currDepth+1);
        var rightHeight = findDepthAndHeight(node.right, depths, heights, currDepth+1);
        var height = 1 + Math.max(leftHeight, rightHeight);
        heights.put(node.val, height);
        return height;
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
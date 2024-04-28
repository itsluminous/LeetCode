public class Solution {
    public boolean leafSimilar(TreeNode root1, TreeNode root2) {
        var nodes1 = getLeafNodes(root1);
        var nodes2 = getLeafNodes(root2);
        return nodes1.equals(nodes2);
    }

    public List<Integer> getLeafNodes(TreeNode root) {
        if(root == null) return new ArrayList<Integer>();
        if(root.left == null && root.right == null){
            var lst = new ArrayList<Integer>();
            lst.add(root.val);
            return lst;
        }

        var lst = new ArrayList<Integer>();
        lst.addAll(getLeafNodes(root.left));
        lst.addAll(getLeafNodes(root.right));

        return lst;
    }
}
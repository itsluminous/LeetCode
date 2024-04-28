public class Solution {
    public boolean leafSimilar(TreeNode root1, TreeNode root2) {
        var nodes1 = getLeafNodes(root1);
        var nodes2 = getLeafNodes(root2);

        if(nodes1.size() != nodes2.size()) return false;
        for(var i=0; i<nodes1.size(); i++){
            if(!nodes1.get(i).equals(nodes2.get(i))) return false;
        }   
        
        return true;
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
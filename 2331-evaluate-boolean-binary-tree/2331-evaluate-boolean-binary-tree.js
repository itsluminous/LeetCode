/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} root
 * @return {boolean}
 */
var evaluateTree = function(root) {
    // since it is a full binary tree, then if any child is null, then it is a leaf node
    if(!root.left) return root.val == 1;
    
    let leftVal = evaluateTree(root.left);
    let rightVal = evaluateTree(root.right);

    if(root.val == 2)
        return (leftVal || rightVal);
    return (leftVal && rightVal);
};
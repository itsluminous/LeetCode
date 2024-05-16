class Solution {
    /**
     * @param TreeNode $root
     * @return Boolean
     */
    function evaluateTree($root) {
        // since it is a full binary tree, then if any child is null, then it is a leaf node
        if($root->left === null) return $root->val == 1;
        
        $leftVal = $this->evaluateTree($root->left);
        $rightVal = $this->evaluateTree($root->right);

        if($root->val == 2) return $leftVal || $rightVal;
        return $leftVal && $rightVal;
    }
}

/**
 * Definition for a binary tree node.
 * class TreeNode {
 *     public $val = null;
 *     public $left = null;
 *     public $right = null;
 *     function __construct($val = 0, $left = null, $right = null) {
 *         $this->val = $val;
 *         $this->left = $left;
 *         $this->right = $right;
 *     }
 * }
 */
class Solution {
public:
    bool evaluateTree(TreeNode* root) {
        // since it is a full binary tree, then if any child is null, then it is a leaf node
        if(root->left == nullptr) return root->val == 1;
        
        bool leftVal = evaluateTree(root->left);
        bool rightVal = evaluateTree(root->right);

        if(root->val == 2) return leftVal || rightVal;
        return leftVal && rightVal;
    }
};

/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */
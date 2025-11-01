class Solution {
public:
    ListNode* modifiedList(vector<int>& nums, ListNode* head) {
        unordered_set<int> set(nums.begin(), nums.end());

        // create a dummy head node
        auto newHead = new ListNode(-1, head);
        auto curr = newHead;

        while(curr->next){
            if (set.count(curr->next->val))
                curr->next = curr->next->next;
            else
                curr = curr->next;
        }

        return newHead->next;
    }
};

/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */
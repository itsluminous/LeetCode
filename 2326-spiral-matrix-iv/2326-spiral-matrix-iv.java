class Solution {
    public int[][] spiralMatrix(int m, int n, ListNode head) {
        var ans = new int[m][n];
        for(var i=0; i<m; i++)
            Arrays.fill(ans[i], -1);

        int[][] dirs = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
        int x = 0, y = 0, dirIdx = 0;

        while(head != null){
            ans[x][y] = head.val;

            // update next coordinates
            var newx = x + dirs[dirIdx][0];
            var newy = y + dirs[dirIdx][1];
            if(newx == -1 || newx == m || newy == -1 || newy == n || ans[newx][newy] != -1)
                dirIdx = (dirIdx + 1) % 4;
            
            x += dirs[dirIdx][0];
            y += dirs[dirIdx][1];
            head = head.next;
        }

        return ans;
    }
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
public class Solution {
    public int[][] SpiralMatrix(int m, int n, ListNode head) {
        var matrix = new int[m][];
        for(var x=0; x<m; x++) matrix[x] = new int[n];
        
        for(var x=0; x<m; x++)
            for(var y=0; y<n; y++)
                matrix[x][y] = -1;
        
        var dirs = new []{0, 1, 0, -1, 0};
        int i=0, j=0, dir=0;
        
        while(head != null){
            matrix[i][j] = head.val;
            
            // if next step is out of bound or already filled, change direction
            int new_i = i + dirs[dir], new_j = j + dirs[dir + 1];
            if(new_i < 0 || new_j < 0 || new_i >= m || new_j >= n || matrix[new_i][new_j] != -1)
                dir = (dir+1) % 4;
            
            i += dirs[dir];
            j += dirs[dir+1];
            head = head.next;
        }
        
        return matrix;
    }
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
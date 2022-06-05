public class Solution {
    int count = 0;
    
    public int TotalNQueens(int n) {
        // arrays to mark cols |, and both diagnoals \ & /
        bool[] cols = new bool[n], diag1 = new bool[2*n], diag2 = new bool[2*n];
        BackTrack(0, cols, diag1, diag2, n);
        return count;
    }
    
    private void BackTrack(int row, bool[] cols, bool[] d1, bool[] d2, int n){
        if(row == n) count++;
        
        for(var col=0; col<n; col++){
            int idx1 = col-row+n, idx2 = col+row;
            if(cols[col] || d1[idx1] || d2[idx2]) continue; // if posn is occupied
            
            // mark posn of curr &  neighbours occupied then backtrack
            cols[col] = true; d1[idx1] = true; d2[idx2] = true;
            BackTrack(row+1, cols, d1, d2, n);
            cols[col] = false; d1[idx1] = false; d2[idx2] = false;
        }
    }
}
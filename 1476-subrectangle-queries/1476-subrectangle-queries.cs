public class SubrectangleQueries {
    int[][] rect;

    public SubrectangleQueries(int[][] rectangle) {
        rect = rectangle;
    }
    
    public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue) {
        for(var i=row1; i<=row2; i++)
            for(var j=col1; j<=col2; j++)
                rect[i][j] = newValue;
    }
    
    public int GetValue(int row, int col) {
        return rect[row][col];
    }
}

/**
 * Your SubrectangleQueries object will be instantiated and called as such:
 * SubrectangleQueries obj = new SubrectangleQueries(rectangle);
 * obj.UpdateSubrectangle(row1,col1,row2,col2,newValue);
 * int param_2 = obj.GetValue(row,col);
 */
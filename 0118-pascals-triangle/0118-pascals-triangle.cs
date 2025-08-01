public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var result = new List<IList<int>>();
        var row = new List<int>();                  // this same variable will be reused in all layers
        for(int j=0; j< numRows; j++){              // for all the layers
            for(int i=row.Count -1; i>0; i--){      // starting from right side
                row[i] = row[i] + row[i-1];         // the current row already has prev row data
            }
            row.Add(1);                             // add 1 at end of each row
            result.Add(new List<int>(row));
        }
        return result;
    }
}
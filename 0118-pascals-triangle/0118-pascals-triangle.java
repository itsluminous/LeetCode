class Solution {
    public List<List<Integer>> generate(int numRows) {
        List<List<Integer>> result = new ArrayList<>();
        List<Integer> row = new ArrayList<>();                // this same variable will be reused in all layers

        for (int j = 0; j < numRows; j++) {                   // for all the layers
            for (int i = row.size() - 1; i > 0; i--) {        // starting from right side
                row.set(i, row.get(i) + row.get(i - 1));      // the current row already has prev row data
            }
            row.add(1);                                       // add 1 at end of each row
            result.add(new ArrayList<>(row));
        }
        return result;
    }
}

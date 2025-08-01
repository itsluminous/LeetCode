class Solution:
    def generate(self, numRows: int) -> List[List[int]]:
        result = []
        row = []                                # this same variable will be reused in all layers

        for j in range(numRows):                # for all the layers
            for i in range(len(row) - 1, 0, -1):# starting from right side
                row[i] = row[i] + row[i - 1]    # the current row already has prev row data
            row.append(1)                       # add 1 at end of each row
            result.append(row[:])               # make a copy of current row
        return result

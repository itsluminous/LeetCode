// num of squares in each step increases in multiples of 4
// 1st = 1 + 4*0
// 2nd = 1 + 4*0 + 4*1
// 3rd = 1 + 4*0 + 4*1 + 4*2
// 4th = 1 + 4*0 + 4*1 + 4*2 + 4*3

// apSum formula = n/2 * (2a + (n-1) * d)
// a = 0 in our case, d = 4

class Solution {
    fun coloredCells(n: Int): Long {
        var apSum = n.toLong() * (n - 1).toLong() * 2;
        return 1 + apSum;
    }
}
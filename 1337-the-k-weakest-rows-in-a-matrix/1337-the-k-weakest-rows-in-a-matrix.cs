public class Solution {
    public int[] KWeakestRows(int[][] mat, int k) {
        return mat
		.Select((arr, idx) => (idx, count: arr.Sum()))
		.OrderBy(x => x.count)
		.ThenBy(x => x.idx)
		.Select(x => x.idx)
		.Take(k)
		.ToArray();
    }
}
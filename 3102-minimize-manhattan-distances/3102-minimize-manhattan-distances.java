// https://leetcode.com/problems/minimize-manhattan-distances/solutions/4949500/clear-explanation-on-formula-with-multiset-implementation/
// The soln in link uses sorted set, but we don't need sorted set, because we can live with sorting just once
class Solution {
    public int minimumDistance(int[][] points) {
        int n = points.length;
        int minimumVal = Integer.MAX_VALUE;

        // we ideally need to store just the sum/diff
        // but we are storing index also to handle case where sum/diff of two points is same
        List<ValueIndex> plus = new ArrayList<>(), minus = new ArrayList<>();

        // for each point, store (x+y) and (x-y)
        // refer the intuition in the link provided for why
        for (int i = 0; i < n; i++) {
            int[] point = points[i];
            plus.add(new ValueIndex(point[0] + point[1], i));
            minus.add(new ValueIndex(point[0] - point[1], i));
        }

        Collections.sort(plus, (a, b) -> Integer.compare(a.val, b.val));
        Collections.sort(minus, (a, b) -> Integer.compare(a.val, b.val));

        // now one by one remove each point and compute answer
        for (int i = 0; i < n; i++) {
            // now we need to find the extreme values from points array after removing point i
            int maxPlus = plus.get(n - 1).idx == i ? plus.get(n - 2).val : plus.get(n - 1).val;
            int minPlus = plus.get(0).idx == i ? plus.get(1).val : plus.get(0).val;
            int maxMinus = minus.get(n - 1).idx == i ? minus.get(n - 2).val : minus.get(n - 1).val;
            int minMinus = minus.get(0).idx == i ? minus.get(1).val : minus.get(0).val;

            // maximum manhattan distance after removing point i
            int maxAfterRemovingOne = Math.max(maxPlus - minPlus, maxMinus - minMinus);

            // update final answer
            minimumVal = Math.min(minimumVal, maxAfterRemovingOne);
        }

        return minimumVal;
    }
}

class ValueIndex {
    public int val;
    public int idx;

    public ValueIndex(int v, int i) {
        val = v;
        idx = i;
    }
}
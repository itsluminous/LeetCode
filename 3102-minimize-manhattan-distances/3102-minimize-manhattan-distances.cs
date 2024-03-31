// https://leetcode.com/problems/minimize-manhattan-distances/solutions/4949500/clear-explanation-on-formula-with-multiset-implementation/
// The soln in link uses sorted set, but we don't need sorted set, because we can live with sorting just once
public class Solution {
    public int MinimumDistance(int[][] points) {
        var n = points.Length;
        var minimumVal = int.MaxValue;

        // we ideally need to store just the sum/diff
        // but we are storing index also to handle case where sum/diff of two points is same
        List<ValueIndex> plus = new List<ValueIndex>(), minus = new List<ValueIndex>();

        // for each point, store (x+y) and (x-y)
        // refer the intution in link on top for why
        for(var i=0; i<n; i++){
            var point = points[i];
            plus.Add(new ValueIndex(point[0] + point[1], i));
            minus.Add(new ValueIndex(point[0] - point[1], i));
        }

        plus.Sort((a, b) => a.val.CompareTo(b.val));
        minus.Sort((a, b) => a.val.CompareTo(b.val));
        
        // now one by one remove each point and compute answer
        for (var i=0; i<n; i++) {
            // now we need to find the extreme values from points array after removing point i
            var maxPlus = plus[n-1].idx == i ? plus[n-2].val : plus[n-1].val;
            var minPlus = plus[0].idx == i ? plus[1].val : plus[0].val;
            var maxMinus = minus[n-1].idx == i ? minus[n-2].val : minus[n-1].val;
            var minMinus = minus[0].idx == i ? minus[1].val : minus[0].val;

            // maximum manhattan distance after removing point i
            var maxAfterRemovingOne = Math.Max(maxPlus - minPlus, maxMinus - minMinus);

            // update final answer
            minimumVal = Math.Min(minimumVal, maxAfterRemovingOne);
        }

        return minimumVal;
    }
}

public class ValueIndex{
    public int val;
    public int idx;

    public ValueIndex(int v, int i){
        val = v;
        idx = i;
    }
}
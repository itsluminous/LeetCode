public class Solution {
    double delta = 0.001;   // to keep decimal till 3 places only

    public boolean judgePoint24(int[] cards) {
        List<Double> arr = new ArrayList<>();
        for(var card : cards) arr.add((double) card);
        return evaluate(arr);
    }

    private boolean evaluate(List<Double> arr) {
        if (arr.size() == 1) {
            if (Math.abs(arr.get(0) - 24.0) < delta)
                return true;
            return false;
        }

        // try all permutations of two numbers
        for (var i = 0; i < arr.size(); i++) {
            for (var j = 0; j < i; j++) {
                List<Double> next = new ArrayList<>();
                double n1 = arr.get(i), n2 = arr.get(j);

                // add all possible operations between n1 & n2
                next.addAll(Arrays.asList(n1+n2, n1-n2, n2-n1, n1*n2));
                if (Math.abs(n1) > delta) next.add(n2 / n1);
                if (Math.abs(n2) > delta) next.add(n1 / n2);

                // backtracking
                arr.remove(i);
                arr.remove(j);
                for (var nxt : next) {
                    arr.add(nxt);
                    if (evaluate(arr)) return true;
                    arr.remove(arr.size() - 1);
                }
                arr.add(j, n2);
                arr.add(i, n1);
            }
        }
        return false;
    }
}
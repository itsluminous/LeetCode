class Solution {
    List<Integer>[][] dp;

    public List<Integer> diffWaysToCompute(String expression) {
        var n = expression.length();
        dp = new ArrayList[n][n];
        return compute(expression.toCharArray(), 0, n-1);
    }

    private List<Integer> compute(char[] exp, int start, int end){
        if(dp[start][end] != null) return dp[start][end];

        var result = new ArrayList<Integer>();
        // single digit
        if(start == end){
            result.add(exp[start] - '0');
            dp[start][end] = result;
            return result;
        }

        // two digit number only
        if(start+1 == end && Character.isDigit(exp[start])){
            var num = 10 * (exp[start] - '0');
            num += (exp[end] - '0');
            result.add(num);
            dp[start][end] = result;
            return result;
        }

        // recursion to try splitting expression at each operator
        for(var i=start; i<=end; i++){
            if(Character.isDigit(exp[i])) continue;  // we want to split only at operator index

            var leftResult = compute(exp, start, i-1);
            var rightResult = compute(exp, i+1, end);

            // combined permutation of both side results
            for(var l : leftResult){
                for(var r : rightResult){
                    switch (exp[i]) {
                        case '+':
                            result.add(l + r);
                            break;
                        case '-':
                            result.add(l - r);
                            break;
                        case '*':
                            result.add(l * r);
                            break;
                    }
                }
            }
        }

        dp[start][end] = result;
        return result;
    }
}
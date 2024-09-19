public class Solution {
    IList<int>[,] dp;

    public IList<int> DiffWaysToCompute(string expression) {
        var n = expression.Length;
        dp = new List<int>[n,n];
        return Compute(expression, 0, n-1);
    }

    private IList<int> Compute(string exp, int start, int end){
        if(dp[start,end] != null) return dp[start,end];

        var result = new List<int>();
        // single digit
        if(start == end){
            result.Add(exp[start] - '0');
            dp[start,end] = result;
            return result;
        }

        // two digit number only
        if(start+1 == end && char.IsDigit(exp[start])){
            var num = 10 * (exp[start] - '0');
            num += (exp[end] - '0');
            result.Add(num);
            dp[start,end] = result;
            return result;
        }

        // recursion to try splitting expression at each operator
        for(var i=start; i<=end; i++){
            if(char.IsDigit(exp[i])) continue;  // we want to split only at operator index

            var leftResult = Compute(exp, start, i-1);
            var rightResult = Compute(exp, i+1, end);

            // combined permutation of both side results
            foreach(var l in leftResult){
                foreach(var r in rightResult){
                    result.Add(exp[i] switch {
                        '+' => l + r,
                        '-' => l - r,
                        '*' => l * r,
                    });
                }
            }
        }

        dp[start,end] = result;
        return result;
    }
}
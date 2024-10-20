public class Solution {
    public bool ParseBoolExpr(string expression) {
        var n = expression.Length;
        if(n == 1) return expression == "t";   // only one char in expression
        if(expression[0] == '!') return !ParseBoolExpr(expression.Substring(2, n-3));

        var isAnd = expression[0] == '&';
        var val = isAnd;    // True by default for AND, False by default for OR

        for(int start=2, end=2, count=0; end < n && val == isAnd; end++){
            // count opening & closing brackets
            if(expression[end] == '(') count++;
            if(expression[end] == ')') count--;

            // ParseBoolExpr expression if we found a matching closing bracket
            if(end == n-1 || (expression[end] == ',' && count == 0)){
                if(isAnd) val &= ParseBoolExpr(expression.Substring(start, end - start));
                else val |= ParseBoolExpr(expression.Substring(start, end - start));
                start = end+1;
            }
        }

        return val;
    }
}
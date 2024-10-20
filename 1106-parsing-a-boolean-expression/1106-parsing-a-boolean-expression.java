class Solution {
    public boolean parseBoolExpr(String expression){
        var n = expression.length();
        if(n == 1) return expression.equals("t");   // only one char in expression
        if(expression.charAt(0) == '!') return !parseBoolExpr(expression.substring(2, n-1));

        var isAnd = expression.charAt(0) == '&';
        var val = isAnd;    // True by default for AND, False by default for OR

        for(int start=2, end=2, count=0; end < n && val == isAnd; end++){
            // count opening & closing brackets
            if(expression.charAt(end) == '(') count++;
            if(expression.charAt(end) == ')') count--;

            // parseBoolExpr expression if we found a matching closing bracket
            if(end == n-1 || (expression.charAt(end) == ',' && count == 0)){
                if(isAnd) val &= parseBoolExpr(expression.substring(start, end));
                else val |= parseBoolExpr(expression.substring(start, end));
                start = end+1;
            }
        }

        return val;
    }
}
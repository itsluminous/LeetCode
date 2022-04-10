public class Solution {
    public string MinimizeResult(string exp) {
        int n = exp.Length, minVal = int.MaxValue;
        var minStr = exp;
        
        for(var i=0; i<n; i++){
            if(exp[i] == '+') break;
            // find number before bracket
            var pre = exp.Substring(0, i);
            var preVal = pre.Length == 0 ? 1 : Convert.ToInt32(pre);
            
            for(var j=n-1; j>i; j--){
                if(exp[j] == '+') break;
                
                // find number after bracket
                var post = j == n-1 ? string.Empty : exp.Substring(j+1, n-j-1);
                var postVal = post.Length == 0 ? 1 :  Convert.ToInt32(post);
                
                // find value of expression inside bracket
                var inner = exp.Substring(i, j-i+1);
                var innerVal = EvalExpression(inner);
                
                // evaluate total expression and update minVal
                var curr = preVal*innerVal*postVal;
                if(minVal > curr){
                    minVal = curr;
                    minStr = pre + "(" + inner + ")" + post;
                }
            }
        }
        
        return minStr;
    }
    
    private int EvalExpression(string str){
        var split = str.Split("+");
        if(split.Length != 2) return int.MaxValue;
        return Convert.ToInt32(split[0]) + Convert.ToInt32(split[1]);
    }
}
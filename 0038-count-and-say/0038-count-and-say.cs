// Recursive
public class Solution {
    public string CountAndSay(int n) {
        if(n == 1) return "1";
        var str = CountAndSay(n-1);

        var sb = new StringBuilder();
        for(var i=str.Length-1; i>=0; ){
            var ch = str[i];
            var count = 0;
            while(i >= 0 && str[i] == ch){
                i--;
                count++;
            }
            sb.Insert(0, count.ToString() + ch);
        }
        return sb.ToString();
    }
}

// Accepted - Iteration
public class SolutionIter {
    public string CountAndSay(int n) {
        var str = "1";
        while(--n > 0){
            var sb = new StringBuilder();
            for(var i=str.Length-1; i>=0; ){
                var ch = str[i];
                var count = 0;
                while(i >= 0 && str[i] == ch){
                    i--;
                    count++;
                }
                sb.Insert(0, count.ToString() + ch);
            }
            str = sb.ToString();
        }
        return str;
    }
}
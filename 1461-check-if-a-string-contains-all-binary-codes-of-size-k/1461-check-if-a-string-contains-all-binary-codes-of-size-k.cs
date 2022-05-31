public class Solution {
    public bool HasAllCodes(string s, int k) {
        // create a set of all possible numbers in given string
        var codes = new HashSet<int>();
        for(var i=0; i<=s.Length-k; i++){
            var str = s.Substring(i, k);
            codes.Add(Convert.ToInt32(str, 2));
        }
        
        // generate max possible number with k size
        var max_str = new StringBuilder();
        for(var i=0; i<k; i++) max_str.Append("1");
        var max = Convert.ToInt32(max_str.ToString(), 2);
        
        // check if all numbers are present
        for(var i=0; i<=max; i++){
            if(!codes.Contains(i))
                return false;
        }
        return true;
    }
}
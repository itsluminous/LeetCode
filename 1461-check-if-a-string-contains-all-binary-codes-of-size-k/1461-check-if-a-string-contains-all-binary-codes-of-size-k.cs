public class Solution {
    public bool HasAllCodes(string s, int k) {
        // create a set of all possible numbers in given string
        var codes = new HashSet<string>();
        for(var i=0; i<=s.Length-k; i++){
            codes.Add(s.Substring(i, k));
        }
        
        // max possible number with k size
        var max = 1 << k;
        
        // if total items in set is not same as max possible, then some numbers are missing
        if(max != codes.Count) return false;
        return true;
    }
}

// Accepted - same logic as above but extra loops and string to int conversion
public class Solution1 {
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
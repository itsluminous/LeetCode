public class Solution {
    public string GetSmallestString(int n, int k) {
        var sb = new StringBuilder();
        while(n != 0){
            var aCount = n-1;           // assume that all other characters are 'a'
            var remaining = k - aCount; // remaining k for current char
            var curr = Math.Min(26, remaining);
            
            // now append the current char to string builder
            char c='a'; 
            c += (char)(curr - 1);
            sb.Append(c);
            
            // prepare for next loop
            n--;
            k -= curr;
        }
        
        return new string(sb.ToString().Reverse().ToArray());
    }
}
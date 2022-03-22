// using char array
public class Solution {
    public string GetSmallestString(int n, int rem)
    {
         var result = new char[n];
         Array.Fill(result, 'a');

         // We have already filled array with 'a' with value 1 for each char
         rem -= n;

         for(var i = n-1; i >= 0; i--){
             var diff = Math.Min(rem, 25);
             result[i] = (char)('a' + diff);
             rem -= diff;
         }

         return new string(result);
    }
}

// using string builder
public class Solution1 {
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
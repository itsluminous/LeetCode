// Refer : https://leetcode.com/problems/find-palindrome-with-fixed-length/discuss/1887014/Simple-Java-Solution-Half-the-palindrome-length/1325237
// k = 35, lenth = 10 (Even)
// 1st half number = 9999+35 = 10034         // minVal = 9999+1, maxVal = 99999
// 2nd half number = reverse(10034) = 43001
// Number = 1003443001

// k = 35, lenth = 11 (Odd)
// 1st half number = 99999+35 = 100034       // minVal = 99999+1, maxVal = 999999
// 2nd half number = reverse(1003) = 3001
// Number = 10003430001

public class Solution {
    public long[] KthPalindrome(int[] queries, int intLength) {
        var n = queries.Length;
        var result = new long[n];
        
        for(var i=0; i<n; i++)
            result[i] = GetKthPalindrome(queries[i], intLength);
        
        return result;
    }
    
    private long GetKthPalindrome(int idx, int len) {
        var minDigits = len%2 == 0 ? len/2 -1 : len/2;
        var maxDigits = len%2 == 0 ? len/2 : len/2 + 1;
        
        long minVal = 0, maxVal = 0;
        
        while(minDigits-- > 0) minVal = minVal*10 + 9;
        while(maxDigits-- > 0) maxVal = maxVal*10 + 9;
        
        if(idx > (maxVal - minVal)) return -1;
        
        var part1 = (minVal + idx).ToString();
        var part2 = len%2 == 0 ? part1 : part1.Substring(0, len/2);
        part2 = Reverse(part2);
        
        return (long)Convert.ToDouble(part1 + part2);
    }
    
    private string Reverse(string str){
        char[] charArray = str.ToCharArray();
        Array.Reverse( charArray );
        return new string( charArray );
    }
}
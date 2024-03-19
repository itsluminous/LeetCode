public class Solution {
    public string MaximumOddBinaryNumber(string s) {
        var n = s.Length;
        var oneCount = s.Count(c => c == '1');
        var maxBinary = new char[n];

        for(var i=0; i<oneCount-1; i++) maxBinary[i] = '1';
        for(var i=oneCount-1; i<n-1; i++) maxBinary[i] = '0';
        maxBinary[n-1]='1';

        return new String(maxBinary);
    }
}
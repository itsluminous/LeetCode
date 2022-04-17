public class Solution {
    public string DigitSum(string s, int k) {
        while(s.Length > k){
            var chunks = Split(s, k);
            var sb = new StringBuilder();
            foreach(var ch in chunks) sb.Append(SumOfChunk(ch));
            s = sb.ToString();
        }
        return s;
    }
    
    private string[] Split(string str, int size)
    {
        var len = str.Length;
        var chunks = new List<string>();
        
        for(var i=0; i<len; i+= size){
            var chunkSize = Math.Min(size, len-i);
            chunks.Add(str.Substring(i, chunkSize));
        }
        
        return chunks.ToArray();
    }
    
    private string SumOfChunk(string s){
        int sum = 0;
        foreach(var ch in s){
            int val = ch - '0';
            sum += val;
        }
        return sum.ToString();
    }
}
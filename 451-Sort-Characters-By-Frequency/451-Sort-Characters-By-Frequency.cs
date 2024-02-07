public class Solution {
    public string FrequencySort(string s) {
        var freq = new int[128];
        foreach(var ch in s) freq[ch]++;

        var sorted = freq.Select((count, ch) => new {ch, count}).OrderByDescending(c => c.count);
        var result = new StringBuilder();
        foreach(var k in sorted){
            if(k.count == 0) break;
            for(var i=0; i<k.count; i++)
                result.Append((char)k.ch);
        }

        return result.ToString();
    }
}

// This also passes
public class SolutionUsingDedicatedClass {
    public string FrequencySort(string s) {
        var sf = new StrFreq[100];
        for(var i=0; i<100; i++) sf[i] = new StrFreq();

        foreach(var ch in s){
            sf[ch-'0'].ch = ch;
            sf[ch-'0'].freq++;
        }

        var sorted = sf.OrderByDescending(k => k.freq);
        var result = new List<char>();
        foreach(var k in sorted){
            if(k.freq == 0) break;
            for(var i=0; i<k.freq; i++)
                result.Add(k.ch);
        }

        return new string(result.ToArray());
    }
}

class StrFreq {
    public char ch;
    public int freq;
}
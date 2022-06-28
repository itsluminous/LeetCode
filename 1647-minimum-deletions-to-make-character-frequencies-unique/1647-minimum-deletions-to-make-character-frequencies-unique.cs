public class Solution {
    public int MinDeletions(string s) {
        // count occurence of each char
        var dict = new Dictionary<char, int>();
        foreach(var ch in s){
            if(dict.ContainsKey(ch)) dict[ch]++;
            else dict[ch] = 1;
        }
        
        // get sorted (by desc) list of all counts
        var counts = dict.OrderByDescending(kv => kv.Value).Select(kv => kv.Value).ToList();
        
        // if curr count >= prev, then we delete extra numbers
        var deletions = 0;
        for(var i=1; i<counts.Count; i++){
            // Console.WriteLine($"curr={counts[i]}, prev={counts[i-1]}, del={deletions}");
            if(counts[i] < counts[i-1]) continue;   // no deletions needed
            if(counts[i-1] == 0){           // special case - we don't want deletions to go in -ve
                deletions += counts[i];
                counts[i] = 0;
                continue;
            }
            var newVal = counts[i-1] - 1;
            deletions += counts[i] - newVal;
            counts[i] = newVal;
        }
        
        return deletions;
    }
}
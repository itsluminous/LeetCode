public class Solution {
    public bool MaxSubstringLength(string s, int k) {
        if(k == 0) return true;
        var n = s.Length;
        
        // find out first and last occurrences of each char
        int[] first = new int[26], last = new int[26];
        Array.Fill(first, n);

        for(var i=0; i<n; i++){
            var idx = s[i] - 'a';
            first[idx] = Math.Min(first[idx], i);
            last[idx] = Math.Max(last[idx], i);
        }

        // capture start & end of all substrings that satisfy condition
        var segments = new List<int[]>();
        for(var start=0; start<n; start++){
            // get the first & last occurence of curr char
            int begin = first[s[start] - 'a'], end = last[s[start] - 'a'];

            // if curr char exists before the substring start, then it is invalid
            if(begin < start) continue;

            var valid = true;
            for(var curr=begin; curr<end; curr++){
                if(first[s[curr] - 'a'] < begin){
                    valid = false;
                    break;
                }
                end = Math.Max(end, last[s[curr] - 'a']);
            }

            // if this substring is not full string, then it is valid
            if(valid && !(begin == 0 && end == n-1))
                segments.Add(new int[]{begin, end});
            
        }

        // count non-overlapping substring segments
        int count = 0, lastIdx = -1;
        segments.Sort((seg1, seg2) => seg1[1] - seg2[1]);    // sort based on end index

        foreach(var seg in segments){
            if(seg[0] <= lastIdx) continue; // overlapping
            lastIdx = seg[1];
            count++;
        }

        return count >= k;
    }
}
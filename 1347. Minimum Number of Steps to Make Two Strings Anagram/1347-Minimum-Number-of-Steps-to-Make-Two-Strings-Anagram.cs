public class Solution {
    public int MinSteps(string s, string t) {
        int[] sArr = new int[26],  tArr = new int[26];

        for(var i=0; i<s.Length; i++){
            sArr[s[i] - 'a']++;
            tArr[t[i] - 'a']++;
        }

        var steps = 0;
        for(var i=0; i<26; i++)
            if(tArr[i] > sArr[i])
                steps += (tArr[i] - sArr[i]);
        
        return steps;
    }
}

// This also passes, similar time complexity
public class Solution1 {
    public int MinSteps(string s, string t) {
        var sArr = GetCharCount(s);
        var tArr = GetCharCount(t);

        var steps = 0;
        for(var i=0; i<26; i++){
            var diff = tArr[i] - sArr[i];
            steps += (diff < 0 ? 0 : diff);
        }
        
        return steps;
    }

    private int[] GetCharCount(string str){
        var arr = new int[26];
        foreach(var ch in str){
            arr[ch-'a']++;
        }
        return arr;
    }
}
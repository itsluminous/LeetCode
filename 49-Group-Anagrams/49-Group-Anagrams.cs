// This one is slower than 2nd soln
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, List<string>>(); // Dictionary with anagrams under same key
        foreach(var str in strs){
            var chars = str.ToCharArray();
            Array.Sort(chars);
            var key = new String(chars);
            if(dict.ContainsKey(key)) dict[key].Add(str);
            else dict[key] = new List<string>{str};
        }

        var result = new List<IList<string>>();
        foreach(var key in dict.Keys)
            result.Add(dict[key]);
        
        return result;
    }
}

// Passes
public class SolutionWithIntArr {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, List<string>>(); // Dictionary with anagrams under same key
        foreach(var str in strs){
            var k = new int[26];
            foreach(var ch in str) k[ch-'a']++;

            var key = string.Join(",", k.Select(x => x.ToString()));
            if(dict.ContainsKey(key)) dict[key].Add(str);
            else dict[key] = new List<string>{str};
        }

        var result = new List<IList<string>>();
        foreach(var key in dict.Keys)
            result.Add(dict[key]);
        
        return result;
    }
}
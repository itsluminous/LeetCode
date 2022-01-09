// Using HashSet
public class Solution {
    public int WordCount(string[] startWords, string[] targetWords) {
        var set = new HashSet<string>();
        foreach(var word in startWords){
            var sorted = String.Concat(word.OrderBy(c => c));   // sort characters
            set.Add(sorted);
        }
        
        var matching = 0;
        foreach(var word in targetWords){
            var sorted = String.Concat(word.OrderBy(c => c));   // sort characters
            var len = sorted.Length;
            // now one by one remove characters from the target word and see if it exists in hash set
            for(var i=0; i<len; i++){
                var newWord = sorted.Substring(0,i) + sorted.Substring(i+1,len-i-1);
                if(set.Contains(newWord)){
                    matching++;
                    break;
                }
            }
        }
        
        return matching;
    }
}

// Brute force - TLE
public class Solution1 {
    public int WordCount(string[] startWords, string[] targetWords) {
        var matching = 0;
        foreach(var tWord in targetWords){
            var target = String.Concat(tWord.OrderBy(c => c));
            foreach(var sWord in startWords){
                if(sWord.Length != target.Length-1) continue;
                var start = String.Concat(sWord.OrderBy(c => c));
                var miss = false;
                var s = 0;
                for(var t=0; t<target.Length; t++){
                    if(t == target.Length-1 && !miss) break;
                    if(target[t] != start[s]){
                        if(miss) break;
                        miss = true;
                    }
                    else s++;
                }
                if(s == start.Length){
                    matching++;
                    break;
                }
            }
        }
        return matching;
    }
}
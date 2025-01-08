public class Solution {
    public int CountPrefixSuffixPairs(string[] words) {
        var n = words.Length;
        var count = 0;
        for(var i=0; i<n-1; i++){
            var str1 = words[i];
            for(var j=i+1; j<n; j++){
                if(IsPrefixAndSuffix(str1, words[j])) count++;
            }
        }
        
        return count;
    }
    
    private bool IsPrefixAndSuffix(string str1, string str2){
        return (str1.Length <= str2.Length && str2.StartsWith(str1) && str2.EndsWith(str1));
    }
}
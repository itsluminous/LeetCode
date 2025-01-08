class Solution {
    public int countPrefixSuffixPairs(String[] words) {
        var n = words.length;
        var count = 0;
        for(var i=0; i<n-1; i++){
            var str1 = words[i];
            for(var j=i+1; j<n; j++){
                if(isPrefixAndSuffix(str1, words[j])) count++;
            }
        }
        
        return count;
    }
    
    private boolean isPrefixAndSuffix(String str1, String str2){
        return (str1.length() <= str2.length() && str2.startsWith(str1) && str2.endsWith(str1));
    }
}
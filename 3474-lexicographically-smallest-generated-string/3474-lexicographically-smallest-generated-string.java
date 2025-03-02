class Solution {
    public String generateString(String str1, String str2) {
        int len1 = str1.length(), len2 = str2.length();
        var len = len1 + len2 - 1;
        char empty = '0';

        var ans = new char[len];
        var forced = new boolean[len];
        Arrays.fill(ans, empty);

        // fill all chars for "T"
        // for "F", fill it with 'a', to keep lexicographically smallest
        for(var i=0; i<len1; i++){
            if(str1.charAt(i) == 'T'){
                for(var j=0; j<len2; j++){
                    if(ans[i + j] == empty){
                        ans[i + j] = str2.charAt(j);
                        forced[i + j] = true;
                    }
                    else if(ans[i + j] != str2.charAt(j))
                        return "";
                }
            }
            else if(ans[i] == empty)
                ans[i] = 'a';
        }

        // fill remaining empty chars with "a"
        for(var i=len1; i<len; i++){
            if(ans[i] == empty)
                ans[i] = 'a';
        }

        // fix any "F" that matches str2 
        var modified = true;
        while(modified){
            modified = false;
            for(var i=0; i<len1; i++){
                if(str1.charAt(i) == 'T') continue;

                // if even a single char is a mismatch, then no change needed
                var problem = true;
                for(var j=0; j<len2; j++){
                    if(ans[i + j] != str2.charAt(j)){
                        problem = false;
                        break;
                    }
                }

                if(!problem) continue;

                // try to change any char from behind to be non 'a', to keep lexicographically smallest
                for(var j=len2-1; j>=0; j--){
                    if(forced[i+j]) continue;       // can't change this
                    ans[i+j] = 'b';
                    problem = false;

                    // change all next chars to 'a' (they may have been changed to 'b' by prev steps)
                    for(var k=i+j+1; k<len; k++)
                        if(!forced[k]) ans[k] = 'a';
                    
                    break;
                }

                if(problem) return "";  // not fixable
                modified = true;
                break;
            }
        }

        return new String(ans);
    }
}
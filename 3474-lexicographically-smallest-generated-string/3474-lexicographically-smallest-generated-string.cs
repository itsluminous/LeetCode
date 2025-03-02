public class Solution {
    public string GenerateString(string str1, string str2) {
        int len1 = str1.Length, len2 = str2.Length;
        var len = len1 + len2 - 1;
        char empty = '0';

        var ans = new char[len];
        var forced = new bool[len];
        Array.Fill(ans, empty);

        // fill all chars for "T"
        // for "F", fill it with 'a', to keep lexicographically smallest
        for(var i=0; i<len1; i++){
            if(str1[i] == 'T'){
                for(var j=0; j<len2; j++){
                    if(ans[i + j] == empty){
                        ans[i + j] = str2[j];
                        forced[i + j] = true;
                    }
                    else if(ans[i + j] != str2[j])
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
                if(str1[i] == 'T') continue;

                // if even a single char is a mismatch, then no change needed
                var problem = true;
                for(var j=0; j<len2; j++){
                    if(ans[i + j] != str2[j]){
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

        return new string(ans);
    }
}
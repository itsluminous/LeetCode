// solution - Work Backwards
public class Solution {
    public int[] MovesToStamp(string stamp, string target) {
        int stars = 0, tlen = target.Length, slen = stamp.Length;
        var result = new List<int>();
        var visited = new bool[tlen];
        var targetChars = target.ToCharArray();
        
        while(stars < tlen){
            var noReplacement = true;
            for(var i=0; i <= tlen-slen; i++){
                if(!visited[i] && CanReplace(stamp, targetChars, i)){
                    stars = DoReplace(targetChars, i, slen, stars);
                    noReplacement = false;
                    visited[i] = true;
                    result.Add(i);
                    if(stars == tlen) break;    // already found solution
                }
            }
            
            if(noReplacement) return new int[0];    // we were not able to substitiute even once
        }
        
        result.Reverse();   // because we did our work in reverse
        return result.ToArray();
    }
    
    private bool CanReplace(string stamp, char[] target, int idx){
        for(var i=0; i<stamp.Length; i++)
            if(target[idx+i] != '*' && target[idx+i] != stamp[i])
                return false;
        return true;
    }
    
    private int DoReplace(char[] target, int idx, int slen, int stars){
        for(var i=0; i<slen; i++)
            if(target[idx+i] != '*'){
                target[idx+i] = '*';
                stars++;
            }
        return stars;
    }
}
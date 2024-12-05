class Solution {
    public boolean canChange(String start, String target) {
        int n = start.length(), sIdx = 0, tIdx = 0;

        while(sIdx < n || tIdx < n){
            // skip all blanks
            while(sIdx < n && start.charAt(sIdx) == '_') sIdx++;
            while(tIdx < n && target.charAt(tIdx) == '_') tIdx++;

            // either both string should be over, or none
            if(sIdx == n && tIdx == n) return true;
            if(sIdx == n || tIdx == n) return false;

            if(start.charAt(sIdx) != target.charAt(tIdx) ||
                (sIdx < tIdx && start.charAt(sIdx) == 'L') ||
                (sIdx > tIdx && start.charAt(sIdx) == 'R')
            ) return false;

            sIdx++;
            tIdx++;
        }
        return true;
    }
}

// Acccepted - O(n)
class SolutionConvoluted {
    public boolean canChange(String start, String target) {
        char[] s = start.toCharArray(), t = target.toCharArray();
        var n = s.length;
        int lbal = 0, rbal = 0; // this tracks how many more l & r we need to shift

        for(var i=0; i<n-1; i++){
            if(lbal > 0 && t[i] == '_') {
                t[i] = 'L';
                lbal--;
            }
            if(rbal > 0 && s[i] == '_') {
                s[i] = 'R';
                rbal--;
            }

            if(s[i] == t[i]) continue;
            if(s[i] != '_' && t[i] != '_') return false;

            if(s[i] == '_'){
                if(t[i] != 'L') return false;
                if(t[i+1] == 'R') return false;
                if(t[i+1] == 'L') lbal++;
                else t[i+1] = 'L';
            }
            else if(t[i] == '_'){
                if(s[i] != 'R') return false;
                if(s[i+1] == 'L') return false;
                if(s[i+1] == 'R') rbal++;
                else s[i+1] = 'R';
            }
        }

        if(lbal > 0 && t[n-1] == '_') {
            t[n-1] = 'L';
            lbal--;
        }
        if(rbal > 0 && s[n-1] == '_') {
            s[n-1] = 'R';
            rbal--;
        }
        return s[n-1] == t[n-1] && lbal == 0 && rbal == 0;
    }
}
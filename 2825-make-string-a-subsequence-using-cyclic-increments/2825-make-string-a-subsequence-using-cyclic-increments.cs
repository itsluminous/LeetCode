public class Solution {
    public bool CanMakeSubsequence(string str1, string str2) {
        int len1 = str1.Length, len2 = str2.Length;
        int idx1 = 0, idx2 = 0;
        if(len1 < len2) return false;

        for(;idx1 < len1 && idx2 < len2; idx1++)
            if(CharMatch(str1[idx1], str2[idx2]))
                idx2++;

        return idx2 == len2;
    }

    private bool CharMatch(char ch1, char ch2){
        if(ch1 == ch2) return true;
        if(ch1 == 'z' && ch2 == 'a') return true;
        return 1 + ch1 == ch2;
    }
}
class Solution {
    public boolean canMakeSubsequence(String str1, String str2) {
        int len1 = str1.length(), len2 = str2.length();
        int idx1 = 0, idx2 = 0;
        if(len1 < len2) return false;

        for(;idx1 < len1 && idx2 < len2; idx1++)
            if(charMatch(str1.charAt(idx1), str2.charAt(idx2)))
                idx2++;

        return idx2 == len2;
    }

    private boolean charMatch(char ch1, char ch2){
        if(ch1 == ch2) return true;
        if(ch1 == 'z' && ch2 == 'a') return true;
        return 1 + ch1 == ch2;
    }
}
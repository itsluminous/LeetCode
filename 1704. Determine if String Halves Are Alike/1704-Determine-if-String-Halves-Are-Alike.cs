public class Solution {
    public bool HalvesAreAlike(string s) {
        int lCount = 0, rCount = 0;
        for(int i=0, j=s.Length-1; i<j; i++,j--){
            if(IsVowel(s[i])) lCount++;
            if(IsVowel(s[j])) rCount++;
        }
        return lCount == rCount;
    }

    private bool IsVowel(char c){
        c = Char.ToLower(c);
        if(c=='a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            return true;
        return false;
    }
}
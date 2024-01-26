// Logic : 
// assuming xy is count of pairs where s1[i] = x & s2[i] = y
// assuming yx is count of pairs where s1[i] = y & s2[i] = x
// There are 3 cases -
// 1. if count of xy is even, then it just need half the swap (eg. for s1="xx" & s2="yy", only 1 swap)
// 2. if count of yx is even, then it just need half the swap (eg. for s1="yy" & s2="xx", only 1 swap)
// 3. if count of xy=1 & yx=1, then it needs 2 swaps (eg. for s1="xy" & s2="yx", we need 2 swaps)
// In case of big strings, first remove all 1 swap conditions, then with leftover do 2 swap
// If xy+yx is odd number, then it is impossible to make strings equal
// we don't care about chars that already match

public class Solution {
    public int MinimumSwap(string s1, string s2) {
        int xy=0, yx=0, swaps=0;
        for(var i=0; i<s1.Length; i++){
            if(s1[i] == s2[i]) continue;    // we don't care about chars that already match
            
            if(s1[i] == 'x') xy++;
            else yx++;
        }

        if((xy+yx) % 2 == 1) return -1;   // we need xy+yx to be even number for ensuring success
        swaps = xy/2 + yx/2;            // case 1 + case 2
        if(xy % 2 == 1) swaps+=2;         // case 3

        return swaps;
    }
}
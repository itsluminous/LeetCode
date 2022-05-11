// 0 = a, 1 = e, 2 = i, 3 = o, 4 = u
public class Solution {
    int count = 0;
    
    public int CountVowelStrings(int n) {
        CountVowelStrings(n, 0);
        return count;
    }
    
    private void CountVowelStrings(int n, int prev){
        if(n == 0){
            count++;
            return;
        }
        
        for(var i=prev; i<5; i++)
            CountVowelStrings(n-1, i);
    }
}
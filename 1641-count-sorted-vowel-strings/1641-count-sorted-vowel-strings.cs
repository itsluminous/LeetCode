// Simply try to figure out how to place four separators inside result string
// all a's will be before 1st separator, b's before 2nd, c's before 3rd, d's before 4th and e's after 4th
// now it becomes a combination problem
// Not permutations because numbers need to be sorted, so we only count "112", not "121", "211".
public class Solution {
    public int CountVowelStrings(int n) {
        // formula for combination i.e. arranging k items in n set => (n+k-1)! / (n! * (k-1)!) 
        // in our case k = 5, so (n+4)! / (n! * 4!)  =  (n+4)*(n+3)*(n+2)*(n+1)* n! / (n! * 24)
        return (n+4)*(n+3)*(n+2)*(n+1) / 24;
    }
}

// Accepted - Backtracking
// 0 = a, 1 = e, 2 = i, 3 = o, 4 = u
public class Solution1 {
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
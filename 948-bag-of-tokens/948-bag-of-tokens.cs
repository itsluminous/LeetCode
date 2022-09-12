public class Solution {
    public int BagOfTokensScore(int[] tokens, int power) {
        Array.Sort(tokens);
        int n = tokens.Length, maxscore = 0, currscore = 0;
        for(int i=0,j=n-1; i<=j;){
            // while we have enough power, play the i-th token face up to get more score
            while(i <= j && power >= tokens[i]){
                power -= tokens[i++];
                currscore++;
                maxscore = Math.Max(currscore, maxscore);
            }
            
            if(i == j) break;           // we processed full array already
            if(currscore == 0) break;   // we cannot do any further transactions      
            
            // now play the j-th token face down to get power and lose a score
            power += tokens[j--];
            currscore--;
        }
        
        return maxscore;
    }
}
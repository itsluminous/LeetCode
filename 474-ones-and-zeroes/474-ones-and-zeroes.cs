// Copied

public class Solution {
    public int FindMaxForm(string[] strs, int maxZeros, int maxOnes) {
        int[,] dp = new int[maxZeros+1,maxOnes+1];
        int zeros,ones;
        for(int i=0;i<strs.Length;i++)
        {
            zeros = 0;
            for(int j=0;j<strs[i].Length;j++)
                if(strs[i][j]=='0')
                    zeros++;
            ones = strs[i].Length-zeros;
            
            for(int j=maxZeros;j>=zeros;j--)
                for(int k=maxOnes;k>=ones;k--)
                    dp[j,k]=Math.Max(dp[j,k],1+dp[j-zeros,k-ones]);
        }
        return dp[maxZeros,maxOnes];
    }
}
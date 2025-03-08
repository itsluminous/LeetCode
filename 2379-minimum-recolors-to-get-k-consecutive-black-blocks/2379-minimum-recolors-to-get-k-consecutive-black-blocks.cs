public class Solution {
    public int MinimumRecolors(string blocks, int k) {
        var currWhite = 0;
        for(var i=0; i<k; i++)
            if(blocks[i] == 'W') currWhite++;
        
        var minWhite = currWhite;
        for(int left = 0, right = k; right < blocks.Length; left++, right++){
            if(blocks[left] == 'W') currWhite--;
            if(blocks[right] == 'W') currWhite++;
            minWhite = Math.Min(minWhite, currWhite);
        }

        return minWhite;
    }
}
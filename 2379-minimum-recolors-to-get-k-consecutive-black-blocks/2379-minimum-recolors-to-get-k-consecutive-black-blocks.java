class Solution {
    public int minimumRecolors(String blocks, int k) {
        var currWhite = 0;
        for(var i=0; i<k; i++)
            if(blocks.charAt(i) == 'W') currWhite++;
        
        var minWhite = currWhite;
        for(int left = 0, right = k; right < blocks.length(); left++, right++){
            if(blocks.charAt(left) == 'W') currWhite--;
            if(blocks.charAt(right) == 'W') currWhite++;
            minWhite = Math.min(minWhite, currWhite);
        }

        return minWhite;
    }
}
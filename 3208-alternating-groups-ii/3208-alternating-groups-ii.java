class Solution {
    public int numberOfAlternatingGroups(int[] colors, int k) {
        int n = colors.length, ans = 0, same = 0;

        // count same adjacent colors in first k tiles
        for(var i=1; i<k; i++)
            if(colors[i] == colors[i-1]) same++;
        if(same == 0) ans++;

        // track same adjacent colors for each k window
        int lPrev = colors[0], rPrev = colors[k-1];
        for(int l=1, r=(l+k-1)%n; l < n; l++, r = (r+1)%n){
            if(colors[l] == lPrev) same--;
            if(colors[r] == rPrev) same++;
            if(same == 0) ans++;

            lPrev = colors[l];
            rPrev = colors[r];
        }

        return ans;
    }
}
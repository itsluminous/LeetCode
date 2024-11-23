public class Solution {
    public char[][] RotateTheBox(char[][] box) {
        int m = box.Length, n = box[0].Length;
        var ans = new char[n][];
        for(var i=0; i<n; i++) ans[i] = new char[m];

        for(var i=0; i<m; i++){
            int l=n-1, r=n-1;
            while(l >= 0){
                if(box[i][l] == '*'){
                    while(r > l)
                        ans[r--][m-i-1] = '.';
                    ans[r--][m-i-1] = '*';
                }
                else if(box[i][l] == '#')
                    ans[r--][m-i-1] = '#';
                l--;
            }

            while(r >= 0)
                ans[r--][m-i-1] = '.';
        }

        return ans;
    }
}
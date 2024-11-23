public class Solution {
    public char[][] RotateTheBox(char[][] box) {
        int m = box.Length, n = box[0].Length;
        var ans = new char[n][];
        for(var i=0; i<n; i++) ans[i] = new string('.', m).ToCharArray();

        for(var i=0; i<m; i++){
            var r=n-1;
            for(var l=n-1; l>=0; l--){
                if(box[i][l] == '*'){
                    // all cells till this point will be empty
                    r = l;
                    ans[r--][m-i-1] = '*';
                }
                else if(box[i][l] == '#')
                    // this stone should fall to rightmost possible idx
                    ans[r--][m-i-1] = '#';
            }
        }

        return ans;
    }
}
class Solution {
    public char[][] rotateTheBox(char[][] box) {
        int m = box.length, n = box[0].length;
        var ans = new char[n][m];

        for(var i=0; i<m; i++){
            var r=n-1;
            for(var l=n-1; l>=0; l--){
                if(box[i][l] == '*'){
                    // fill all cells till this point as empty
                    while(r > l)
                        ans[r--][m-i-1] = '.';
                    ans[r--][m-i-1] = '*';
                }
                else if(box[i][l] == '#')
                    // this stone should fall to rightmost possible idx
                    ans[r--][m-i-1] = '#';
            }

            // fill all left out cells with empty
            while(r >= 0)
                ans[r--][m-i-1] = '.';
        }

        return ans;
    }
}
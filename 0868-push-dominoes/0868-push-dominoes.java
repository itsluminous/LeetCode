class Solution {
    public String pushDominoes(String dominoes) {
        int n = dominoes.length(), l = 0;
        var ans = new StringBuilder(n);
        var lchar = '.'; // it can be '.' or 'R'
        
        for(var r=0; r<n; r++){
            // no action for just "."
            if(dominoes.charAt(r) == '.') continue;

            // if we encounter "R", then if l="R", then all followers will be "R", else all "."
            if(dominoes.charAt(r) == 'R'){
                for(var i=l; i<r; i++) ans.append(lchar);
                lchar = 'R';
                l = r;
            }

            // if we encounter "L" and l=".", then all dominoes between l and r will fall on left
            // if we encounter "L" and l="R", then dominoes will fall from both sides
            if(dominoes.charAt(r) == 'L'){
                if(lchar == '.'){
                    for(var i=l; i<=r; i++) ans.append('L');
                    l=r+1;
                }
                else {
                    var diff = (r - l + 1);
                    for(var i=0; i<diff/2; i++) ans.append('R');
                    if((diff & 1) == 1) ans.append('.');
                    for(var i=0; i<diff/2; i++) ans.append('L');

                    l=r+1;
                    lchar = '.';
                }
            }
        }

        // take care of remaining dominoes
        if(l < n)
            for(var i=l; i<n; i++) ans.append(lchar);

        return ans.toString();
    }
}
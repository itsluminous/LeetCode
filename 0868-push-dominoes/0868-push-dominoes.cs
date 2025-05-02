public class Solution {
    public string PushDominoes(string dominoes) {
        int n = dominoes.Length, l = 0;
        var ans = new StringBuilder(n);
        var lchar = '.'; // it can be '.' or 'R'

        for (var r = 0; r < n; r++) {
            // no action for just "."
            if (dominoes[r] == '.') continue;

            // if we encounter "R", then if l="R", then all followers will be "R", else all "."
            if (dominoes[r] == 'R') {
                for (var i = l; i < r; i++) ans.Append(lchar);
                lchar = 'R';
                l = r;
            }

            // if we encounter "L" and l=".", then all dominoes between l and r will fall on left
            // if we encounter "L" and l="R", then dominoes will fall from both sides
            if (dominoes[r] == 'L') {
                if (lchar == '.') {
                    for (var i = l; i <= r; i++) ans.Append('L');
                    l = r + 1;
                } else {
                    var diff = (r - l + 1);
                    for (var i = 0; i < diff / 2; i++) ans.Append('R');
                    if ((diff & 1) == 1) ans.Append('.');
                    for (var i = 0; i < diff / 2; i++) ans.Append('L');

                    l = r + 1;
                    lchar = '.';
                }
            }
        }

        // take care of remaining dominoes
        if (l < n)
            for (var i = l; i < n; i++) ans.Append(lchar);

        return ans.ToString();
    }
}
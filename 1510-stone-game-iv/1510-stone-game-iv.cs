public class Solution {
    public bool WinnerSquareGame(int n) {
        var dict = new Dictionary<int, bool>();
        dict[0] = false;    // any player having 0 tiles will lose
        return DFS(n, dict);
    }
    
    private bool DFS(int n, Dictionary<int, bool> dict) {
        if(dict.ContainsKey(n)) return dict[n];
        var sqrt = (int)Math.Sqrt(n);   // Math.Sqrt gives double by default, which will have decimal
        for(var i=sqrt; i>0; i--){
            var square = i*i;
            // if we can defeat other player after removing "square" tiles, then this player wins
            if(!DFS(n - square, dict)){
                dict[n] = true;
                return true;
            }
        }
        // if we reached this point, then current player must be loosing with n tiles.
        dict[n] = false;
        return false;
    }
}
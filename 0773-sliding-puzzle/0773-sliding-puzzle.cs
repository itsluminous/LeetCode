public class Solution {
    public int SlidingPuzzle(int[][] board) {
        var target = "123450";

        // convert board to 1D string
        var boardStr = new StringBuilder();
        for(var i=0; i<3; i++) boardStr.Append(board[0][i]);
        for(var i=0; i<3; i++) boardStr.Append(board[1][i]);

        // add curr board to queue and mark as visited
        var queue = new Queue<string>();
        queue.Enqueue(boardStr.ToString());

        var visited = new HashSet<string>();
        visited.Add(boardStr.ToString());

        // all positions that 0 can swap to (based on its idx)
        var dirs = new[] {
            new[] { 1, 3 },
            new[] { 0, 2, 4 },
            new[] { 1, 5 },
            new[] { 0, 4 },
            new[] { 1, 3, 5 },
            new[] { 2, 4 }
        };

        // bfs to find target
        for(var moves=0; queue.Count > 0; moves++){
            for(var i=queue.Count; i>0; i--){
                var state = queue.Dequeue();
                if(state == target) return moves;

                var zeroPos = state.IndexOf("0");
                foreach(var newPos in dirs[zeroPos]){
                    var next = Swap(state, zeroPos, newPos);
                    if(visited.Contains(next)) continue;
                    visited.Add(next);
                    queue.Enqueue(next);
                }
            }
        }

        return -1;
    }

    private string Swap(string str, int curr, int next){
        var chars = str.ToCharArray();
        (chars[curr], chars[next]) = (chars[next], chars[curr]);
        return new string(chars);
    }
}
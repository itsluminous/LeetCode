class Solution {
    public int slidingPuzzle(int[][] board) {
        var target = "123450";

        // convert board to 1D string
        var boardStr = new StringBuilder();
        for(var i=0; i<3; i++) boardStr.append(board[0][i]);
        for(var i=0; i<3; i++) boardStr.append(board[1][i]);

        // add curr board to queue and mark as visited
        Queue<String> queue = new LinkedList<>();
        queue.add(boardStr.toString());

        var visited = new HashSet<String>();
        visited.add(boardStr.toString());

        // all positions that 0 can swap to (based on its idx)
        var dirs = new int[][] {
            { 1, 3 },
            { 0, 2, 4 },
            { 1, 5 },
            { 0, 4 },
            { 1, 3, 5 },
            { 2, 4 },
        };

        // bfs to find target
        for(var moves=0; queue.size() > 0; moves++){
            for(var i=queue.size(); i>0; i--){
                var state = queue.poll();
                if(state.equals(target)) return moves;

                var zeroPos = state.indexOf("0");
                for(var newPos : dirs[zeroPos]){
                    var next = swap(state, zeroPos, newPos);
                    if(visited.contains(next)) continue;
                    visited.add(next);
                    queue.add(next);
                }
            }
        }

        return -1;
    }

    private String swap(String str, int curr, int next){
        var chars = str.toCharArray();
        var tmp = chars[curr];
        chars[curr] = chars[next];
        chars[next] = tmp;
        return new String(chars);
    }
}
class Solution {
    public int robotSim(int[] commands, int[][] obstacles) {
        var obs = new HashSet<String>();
        for(var ob : obstacles)
            obs.add(ob[0] + ":" + ob[1]);

        var dirs = new int[][]{{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
        int maxDist = 0, dirIdx = 0;
        int x = 0, y = 0;
        for(var cmd : commands){
            if(cmd == -1){
                dirIdx = (dirIdx + 1) % 4;
            }
            else if(cmd == -2){
                dirIdx--;
                if(dirIdx == -1) dirIdx = 3;
            }
            else{
                for(var i=0; i<cmd; i++){
                    int newX = x + dirs[dirIdx][0];
                    int newY = y + dirs[dirIdx][1];
                    if(obs.contains(newX + ":" + newY)) break;
                    x = newX;
                    y = newY;
                }
                var currDist = x*x + y*y;
                maxDist = Math.max(maxDist, currDist);
            }
        }

        return maxDist;
    }
}
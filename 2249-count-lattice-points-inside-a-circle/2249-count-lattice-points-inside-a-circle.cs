// Accepted - Brute force
public class Solution {
    public int CountLatticePoints(int[][] circles) {
        var points = new HashSet<string>();
        foreach(var c in circles){
            int x=c[0], y=c[1], r=c[2];
            for(var i=-r; i<=r; i++){
                for(var j=-r; j<=r; j++){
                    if(i*i + j*j <= r*r)
                        points.Add($"{x+i}:{y+j}");
                }
            }
        }
        return points.Count;
    }
}
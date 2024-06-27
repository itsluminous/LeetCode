// the center node is only node which has more than one edge
public class Solution {
    public int FindCenter(int[][] edges) {
        int[] first = edges[0], second = edges[1];
        if(first[0] == second[0] || first[0] == second[1]) return first[0];
        return first[1];
    }
}
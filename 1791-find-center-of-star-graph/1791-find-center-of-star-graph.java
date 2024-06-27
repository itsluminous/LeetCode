// the center node is only node which has more than one edge
class Solution {
    public int findCenter(int[][] edges) {
        int[] first = edges[0], second = edges[1];
        if(first[0] == second[0] || first[0] == second[1]) return first[0];
        return first[1];
    }
}

// Accepted : using hashmap to find the node with max edges
class SolutionHM {
    public int findCenter(int[][] edges) {
        int center = 0, centerEdges = 0;
        var connections = new HashMap<Integer, Integer>();
        for(var edge : edges){
            connections.put(edge[0], connections.getOrDefault(edge[0], 0) + 1);
            connections.put(edge[1], connections.getOrDefault(edge[1], 0) + 1);
            
            if(centerEdges < connections.get(edge[0])){
                center = edge[0];
                centerEdges = connections.get(edge[0]);
            }

            if(centerEdges < connections.get(edge[1])){
                center = edge[1];
                centerEdges = connections.get(edge[1]);
            }
        }

        return center;
    }
}
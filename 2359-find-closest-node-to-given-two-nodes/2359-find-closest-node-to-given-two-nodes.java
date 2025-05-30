class Solution {
    public int closestMeetingNode(int[] edges, int node1, int node2) {
        var n = edges.length;
        int[] dist1 = new int[n], dist2 = new int[n];
        Arrays.fill(dist1, -1);
        Arrays.fill(dist2, -1);

        // now find out center node's distance
        var currDist = 0; 
        int minDist = Integer.MAX_VALUE, minNode = -1;
        while(node1 != -1 || node2 != -1){
            // check if already visited
            var visited = true;
            if(node1 != -1 && dist1[node1] == -1) visited = false;
            if(node2 != -1 && dist2[node2] == -1) visited = false;
            if(visited) break;

            if(node1 != -1) dist1[node1] = currDist;
            if(node2 != -1) dist2[node2] = currDist;

            if(node1 != -1 && dist2[node1] != -1 && minDist >= Math.max(dist2[node1], dist1[node1])){
                var newDist = Math.max(dist2[node1], dist1[node1]);
                if(newDist == minDist) minNode = Math.min(minNode, node1);
                else minNode = node1;
                minDist = newDist;
            }
            if(node2 != -1 && dist1[node2] != -1 && minDist >= Math.max(dist1[node2], dist2[node2])){
                var newDist = Math.max(dist1[node2], dist2[node2]);
                if(newDist == minDist) minNode = Math.min(minNode, node2);
                else minNode = node2;
                minDist = newDist;
            }
            if(minNode != -1) return minNode;
            
            // prepare for next iteration
            currDist++;
            if(node1 != -1) node1 = edges[node1];
            if(node2 != -1) node2 = edges[node2];
        }

        return -1;
    }
}
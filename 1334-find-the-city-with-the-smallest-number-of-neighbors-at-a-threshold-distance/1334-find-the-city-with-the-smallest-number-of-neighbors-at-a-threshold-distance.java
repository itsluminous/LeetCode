class Solution {
    public int findTheCity(int n, int[][] edges, int distanceThreshold) {
        var INF = (int) 1e9 + 7;
        var shortestPaths = new int[n][n];
        for(var i=0; i<n; i++){
            Arrays.fill(shortestPaths[i], INF);
            shortestPaths[i][i] = 0;
        }

        for(var edge : edges){
            int city1 = edge[0], city2 = edge[1], weight = edge[2];
            if(weight > distanceThreshold) continue;
            shortestPaths[city1][city2] = weight;
            shortestPaths[city2][city1] = weight;
        }

        floyd(n, shortestPaths);
        return cityWithFewestReachable(n, shortestPaths, distanceThreshold);
    }

    private int cityWithFewestReachable(int n, int[][] shortestPaths, int distanceThreshold){
        int city = -1, nbrCount = n;

        for(var i=0; i<n; i++){
            var reachableCount = 0;
            for(var j=0; j<n; j++){
                if(i == j) continue;
                if(shortestPaths[i][j] <= distanceThreshold) reachableCount++;
            }

            if(reachableCount <= nbrCount){
                nbrCount = reachableCount;
                city = i;
            }
        }

        return city;
    }

    private void floyd(int n, int[][] shortestPaths){
        for(var k=0; k<n; k++){
            for(var i=0; i<n; i++){
                for(var j=0; j<n; j++){
                    shortestPaths[i][j] = Math.min(shortestPaths[i][j], 
                                                    shortestPaths[i][k] + shortestPaths[k][j]);
                }
            }
        }
    }
}

// Accepted - Dijkastra
class SolutionDijkastra {
    public int findTheCity(int n, int[][] edges, int distanceThreshold) {
        var graph = buildAdjList(n, edges, distanceThreshold);

        var shortestPaths = new int[n][n];
        for(var i=0; i<n; i++){
            Arrays.fill(shortestPaths[i], Integer.MAX_VALUE);
            shortestPaths[i][i] = 0;
            dijkastra(graph, shortestPaths[i], i);
        }

        return cityWithFewestReachable(n, shortestPaths, distanceThreshold);
    }

    private int cityWithFewestReachable(int n, int[][] shortestPaths, int distanceThreshold){
        int city = -1, nbrCount = n;

        for(var i=0; i<n; i++){
            var reachableCount = 0;
            for(var j=0; j<n; j++){
                if(i == j) continue;
                if(shortestPaths[i][j] <= distanceThreshold) reachableCount++;
            }

            if(reachableCount <= nbrCount){
                nbrCount = reachableCount;
                city = i;
            }
        }

        return city;
    }

    private void dijkastra(List<int[]>[] graph, int[] shortestPath, int src){
        PriorityQueue<int[]> pq = new PriorityQueue<>(Comparator.comparingInt(a -> a[1]));
        pq.add(new int[]{src, 0});

        while(!pq.isEmpty()){
            var curr = pq.remove();
            int currCity = curr[0], currDist = curr[1];
            if(currDist > shortestPath[currCity]) continue;

            for(var nbr : graph[currCity]){
                int nbrCity = nbr[0], nbrDist = nbr[1];
                if(shortestPath[nbrCity] <= currDist + nbrDist) continue;
                shortestPath[nbrCity] = currDist + nbrDist;
                pq.add(new int[]{nbrCity, shortestPath[nbrCity]});
            }
        }
    }

    private List<int[]>[] buildAdjList(int n, int[][] edges, int distanceThreshold){
        List<int[]>[] graph = new List[n];
        for(var i=0; i<n; i++) graph[i] = new ArrayList<int[]>();

        for(var edge : edges){
            int city1 = edge[0], city2 = edge[1], weight = edge[2];
            if(weight > distanceThreshold) continue;
            graph[city1].add(new int[]{city2, weight});
            graph[city2].add(new int[]{city1, weight});
        }

        return graph;
    }
}
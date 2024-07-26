public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        var graph = BuildAdjList(n, edges, distanceThreshold);

        var shortestPaths = new int[n][];
        for(var i=0; i<n; i++){
            shortestPaths[i] = new int[n];
            for(var j=0; j<n; j++)
                shortestPaths[i][j] = int.MaxValue;
            shortestPaths[i][i] = 0;
            Dijstra(graph, shortestPaths[i], i);
        }

        return CityWithFewestReachable(n, shortestPaths, distanceThreshold);
    }

    private int CityWithFewestReachable(int n, int[][] shortestPaths, int distanceThreshold){
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

    private void Dijstra(List<int[]>[] graph, int[] shortestPath, int src){
        var pq = new PriorityQueue<int[], int>();
        pq.Enqueue([src, 0], 0);

        while(pq.Count > 0){
            var curr = pq.Dequeue();
            var (currCity, currDist) = (curr[0], curr[1]);
            if(currDist > shortestPath[currCity]) continue;

            foreach(var nbr in graph[currCity]){
                var (nbrCity, nbrDist) = (nbr[0], nbr[1]);
                if(shortestPath[nbrCity] <= currDist + nbrDist) continue;
                shortestPath[nbrCity] = currDist + nbrDist;
                pq.Enqueue([nbrCity, shortestPath[nbrCity]], shortestPath[nbrCity]);
            }
        }
    }

    private List<int[]>[] BuildAdjList(int n, int[][] edges, int distanceThreshold){
        var graph = new List<int[]>[n];
        for(var i=0; i<n; i++) graph[i] = new List<int[]>();

        foreach(var edge in edges){
            var (city1, city2, weight) = (edge[0], edge[1], edge[2]);
            if(weight > distanceThreshold) continue;
            graph[city1].Add([city2, weight]);
            graph[city2].Add([city1, weight]);
        }

        return graph;
    }
}
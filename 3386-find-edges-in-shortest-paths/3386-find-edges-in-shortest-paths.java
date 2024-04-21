public class Solution {
    public boolean[] findAnswer(int n, int[][] edges) {
        List<Pair<Integer, Integer>>[] graph = edgesToGraph(n, edges);
        HashSet<Pair<Integer, Integer>> shortestPathEdges = dijkstra(graph);
        
        // now check which edges are part of the shortest path
        boolean[] ans = new boolean[edges.length];
        for(int i = 0; i < edges.length; i++) {
            int s = edges[i][0], d = edges[i][1];
            if(shortestPathEdges.contains(new Pair<>(s, d)) || shortestPathEdges.contains(new Pair<>(d, s))) {
                ans[i] = true;
            }
        }
        
        return ans;
    }

    // function to covert edges to adjacency list
    private List<Pair<Integer, Integer>>[] edgesToGraph(int n, int[][] edges) {
        List<Pair<Integer, Integer>>[] graph = new List[n];
        for(int i = 0; i < n; i++) graph[i] = new ArrayList<>();

        for(int[] edge : edges) {
            int s = edge[0], d = edge[1], w = edge[2];
            graph[s].add(new Pair<>(d, w));
            graph[d].add(new Pair<>(s, w));
        }

        return graph;
    }

    // function to find shortest distance to reach each node
    private HashSet<Pair<Integer, Integer>> dijkstra(List<Pair<Integer, Integer>>[] graph) {
        int n = graph.length;
        
        // shortest distance to reach each node
        int[] shortestDist = new int[n];
        Arrays.fill(shortestDist, Integer.MAX_VALUE);
        shortestDist[0] = 0;    // can reach node 0 in 0 distance, because we start from there

        PriorityQueue<Pair<Integer, Integer>> pq = new PriorityQueue<>(Comparator.comparingInt(Pair::getValue));
        pq.offer(new Pair<>(0, 0)); // Starting from node 0 with distance 0

        // use Dijkstra to find shortest weight for reaching each node
        while (!pq.isEmpty()) {
            Pair<Integer, Integer> pair = pq.poll();
            int node = pair.getKey(), dist = pair.getValue();

            if(dist > shortestDist[node]) continue;
            for (Pair<Integer, Integer> p : graph[node]) {
                int neighbor = p.getKey(), weight = p.getValue();
                if(shortestDist[node] + weight >= shortestDist[neighbor]) continue;
                shortestDist[neighbor] = shortestDist[node] + weight;
                pq.offer(new Pair<>(neighbor, shortestDist[neighbor]));
            }
        }

        // starting from last node, find the shortest routes to reach node 0
        HashSet<Pair<Integer, Integer>> shortestPathEdges = new HashSet<>();
        Queue<Integer> queue = new LinkedList<>();
        queue.offer(n - 1);
        while (!queue.isEmpty()) {
            int node = queue.poll();
            for (Pair<Integer, Integer> p : graph[node]) {
                int neighbor = p.getKey();
                int weight = p.getValue();
                if(shortestDist[node] - weight == shortestDist[neighbor]){
                    shortestPathEdges.add(new Pair<>(node, neighbor));
                    queue.offer(neighbor);
                }
            }
        }

        return shortestPathEdges;
    }
    
    static class Pair<K, V> {
        private final K key;
        private final V value;

        public Pair(K key, V value) {
            this.key = key;
            this.value = value;
        }

        public K getKey() {
            return key;
        }

        public V getValue() {
            return value;
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;
            Pair<?, ?> pair = (Pair<?, ?>) o;
            return Objects.equals(key, pair.key) && Objects.equals(value, pair.value);
        }

        @Override
        public int hashCode() {
            return Objects.hash(key, value);
        }
    }
}

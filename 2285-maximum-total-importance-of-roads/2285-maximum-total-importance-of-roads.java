class Solution {
    public long maximumImportance(int n, int[][] roads) {
        // count connections for each city
        var connections = new long[n];
        for(var road : roads){
            connections[road[0]]++;
            connections[road[1]]++;
        }

        Arrays.sort(connections);

        // assign importance. the city with lowest connections will have lowest importance
        long imp = 1, total = 0;
        for(var conn : connections){
            total += (conn * imp);
            imp++;
        }

        return total;
    }
}

// Accepted : too complex
class SolutionComplex {
    public long maximumImportance(int n, int[][] roads) {
        var adjList = new HashMap<Integer, List<Integer>>();
        for(var i=0; i<n; i++)
            adjList.put(i, new ArrayList<>());

        // build un-directed adjacency list
        for(var road : roads){
            adjList.get(road[0]).add(road[1]);
            adjList.get(road[1]).add(road[0]);
        }

        // priority queue to sort hashmap based on count of connections of each node
        var pq = new PriorityQueue<Map.Entry<Integer, List<Integer>>>(
            (kv1, kv2) -> kv1.getValue().size() - kv2.getValue().size());
        for(var entry : adjList.entrySet())
            pq.offer(entry);

        // assign importance. the city with lowest roads will have lowest importance
        var importance = new long[n];
        long imp = 1;
        while(!pq.isEmpty()){
            var city = pq.poll().getKey();
            importance[city] = imp;
            imp++;
        }

        // calculate total importance;
        long total = 0;
        for(var road : roads)
            total += importance[road[0]] + importance[road[1]];

        return total;
    }
}
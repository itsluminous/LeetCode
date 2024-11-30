class Solution {
    List<int[]> path = new ArrayList<>();

    public int[][] validArrangement(int[][] pairs) {
        // create graph, and count in & out degree
        // degree[i]++ if there is out degree, and degree[i]-- when there is in degree
        // this way we don't need to use two arrays to track in & out degree
        var degree = new HashMap<Integer, Integer>();
        var adjList = new HashMap<Integer, List<Integer>>();
        for(var pair : pairs){
            int src = pair[0], dest = pair[1];
            adjList.computeIfAbsent(src, k -> new ArrayList<>()).add(dest);

            degree.put(src, degree.getOrDefault(src, 0) + 1);
            degree.put(dest, degree.getOrDefault(dest, 0) - 1);
        }

        // find out a node which has degree = 1, because this would be starting point
        // this is an Eulerian trail i.e. one of the nodes which does not complete cycle in Eulerian path
        // if there is no such node, then it is a circular graph, and we can pick any start
        var start = pairs[0][0];
        for(var node : degree.keySet()){
            if(degree.get(node) == 1){
                start = node;
                break;
            }
        }

        // traverse DFS from "start" to complete the path
        // Hierholzer's Algorithm
        dfs(adjList, start);
        
        // dfs will fill up path in reverse order
        Collections.reverse(path);
        return path.toArray(new int[path.size()][]);
    }

    private void dfs(Map<Integer, List<Integer>> adjList, int start){
        if(!adjList.containsKey(start)) return;
        
        var connections = adjList.get(start);
        while(!connections.isEmpty()){
            var next = connections.remove(0);
            dfs(adjList, next);
            
            // Ideally we insert at beginning so that we don't do reverse later, but that gives TLE
            // Other option is to use stack for connections, instead of a list
            path.add(new int[]{start, next});
        }
    }
}
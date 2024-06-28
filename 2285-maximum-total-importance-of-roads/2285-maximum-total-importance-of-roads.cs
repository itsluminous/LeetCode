public class Solution {
    public long MaximumImportance(int n, int[][] roads) {
        // count connections for each city
        var connections = new long[n];
        foreach(var road in roads){
            connections[road[0]]++;
            connections[road[1]]++;
        }

        Array.Sort(connections);

        // assign importance. the city with lowest connections will have lowest importance
        long imp = 1, total = 0;
        foreach(var conn in connections){
            total += (conn * imp);
            imp++;
        }

        return total;
    }
}
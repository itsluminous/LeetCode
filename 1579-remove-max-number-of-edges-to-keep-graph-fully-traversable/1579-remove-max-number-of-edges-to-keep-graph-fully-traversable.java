class Solution {
    public int maxNumEdgesToRemove(int n, int[][] edges) {
        Arrays.sort(edges, (e1, e2) -> e2[0] - e1[0]);  // sort desc based on type

        var removed = 0;
        var alice = new UnionFind(n); 
        var bob = new UnionFind(n);

        // add all common nodes first - to both alice & bob network
        for(var edge : edges){
            // add to both alice & bob's network
            if(edge[0] == 3){
                // if we can add in alice's network without duplicating connection, then bob will also work fine
                if(alice.union(edge[1], edge[2]))
                    bob.union(edge[1], edge[2]);
                else
                    removed++;
            }
            // add edge to alice's network
            else if(edge[0] == 1){   
                // if adding this edge to alice's network is reduntant, then it can be removed
                if(!alice.union(edge[1], edge[2]))
                    removed++;
            }
            // add edge to bob's network
            else if(edge[0] == 2){   
                // if adding this edge to bob's network is reduntant, then it can be removed
                if(!bob.union(edge[1], edge[2]))
                    removed++;
            }
        }

        if(!alice.allConnected() || !bob.allConnected()) return -1;
        return removed;
    }
}

class UnionFind {
    int[] parent;
    int[] size;     // compute size of each UF set to later check if all are connected

    public UnionFind(int n){
        parent = new int[n+1];  // nodes are 1-indexed
        size = new int[n+1];
        for(var i=0; i<=n; i++){
            parent[i] = i;  // all are self parent initially
            size[i] = 1;
        }
    }

    public boolean union(int node1, int node2){
        var p1 = find(node1);
        var p2 = find(node2);
        if(p1 == p2) return false;  // no new connection needed

        if(size[p1] < size[p2]){
            parent[p1] = p2;
            size[p2] += size[p1];
        }
        else{
            parent[p2] = p1;
            size[p1] += size[p2];
        }
        return true;  // new connection added
    } 

    public int find(int node){
        if(parent[node] == node) return node;
        return find(parent[node]);
    }

    public boolean allConnected(){
        var root = find(1);
        return size[root] == parent.length - 1;
    }
}
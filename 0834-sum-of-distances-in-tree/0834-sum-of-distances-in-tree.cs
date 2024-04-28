public class Solution {
    List<int>[] tree;   // adjacency list
    int[] ans;          // the array which will have sum value at each node
    int[] count;        // count of nodes in that node's subtree, including that node itself

    public int[] SumOfDistancesInTree(int n, int[][] edges) {
        tree = EdgesToTree(n, edges);
        ans = new int[n];
        count = new int[n]; 

        // at the end of PostOrder, the topmost node will have the right answer
        PostOrder(0, -1);
        // now using topmost node's answer, find ans for all it's children
        PreOrder(0, -1);
        return ans;
    }

    private void PostOrder(int root, int prev){
        foreach(var next in tree[root]){
            if(next == prev) continue;
            PostOrder(next, root);
            // count of nodes in root's subtree = count of nodes in subtree1 + subtree2... + 1 (self)
            count[root] += count[next];    
            ans[root] += ans[next] + count[next]; 
        }
        count[root]++;  // the current root node is also part of the subtree
    }

    private void PreOrder(int root, int prev){
        foreach(var next in tree[root]){
            if(next == prev) continue;
            // every time we go down in a subtree, then
            // ans[i] = ans[parent] - nodes in curr subtree (because they are getting closer) + all other nodes (because they will get farther)
            ans[next] = ans[root] - count[next] + (tree.Length - count[next]);
            PreOrder(next, root);
        }
    }

    private List<int>[] EdgesToTree(int n, int[][] edges){
        var tree = new List<int>[n];
        for(var i=0; i<n; i++) tree[i] = new List<int>();

        foreach(var edge in edges){
            var (s, d) = (edge[0], edge[1]);
            tree[s].Add(d);
            tree[d].Add(s);
        }

        return tree;
    }
}
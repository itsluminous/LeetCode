// Intro to union find : https://www.youtube.com/watch?v=ibjEGG7ylHk
public class Solution {
    public bool[] FriendRequests(int n, int[][] restrictions, int[][] requests) {
        var uf = new UnionFind(n);
        var result = new bool[requests.Length];
        var resultIdx = 0;
        
        foreach(var req in requests){
            // find parent node of two friends we are about to connect
            int f1 = uf.Find(req[0]), f2 = uf.Find(req[1]);
            var success = true;
            // if two friends are not already connected, check validity
            if(!uf.Connected(f1, f2)){
                foreach(var ban in restrictions){
                    // find parent nodes of two people banned from friendship
                    int b1 = uf.Find(ban[0]), b2 = uf.Find(ban[1]);
                    // if the two parents of friends are same as two parents of bans
                    if((f1 == b1 && f2 == b2) || (f1 == b2 && f2 == b1)){
                        success = false;
                        break;
                    }
                }
            }
            
            if(success) uf.Union(f1, f2);
            result[resultIdx++] = success;
        }
        
        return result;
    }
}

public class UnionFind{
    int[] id;
    
    public UnionFind(int n){
        id = new int[n];
        for(int i=0; i<n; i++)
            id[i] = i;  // all are self parent initially
    }
    
    public int Find(int f){
        if(id[f] != f)
            id[f] = Find(id[f]);
        return id[f];
    }
    
    public void Union(int f1, int f2){
        var f1_p = Find(f1);
        var f2_p = Find(f2);
        id[f1_p] = id[f2_p];    // ideally we should check which one is small and change their parent
    }
    
    public bool Connected(int f1, int f2){
        return Find(f1) == Find(f2);
    }
}
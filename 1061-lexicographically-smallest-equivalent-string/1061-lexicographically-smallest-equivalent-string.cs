public class Solution {
    public string SmallestEquivalentString(string s1, string s2, string baseStr) {
        var uf = new UnionFind();
        for(var i=0; i < s1.Length; i++)
            uf.Union(s1[i], s2[i]);
        
        var ans = new StringBuilder();
        foreach(var ch in baseStr)
            ans.Append(uf.Find(ch));
        
        return ans.ToString();
    }
}

class UnionFind{
    char[] parent;

    public UnionFind(){
        parent = new char[123]; // ascii of z is 122
        for(var ch='a'; ch<='z'; ch++)
            parent[ch] = ch;
    }

    public char Find(char ch){
        if(parent[ch] == ch) return ch;
        parent[ch] = Find(parent[ch]);  // path compression
        return parent[ch];
    }

    public void Union(char a, char b){
        // find parent of a and b
        var pa = Find(a);
        var pb = Find(b);

        // if both nodes are already connected
        if(pa == pb) return;

        // keep smaller char as parent
        if(pa < pb) parent[pb] = pa;
        else parent[pa] = pb;
    }
}
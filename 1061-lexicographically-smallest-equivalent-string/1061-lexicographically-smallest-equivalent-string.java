class Solution {
    public String smallestEquivalentString(String s1, String s2, String baseStr) {
        var uf = new UnionFind();
        for(var i=0; i < s1.length(); i++)
            uf.union(s1.charAt(i), s2.charAt(i));
        
        var ans = new StringBuilder();
        for(var ch : baseStr.toCharArray())
            ans.append(uf.find(ch));
        
        return ans.toString();
    }
}

class UnionFind{
    char[] parent;

    public UnionFind(){
        parent = new char[123]; // ascii of z is 122
        for(var ch='a'; ch<='z'; ch++)
            parent[ch] = ch;
    }

    public char find(char ch){
        if(parent[ch] == ch) return ch;
        parent[ch] = find(parent[ch]);  // path compression
        return parent[ch];
    }

    public void union(char a, char b){
        // find parent of a and b
        var pa = find(a);
        var pb = find(b);

        // if both nodes are already connected
        if(pa == pb) return;

        // keep smaller char as parent
        if(pa < pb) parent[pb] = pa;
        else parent[pa] = pb;
    }
}
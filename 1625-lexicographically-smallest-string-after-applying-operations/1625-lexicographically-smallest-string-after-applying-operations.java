class Solution {
    Set<String> seen = new HashSet<>();
    String ans;

    public String findLexSmallestString(String s, int a, int b) {
        ans = s;
        dfs(s, a, b);
        return ans;
    }

    private void dfs(String s, int a, int b){
        if(seen.contains(s)) return;
        if(ans.compareTo(s) > 0) ans = s;
        seen.add(s);
        dfs(add(s, a), a, b);
        dfs(rotate(s, b), a, b);
    }

    private String add(String s, int a){
        var sb = new StringBuilder();
        for(var i=0; i<s.length(); i++){
            if((i & 1) == 0) sb.append(s.charAt(i));
            else sb.append((s.charAt(i) - '0' + a) % 10);
        }
        return sb.toString();
    }

    private String rotate(String s, int b){
        var n = s.length();
        return s.substring(n-b, n) + s.substring(0, n-b);
    }
}
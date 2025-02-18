// https://leetcode.com/problems/construct-smallest-number-from-di-string/solutions/2422380/java-c-python-easy-reverse/
// Using stack - O(N)
class Solution {
    public String smallestNumber(String pattern) {
        var n = pattern.length();
        var num = new StringBuilder();
        var stack = new StringBuilder();

        for(var i=0; i<=n; i++){
            stack.append((char) 1 + i);
            if(i == n || pattern.charAt(i) == 'I'){
                num.append(stack.reverse());
                stack = new StringBuilder();
            }
        }

        return num.toString();
    }
}

// Accepted - Backtracking - O(9! * N)
class SolutionBT {
    StringBuilder num;
    boolean[] visited;

    public String smallestNumber(String pattern) {
        num = new StringBuilder();
        visited = new boolean[100];

        for(var curr='1'; curr<='9'; curr++){
            num.append(curr);
            visited[curr] = true;
            var possible = canBuildNum(pattern, 0);
            if(possible) return num.toString();
            visited[curr] = false;
            num = new StringBuilder();
        }

        return "";  // unreachable
    }

    public boolean canBuildNum(String pattern, int idx) {
        if(num.length() == pattern.length() + 1)
            return true;
        
        var prev = num.charAt(num.length() - 1);
        var dir = pattern.charAt(idx);

        for(var curr='1'; curr<='9'; curr++){
            if(visited[curr]) continue;
            if(dir == 'I' && curr - prev < 0) continue;
            if(dir == 'D' && curr - prev > 0) continue;
            
            // backtrack
            num.append(curr);
            visited[curr] = true;
            var possible = canBuildNum(pattern, idx+1);
            if(possible) return true;
            visited[curr] = false;
            num.deleteCharAt(num.length() - 1);
        }

        return false;
    }
}
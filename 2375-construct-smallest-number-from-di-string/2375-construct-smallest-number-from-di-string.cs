// https://leetcode.com/problems/construct-smallest-number-from-di-string/solutions/2422380/java-c-python-easy-reverse/
// Using stack - O(N)
public class Solution {
    public string SmallestNumber(string pattern) {
        var n = pattern.Length;
        var num = new StringBuilder();
        var stack = new StringBuilder();

        for(var i=0; i<=n; i++){
            stack.Append((char) 1 + i);
            if(i == n || pattern[i] == 'I'){
                num.Append(stack.ToString().Reverse().ToArray());
                stack.Clear();
            }
        }

        return num.ToString();
    }
}

// Accepted - Backtracking - O(9! * N)
public class SolutionBT {
    StringBuilder num;
    bool[] visited;

    public string SmallestNumber(string pattern) {
        num = new StringBuilder();
        visited = new bool[100];

        for(var curr='1'; curr<='9'; curr++){
            num.Append(curr);
            visited[curr] = true;
            var possible = CanBuildNum(pattern, 0);
            if(possible) return num.ToString();
            visited[curr] = false;
            num = new StringBuilder();
        }

        return "";  // unreachable
    }

    public bool CanBuildNum(String pattern, int idx) {
        if(num.Length == pattern.Length + 1)
            return true;
        
        var prev = num[num.Length - 1];
        var dir = pattern[idx];

        for(var curr='1'; curr<='9'; curr++){
            if(visited[curr]) continue;
            if(dir == 'I' && curr - prev < 0) continue;
            if(dir == 'D' && curr - prev > 0) continue;
            
            // backtrack
            num.Append(curr);
            visited[curr] = true;
            var possible = CanBuildNum(pattern, idx+1);
            if(possible) return true;
            visited[curr] = false;
            num.Length--;
        }

        return false;
    }
}
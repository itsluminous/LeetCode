public class Solution {
    public int[] AssignElements(int[] groups, int[] elements) {
        int g = groups.Length, e = elements.Length;
        var factorMap = new Dictionary<int, int>();

        for(var i = 0; i < e; i++) {
            var elem = elements[i];
            if(factorMap.ContainsKey(elem)) continue;
            factorMap[elem] = i;
        }
        
        for(var i=0; i<g; i++)
            groups[i] = FindIndex(groups[i], factorMap);

        return groups;
    }

    private int FindIndex(int num, Dictionary<int, int> map){
        var max = 1_00_001;
        var ans = max;
        
        // find all factors of num, and check which one exists in map
        for(var i=1; i*i <= num; i++){
            if(num % i == 0){
                if(map.ContainsKey(i))
                     ans = Math.Min(ans, map[i]);
                if(i != num/i && map.ContainsKey(num/i))
                    ans = Math.Min(ans, map[num/i]);
            }
        }

        if(ans == max) return -1;
        return ans;
    }
}

// Accepted
public class SolutionMeh {
    public int[] AssignElements(int[] groups, int[] elements) {
        int g = groups.Length, e = elements.Length;
        var factorMap = new Dictionary<int, int>();
        var max = 1_00_000;

        for(var i = 0; i < e; i++) {
            var elem = elements[i];
            if(factorMap.ContainsKey(elem)) continue;
            for(var f = 1; f * elem <= max; f++) {
                var num = f * elem;
                if(!factorMap.ContainsKey(num)) factorMap[num] = i;
            }
        }
        
        for(var i=0; i<g; i++)
            groups[i] = factorMap.ContainsKey(groups[i]) ? factorMap[groups[i]] : -1;
        return groups;
    }
}
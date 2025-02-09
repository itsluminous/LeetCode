class Solution {
    public int[] assignElements(int[] groups, int[] elements) {
        int g = groups.length, e = elements.length;
        var factorMap = new HashMap<Integer, Integer>();

        for(var i = 0; i < e; i++) {
            var elem = elements[i];
            if(factorMap.containsKey(elem)) continue;
            factorMap.put(elem, i);
        }
        
        for(var i=0; i<g; i++)
            groups[i] = findIndex(groups[i], factorMap);

        return groups;
    }

    private int findIndex(int num, Map<Integer, Integer> map){
        var max = 1_00_001;
        var ans = max;
        
        // find all factors of num, and check which one exists in map
        for(var i=1; i*i <= num; i++){
            if(num % i == 0){
                if(map.containsKey(i))
                     ans = Math.min(ans, map.get(i));
                if(i != num/i && map.containsKey(num/i))
                    ans = Math.min(ans, map.get(num/i));
            }
        }

        if(ans == max) return -1;
        return ans;
    }
}
public class Solution {
    public int romanToInt(String s) {
        Map<Character, Integer> map = Map.of(
            'I', 1, 'V', 5, 'X', 10, 'L', 50,
            'C', 100, 'D', 500, 'M', 1000
        );

        int n = s.length(), ans = 0;
        var chars = s.toCharArray();
        for(var i=0; i<n-1; i++){
            char curr = chars[i], next = chars[i+1];
            if(map.get(curr) < map.get(next))
                ans -= map.get(curr);
            else 
                ans += map.get(curr);
        }

        return ans + map.get(chars[n-1]);
    }
}
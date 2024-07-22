class Solution {
    public String[] sortPeople(String[] names, int[] heights) {
        var n = names.length;
        var map = new HashMap<Integer, String>();
        for(var i=0; i<n; i++)
            map.put(heights[i], names[i]);
        
        Arrays.sort(heights);
        for(int i=n-1, j=0; i >= 0; i--, j++)
            names[j] = map.get(heights[i]);
        
        return names;
    }
}
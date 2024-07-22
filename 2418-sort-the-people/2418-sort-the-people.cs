public class Solution {
    public string[] SortPeople(string[] names, int[] heights) {
        var n = names.Length;
        var dict = new Dictionary<int, string>();
        for(var i=0; i<n; i++)
            dict[heights[i]] = names[i];
        
        Array.Sort(heights, (h1, h2) => h2 - h1);
        for(var i=0; i < n; i++)
            names[i] = dict[heights[i]];
        
        return names;
    }
}
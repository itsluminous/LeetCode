public class Solution {
    public int[][] ReconstructQueue(int[][] people) {
        var sorted = people.OrderByDescending(p => p[0]).ThenBy(p => p[1]);
        
        var result = new List<int[]>();
        foreach(var person in sorted)
            result.Insert(person[1], person);
        
        return result.ToArray();
    }
}
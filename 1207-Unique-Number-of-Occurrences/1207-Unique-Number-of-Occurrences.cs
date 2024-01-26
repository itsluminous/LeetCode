// Using Dictionary and HashSet
public class Solution {
    public bool UniqueOccurrences(int[] arr) {
        var count = new Dictionary<int,int>();
        foreach(var num in arr)
            if(count.ContainsKey(num)) count[num]++;
            else count[num] = 1;

        var set = new HashSet<int>();
        foreach(var val in count.Values)
            if(val != 0 && !set.Add(val))
                return false;

        return true;
    }
}

// Accepted - Using Array and HashSet
public class SolutionArr {
    public bool UniqueOccurrences(int[] arr) {
        const int MAX = 2002;
        var count = new int[MAX];
        foreach(var num in arr) count[num+1000]++;

        var set = new HashSet<int>();
        foreach(var val in count)
            if(val != 0 && !set.Add(val))
                return false;

        return true;
    }
}
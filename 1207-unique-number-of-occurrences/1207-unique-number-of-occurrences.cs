public class Solution {
    public bool UniqueOccurrences(int[] arr) {
        var dict = new Dictionary<int, int>();
        foreach(var num in arr)
            if(dict.ContainsKey(num)) dict[num]++;
            else dict[num] = 1;

        var allFreq = dict.Values;
        var distinct = allFreq.Distinct().ToList();

        return allFreq.Count == distinct.Count;
    }
}
public class Solution {
    public boolean uniqueOccurrences(int[] arr) {
        var map = new HashMap<Integer, Integer>();
        for(var num : arr)
            map.put(num, map.getOrDefault(num, 0) + 1);

        var allFreq = map.values();
        var distinct = allFreq.stream().distinct();

        return allFreq.size() == distinct.count();
    }
}
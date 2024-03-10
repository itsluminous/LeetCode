// using single dictionary (array)
public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        var freq = new bool[1001];
        foreach(var num in nums1) freq[num] = true;

        var ans = new List<int>();
        foreach(var num in nums2){
            if(freq[num]){
                freq[num] = false;
                ans.Add(num);
            }
        }

        return [..ans];    
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#range-operator-
    }
}

// Accepted
public class SolutionSet {
    public int[] Intersection(int[] nums1, int[] nums2) {
        HashSet<int> set1 = new HashSet<int>(), set2 = new HashSet<int>();
        foreach(var num in nums1) set1.Add(num);
        foreach(var num in nums2) set2.Add(num);

        var ans = new List<int>();
        foreach(var num in set2){
            if(set1.Contains(num)) ans.Add(num);
        }
        return [.. ans];    // same as ans.ToArray()
    }
}
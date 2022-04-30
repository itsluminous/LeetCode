// Better time complexity
public class Solution {
    public IList<int> Intersection(int[][] nums) {
        var n = nums.Length;
        var count  = new int[1001];
        var result = new List<int>();
        
        // check number of occurence of each digit in all nums
        foreach(var num in nums)
            foreach(var i in num)
                count[i]++;
        
        // any num which has count equal to n is present in all nums array
        for(var i=0; i<count.Length; i++)
           if(count[i] == n)
               result.Add(i);
        
        return result;
    }
}

// Accepted
public class Solution1 {
    public IList<int> Intersection(int[][] nums) {
        var n = nums.Length;
        var arr1 = nums[0].ToList();
        for(var i=1; i<n; i++){
            var arr2 = nums[i];
            arr1 = arr1.Intersect(arr2).ToList();
        }
        arr1.Sort();
        return arr1;
    }
}
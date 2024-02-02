// O(n) iterate through all possible nums
public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        var seq = new int[]{12, 23, 34, 45, 56, 67, 78, 89, 123, 234, 345, 456, 567, 678, 789, 1234, 2345, 3456, 4567, 5678, 6789, 12345, 23456, 34567, 45678, 56789, 123456, 234567, 345678, 456789, 1234567, 2345678, 3456789, 12345678, 23456789, 123456789};
        var result = new List<int>();

        foreach(var num in seq){
            if(num >= low && num <= high)
                result.Add(num);
        }

        return result;
    }
}

// O(n^2) using sliding window
public class SolutionSW {
    public IList<int> SequentialDigits(int low, int high) {
        var seq = "123456789";
        var result = new List<int>();

        for(var i=0; i<seq.Length; i++){
            for(var j=i+1; j<=seq.Length; j++){
                var numStr = seq.Substring(i,j-i);
                var num = Convert.ToInt32(numStr);
                if(num >= low && num <= high)
                    result.Add(num);
            }
        }

        result.Sort();
        return result;
    }
}
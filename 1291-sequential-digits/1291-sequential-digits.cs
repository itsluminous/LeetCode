public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        var allNums = new List<int>();
        allNums.AddRange(new []{12, 23, 34, 45, 56, 67, 78, 89});
        allNums.AddRange(new []{123, 234, 345, 456, 567, 678, 789});
        allNums.AddRange(new []{1234, 2345, 3456, 4567, 5678, 6789});
        allNums.AddRange(new []{12345, 23456, 34567, 45678, 56789});
        allNums.AddRange(new []{123456, 234567, 345678, 456789});
        allNums.AddRange(new []{1234567, 2345678, 3456789});
        allNums.AddRange(new []{12345678, 23456789});
        allNums.AddRange(new []{123456789});
        
        var result = new List<int>();
        foreach(var num in allNums){
            if(num >= low && num <= high){
                result.Add(num);
            }
        }
        
        return result;
    }
}
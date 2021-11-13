// O(n) - Keep saving idx of temperature in stack till we find a higher temp, then keep popping
public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var n = temperatures.Length;
        var result = new int[n];
        var stack = new Stack<int>();
        
        // for each temperature, form a list of indexes
        for(var currDay=0; currDay<n; currDay++){
            var currTemp = temperatures[currDay];
            // pop until the current day's temp is warmer than stack's top item
            while(stack.Count > 0 && temperatures[stack.Peek()] < currTemp){
                var prevDay = stack.Pop();
                result[prevDay] = currDay - prevDay;
            }
            stack.Push(currDay);
        }
        
        return result;
    }
}

// Brute Force - O(n2) - TLE
public class Solution1 {
    public int[] DailyTemperatures(int[] temperatures) {
        var n = temperatures.Length;
        var result = new int[n];
        for(var i=0; i<n; i++){
            for(var j=i+1; j<n; j++){
                if(temperatures[j] > temperatures[i]){
                    result[i] = j-i;
                    break;
                }
            }
        }
        
        return result;
    }
}
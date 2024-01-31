// start from right and keep populating max temp index
public class Solution {
    public int[] DailyTemperatures(int[] temp) {
        var n = temp.Length;
        var wait = new int[n];
        wait[n-1] = 0;

        for(var i=n-2; i>=0; i--){
            var idx = i+1;
            while(idx < n){
                // found a temp greater than current
                if(temp[idx] > temp[i]){
                    wait[i] = idx-i;
                    break;
                }
                // case where bigger temp does not exist
                if(wait[idx] == 0){
                    idx = n;
                    break;
                }
                // find next bigger temp
                idx += wait[idx];
            }
            if(idx == n) wait[i] = 0;
        }

        return wait;
    }
}

// O(n) - Keep saving idx of temperature in stack till we find a higher temp, then keep popping
public class SolutionStack {
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
public class SolutionBF {
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
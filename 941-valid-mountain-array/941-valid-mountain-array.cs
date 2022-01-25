public class Solution {
    public bool ValidMountainArray(int[] arr) {
        if(arr.Length < 3 || arr[1] < arr[0]) return false;
        
        var peakFound = false;
        for(var i=1; i<arr.Length; i++){
            if(arr[i-1] == arr[i]) return false;                    // we need strictly increasing or decreasing
            if(peakFound && arr[i] > arr[i-1]) return false;        // if we go up again after downhill
            if(!peakFound && arr[i] < arr[i-1]) peakFound = true;   // if we start going downhill, then we found peak
        }
        return peakFound;   // if we kept going up and up, then return value has to be false
    }
}
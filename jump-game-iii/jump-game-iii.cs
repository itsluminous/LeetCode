// Accepted - without using extra space
public class Solution {
    public bool CanReach(int[] arr, int i) {
        if(i < 0 || i >= arr.Length || arr[i] < 0) return false;
        if(arr[i] == 0) return true;
        
        arr[i] = -arr[i];   // marking index i as visited
        return CanReach(arr, i+arr[i]) || CanReach(arr, i-arr[i]);
    }
}


// Accepted - using O(n) extra space
public class Solution1 {
    public bool CanReach(int[] arr, int start) {
        var n = arr.Length;
        var visited = new bool[n];
        return CanReach(arr, start, visited);
    }
    
    private bool CanReach(int[] arr, int i, bool[] visited){
        if(i < 0 || i >= arr.Length || visited[i]) return false;
        if(arr[i] == 0) return true;
        
        visited[i] = true;
        if(CanReach(arr, i+arr[i], visited)) return true;
        if(CanReach(arr, i-arr[i], visited)) return true;
        visited[i] = false;
        
        return false;
    }
}

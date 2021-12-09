public class Solution {
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
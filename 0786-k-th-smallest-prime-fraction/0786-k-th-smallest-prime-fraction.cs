public class Solution {
    public int[] KthSmallestPrimeFraction(int[] arr, int k) {
        var n = arr.Length;
        var pq = new PriorityQueue<(int, int), double>();

        for(var i=0; i<n; i++)
            for(var j=i+1; j<n; j++)
                pq.Enqueue((arr[i], arr[j]), (double)arr[i]/arr[j]);
        
        while(k-- > 1) pq.Dequeue();
        var (num1, num2) = pq.Dequeue();
        return new []{num1, num2};
    }
}
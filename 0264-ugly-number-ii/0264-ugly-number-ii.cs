// Accepted - slow
public class Solution {
    public int NthUglyNumber(int n) {
        var minHeap = new PriorityQueue<double, double>();
        var set = new HashSet<double>();

        // powers of 2
        for(var i=0; i<n; i++){
            var num = Math.Pow(2, i);
            set.Add(num);
            minHeap.Enqueue(num, num);
        }

        // powers of 2 & 3
        for(var i=1; i<n; i++){
            var num = minHeap.Dequeue();
            double into3 = num * 3, into5 = num * 5, into35 = num * 3 * 5;
            if(set.Add(into3)) minHeap.Enqueue(into3, into3);
            if(set.Add(into5)) minHeap.Enqueue(into5, into5);
            if(set.Add(into35)) minHeap.Enqueue(into35, into35);
        }

        return Convert.ToInt32(minHeap.Dequeue());
    }
}
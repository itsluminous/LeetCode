// INTUTION : maxHeap <= median < minHeap
public class MedianFinder {
    PriorityQueue<int, int> maxHeap, minHeap;
    double median;

    public MedianFinder() {
        maxHeap = new PriorityQueue<int, int>();
        minHeap = new PriorityQueue<int, int>();
        median = 0;
    }
    
    public void AddNum(int num) {
        if(maxHeap.Count == 0){
            maxHeap.Enqueue(num, -num);
            median = num;
            return;
        }

        // add new number in appropriate heap
        if(median >= num) maxHeap.Enqueue(num, -num);
        else minHeap.Enqueue(num, num);

        // now balance the no. of elements in heap
        if(maxHeap.Count - minHeap.Count == 2)
            minHeap.Enqueue(maxHeap.Peek(), maxHeap.Dequeue());
        else if(minHeap.Count - maxHeap.Count == 1)
            maxHeap.Enqueue(minHeap.Peek(), -minHeap.Dequeue());

        // calculate new median
        if(maxHeap.Count == minHeap.Count)
            median = (maxHeap.Peek() + minHeap.Peek()) / 2.0;
        else
            median = maxHeap.Peek();
    }
    
    public double FindMedian() {
        return median;
    }
}


/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
// INTUTION : maxHeap <= median < minHeap
class MedianFinder {
    PriorityQueue<Integer> maxHeap, minHeap;
    double median;

    public MedianFinder() {
        maxHeap = new PriorityQueue<>((n1, n2) -> n2 - n1);
        minHeap = new PriorityQueue<>();
        median = 0;
    }
    
    public void addNum(int num) {
        if(maxHeap.isEmpty()){
            maxHeap.offer(num);
            median = num;
            return;
        }

        // add new number in appropriate heap
        if(median >= num) maxHeap.offer(num);
        else minHeap.offer(num);

        // now balance the no. of elements in heap
        if(maxHeap.size() - minHeap.size() == 2)
            minHeap.offer(maxHeap.poll());
        else if(minHeap.size() - maxHeap.size() == 1)
            maxHeap.offer(minHeap.poll());

        // calculate new median
        if(maxHeap.size() == minHeap.size())
            median = (maxHeap.peek() + minHeap.peek()) / 2.0;
        else
            median = maxHeap.peek();
    }
    
    public double findMedian() {
        return median;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.addNum(num);
 * double param_2 = obj.findMedian();
 */
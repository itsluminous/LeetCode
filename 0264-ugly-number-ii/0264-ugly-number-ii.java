class Solution {
    public int nthUglyNumber(int n) {
        var ugly = new int[n];
        ugly[0] = 1;
        int idx2 = 0, idx3 = 0, idx5 = 0;
        int mul2 = 2, mul3 = 3, mul5 = 5;   // multiple of 2, 3, 5

        for(var i=1; i<n; i++){
            var minNum = Math.min(mul2, Math.min(mul3, mul5));
            ugly[i] = minNum;

            if(minNum == mul2) mul2 = 2 * ugly[++idx2];
            if(minNum == mul3) mul3 = 3 * ugly[++idx3];
            if(minNum == mul5) mul5 = 5 * ugly[++idx5];
        }

        return ugly[n-1];
    }
}

// Accepted
class SolutionPQ {
    public int nthUglyNumber(int n) {
        var minHeap = new PriorityQueue<Double>();
        var set = new HashSet<Double>();

        // powers of 2
        for(var i=0; i<n; i++){
            var num = Math.pow(2, i);
            set.add(num);
            minHeap.offer(num);
        }

        // powers of 2 & 3
        for(var i=1; i<n; i++){
            var num = minHeap.poll();
            double into3 = num * 3, into5 = num * 5, into35 = num * 3 * 5;
            if(set.add(into3)) minHeap.offer(into3);
            if(set.add(into5)) minHeap.offer(into5);
            if(set.add(into35)) minHeap.offer(into35);
        }

        return minHeap.poll().intValue();
    }
}
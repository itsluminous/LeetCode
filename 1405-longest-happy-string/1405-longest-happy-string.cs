public class Solution {
    public string LongestDiverseString(int a, int b, int c) {
        var maxHeap = new PriorityQueue<int[], int>();  // [char, count]
        if(a != 0) maxHeap.Enqueue([0, a], -a);
        if(b != 0) maxHeap.Enqueue([1, b], -b);
        if(c != 0) maxHeap.Enqueue([2, c], -c);

        var happy = new StringBuilder();
        int prev1 = 0, prev2 = 0;   // last two characters
        while(maxHeap.Count > 0){
            var first = maxHeap.Dequeue();
            // check if we are going to repeat same char 3rd time
            if(happy.Length >= 2 && prev1 == first[0] && prev2 == first[0]){
                // if heap is empty, we already have final answer
                if(maxHeap.Count == 0) return happy.ToString();
                var second = maxHeap.Dequeue();
                happy.Append((char)('a' + second[0]));
                second[1]--;    // reduce remaining count
                if(second[1] > 0) maxHeap.Enqueue([second[0], second[1]], -second[1]);
                maxHeap.Enqueue([first[0], first[1]], -first[1]);
                prev1 = prev2;
                prev2 = second[0];
            }
            // if curr character fits nicely
            else {
                happy.Append((char)('a' + first[0]));
                first[1]--;    // reduce remaining count
                if(first[1] > 0) maxHeap.Enqueue([first[0], first[1]], -first[1]);
                prev1 = prev2;
                prev2 = first[0];
            }
        }

        return happy.ToString();
    }
}
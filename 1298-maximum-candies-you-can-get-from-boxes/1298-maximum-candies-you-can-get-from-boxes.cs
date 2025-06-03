public class Solution {
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes) {
        int n = candies.Length, maxCandies = 0;
        bool[] boxFound = new bool[n], keyFound = new bool[n];

        var queue = new Queue<int>();
        foreach(var box in initialBoxes){
            boxFound[box] = true;
            if(status[box] == 1) queue.Enqueue(box);
        }

        while(queue.Count > 0){
            var box = queue.Dequeue();
            if(status[box] == -1) continue; // already explored

            // capture candies
            maxCandies += candies[box];
            status[box] = -1;   // mark visited

            // explore new boxes found
            foreach(var cBox in containedBoxes[box]){
                boxFound[cBox] = true;
                if(status[cBox] == 1 || (status[cBox] == 0 && keyFound[cBox])) queue.Enqueue(cBox);
            }

            // explore new keys found
            foreach(var kBox in keys[box]){
                keyFound[kBox] = true;
                if(status[kBox] != -1 && boxFound[kBox]) queue.Enqueue(kBox);
            }
        }

        return maxCandies;
    }
}
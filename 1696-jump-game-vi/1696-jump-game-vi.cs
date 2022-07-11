public class Solution {
    public int MaxResult(int[] nums, int k)
    {
        var n = nums.Length;
        
        // keep track of max score achievable for each index
        int[] scores = new int[n];
        scores[0] = nums[0];
        
        LinkedList<int> q = new LinkedList<int>();
        q.AddLast(0);   // first step we have to always include

        for (int i = 1; i < n; i++)
        {
            // we want to keep only k items in queue, so remove extra from start of window
            while (i - q.First.Value > k)
                q.RemoveFirst();

            // the topmost index in queue will have highest sum, so add it to current index's score
            scores[i] = scores[q.First.Value] + nums[i];

            // if we had reached any index with lesser score than current, remove it from queue
            while (q.Count > 0 && scores[i] >= scores[q.Last.Value])
                q.RemoveLast();

            q.AddLast(i);
        }

        return scores[n-1];
    }
}
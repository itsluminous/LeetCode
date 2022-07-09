public class Solution {
    public int MaxResult(int[] nums, int k)
    {
        int[] scores = new int[nums.Length];
        scores[0] = nums[0];
        LinkedList<int> q = new LinkedList<int>();
        q.AddLast(0);

        for (int i = 1; i < nums.Length; i++)
        {
            while (i - q.First.Value > k)
                q.RemoveFirst();

            scores[i] = scores[q.First.Value] + nums[i];

            while (q.Count > 0 && scores[i] >= scores[q.Last.Value])
                q.RemoveLast();

            q.AddLast(i);
        }

        return scores[nums.Length - 1];
    }
}
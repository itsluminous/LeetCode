public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var countOfNums = new Dictionary<int, int>();
        foreach(var num in nums){
            if(!countOfNums.ContainsKey(num))
                countOfNums[num] = 0;
            countOfNums[num]++;
        }
        
        var pq = new PriorityQueue<int,int>(countOfNums.Keys.Select(n => (n, -countOfNums[n])));
        
        var result = new int[k];
        for(var i=0; i<k; i++)
            result[i] = pq.Dequeue();
        
        return result;
    }
}
public class Solution {
    public int MaxFrequencyElements(int[] nums) {
        var dict = new Dictionary<int,int>();
        int maxFreq = 0, totalFreq = 0;
        foreach(var num in nums){
            var freq = 1;
            if(dict.ContainsKey(num)) freq += dict[num];
            dict[num] = freq;

            if(freq > maxFreq){
                maxFreq = freq;
                totalFreq = freq;
            }
            else if(freq == maxFreq)
                totalFreq += freq;
        }

        return totalFreq;
    }
}

// Accepted
public class Solution2Pass {
    public int MaxFrequencyElements(int[] nums) {
        const int MAX = 102;
        var arr = new int[MAX];
        foreach(var num in nums) arr[num]++;
        
        int maxFreq = arr.Max(), count = 0;
        foreach(var freq in arr)
            if(freq == maxFreq) count++;

        return count*maxFreq;
    }
}
// Without using extra data structure
public class Solution {
    public int[] RearrangeArray(int[] nums) {
        int n = nums.Length, posIdx = 0, negIdx = 1;
        var result = new int[n];
        
        foreach(var num in nums){
            if(num >=0){
                result[posIdx] = num;
                posIdx += 2;
            }
            else{
                result[negIdx] = num;
                negIdx += 2;
            }
        }
        
        return result;
    }
}

// Accepted - Using Queue
public class Solution1 {
    public int[] RearrangeArray(int[] nums) {
        var n = nums.Length;
        var pos = new Queue<int>();
        var neg = new Queue<int>();
        foreach(var num in nums){
            if(num >=0) pos.Enqueue(num);
            else neg.Enqueue(num);
        }
        
        var result = new int[n];
        for(var i=0; i<n; i++){
            result[i++] = pos.Dequeue();
            result[i] = neg.Dequeue();
        }
        
        return result;
    }
}
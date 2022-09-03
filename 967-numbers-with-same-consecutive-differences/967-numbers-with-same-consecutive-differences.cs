public class Solution {
    public int[] NumsSameConsecDiff(int n, int k) {
        var q = new Queue<int>();
        for(var i=1; i<10; i++) q.Enqueue(i);   // add first 9 digits in queue
        n--;                                    // since we added 1 digit, reduce n
        
        // while digit count is not equal to n
        while(n > 0){
            var len = q.Count;
            for(var i=0; i<len; i++){
                var num = q.Dequeue();
                // for each entry in queue, try to add a new digit to it
                for(var d=0; d<10; d++){
                    var lastDigit = num%10;
                    if(Math.Abs(lastDigit - d) != k) continue;
                    q.Enqueue(num*10 + d);
                }
            }
            n--;
        }
        
        return q.ToArray();;
    }
}
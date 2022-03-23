// Working backwards
public class Solution {
    public int BrokenCalc(int startValue, int target) {
        var steps = 0;
        while(target > startValue){
            steps++;
            // if odd number, make it even
            if(target % 2 == 1) target++;
            else target /= 2;
        }
        
        return steps + startValue - target;
    }
}

// BFS - outofmemory for startValue=1 and target=1000000000
public class Solution1 {
    public int BrokenCalc(int startValue, int target) {
        if(target <= startValue)
            return startValue - target;
        
        var q = new Queue<int>();
        q.Enqueue(startValue);
        
        var processed = new HashSet<int>();
        var steps = 1;
        
        while(q.Count > 0){
            var len = q.Count;
            for(var i=0; i<len; i++){
                var num = q.Dequeue();
                
                var sub1 = num-1;
                if(sub1 == target)
                    return steps;
                else if(processed.Add(sub1))
                    q.Enqueue(sub1);
                
                if(num*2 > int.MaxValue) continue;
                var mult2 = num*2;
                
                if(mult2 == target)
                    return steps;
                else if(processed.Add(mult2))
                    q.Enqueue(mult2);
                
                
            }
            steps++;
        }
        return steps;
    }
}
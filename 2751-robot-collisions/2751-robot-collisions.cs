public class Solution {
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions) {
        var n = positions.Length;
        var stack = new Stack<int>();

        var combined = new int[n][];
        for(var i=0; i<n; i++){
            combined[i] = new int[4];
            combined[i][0] = positions[i];
            combined[i][1] = healths[i];
            combined[i][2] = directions[i] == 'L' ? 0 : 1;   // 0=L, 1=R
            combined[i][3] = i;     // actual index
        }
        Array.Sort(combined, (c1, c2) => c1[0] - c2[0]);

        // pq to sort based on actual index
        var pq = new PriorityQueue<int, int>();

        for(var curr=0; curr<n; curr++){
            if(combined[curr][2] == 1)  // R direction, nothing in stack can collide
                stack.Push(curr);
            else if(stack.Count == 0)    // L direction, and no competitor
                pq.Enqueue(combined[curr][1], combined[curr][3]);
            else {  // collide
                var fight = true;
                while(fight){
                    var prev = stack.Pop();
                    if(combined[prev][1] == combined[curr][1])  // both have same health, both are out
                        fight = false;
                    else if(combined[prev][1] > combined[curr][1]){ // robot going right wins, fight ends
                        combined[prev][1]--;
                        if(combined[prev][1] > 0)
                            stack.Push(prev);
                        fight = false;
                    }
                    else{
                        combined[curr][1]--;
                        if(combined[curr][1] > 0){
                            if(stack.Count == 0 || combined[stack.Peek()][2] == 0){  // if no competitor
                                pq.Enqueue(combined[curr][1], combined[curr][3]);
                                fight = false;
                            }   
                        }   
                        else fight = false;
                    }
                }
            }
        }

        while(stack.Count > 0) {
            var idx = stack.Pop();
            pq.Enqueue(combined[idx][1], combined[idx][3]);
        }

        var ans = new List<int>();
        while (pq.Count > 0) ans.Add(pq.Dequeue());

        return ans;
    }
}
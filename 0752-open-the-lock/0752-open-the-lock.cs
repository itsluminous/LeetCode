// without converting int to string for digit manipulation (saves boxing and unboxing)
public class Solution {
    public int OpenLock(string[] deadends, string target) {
        var dead = new HashSet<int>();
        foreach(var de in deadends) dead.Add(Convert.ToInt32(de));

        var visited = new bool[10001];
        var queue = new Queue<int>();
        queue.Enqueue(Convert.ToInt32(target));
        visited[Convert.ToInt32(target)] = true;

        // BFS, from target to 0. Can be done other way also
        for(var moves=0; queue.Count > 0; moves++){
            for(var count=queue.Count-1; count>=0; count--){
                var num = queue.Dequeue();
                if(num == 0) return moves;
                var nextMoves = GetNextMoves(num, visited, dead);
                foreach(var nm in nextMoves){
                    visited[nm] = true;
                    queue.Enqueue(nm);
                }
            }
        }

        return -1;
    }

    private List<int> GetNextMoves(int num, bool[] visited, HashSet<int> dead){
        var next = new List<int>();
        for(var divisor=10; divisor<=10000; divisor*=10){
            var remainder = num % divisor;
            var quotient = num / divisor;

            var digit = remainder / (divisor/10);
            var digitPrev = digit == 0 ? 9 : digit-1;
            var digitNext = (digit + 1)%10;

            var num1 = quotient*divisor + digitPrev*(divisor/10) + remainder%(divisor/10);
            var num2 = quotient*divisor + digitNext*(divisor/10) + remainder%(divisor/10);
            
            if(!visited[num1] && !dead.Contains(num1)) next.Add(num1);
            if(!visited[num2] && !dead.Contains(num2)) next.Add(num2);
        }
        return next;
    }
}

// Accepted - using string operations (slower)
public class SolutionStrOp {
    public int OpenLock(string[] deadends, string target) {
        var deadset = new HashSet<string>();
        foreach(var de in deadends) deadset.Add(de);    // we will use this same set for marking visited
        if(deadset.Contains("0000")) return -1;

        var queue = new Queue<string>();
        queue.Enqueue("0000");
        deadset.Add("0000");    // mark as visited

        // BFS
        for(var moves=0; queue.Count > 0; moves++){
            for(var count=queue.Count-1; count>=0; count--){
                var num = queue.Dequeue();
                if(num == target) return moves;
                var nextMoves = GetNextMoves(num, deadset);
                foreach(var nm in nextMoves){
                    deadset.Add(nm);
                    queue.Enqueue(nm);
                }
            }
        }

        return -1;
    }

    private List<string> GetNextMoves(string num,HashSet<string> deadset){
        var next = new List<string>();
        for(var i=0; i<4; i++){
            var ch = num[i];
            var newch = ch;
            // move forward
            if(ch == '9') newch = '0';
            else newch = (char)(ch + 1);
            var newstr = num.Substring(0, i) + newch + num.Substring(i+1);
            if(!deadset.Contains(newstr)) next.Add(newstr);

            // move back
            if(ch == '0') newch = '9';
            else newch = (char)(ch - 1);
            newstr = num.Substring(0, i) + newch + num.Substring(i+1);
            if(!deadset.Contains(newstr)) next.Add(newstr);
        }
        return next;
    }
}
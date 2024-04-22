// without converting int to string for digit manipulation (saves boxing and unboxing)
public class Solution {
    public int openLock(String[] deadends, String target) {
        var dead = new HashSet<Integer>();
        for(var de : deadends) dead.add(Integer.parseInt(de));

        var visited = new boolean[10001];
        var queue = new LinkedList<Integer>();
        queue.offer(Integer.parseInt(target));
        visited[Integer.parseInt(target)] = true;

        // BFS, from target to 0. Can be done other way also
        for(var moves=0; queue.size() > 0; moves++){
            for(var count=queue.size()-1; count>=0; count--){
                var num = queue.poll();
                if(num == 0) return moves;
                var nextMoves = getNextMoves(num, visited, dead);
                for(var nm : nextMoves){
                    visited[nm] = true;
                    queue.offer(nm);
                }
            }
        }

        return -1;
    }

    private List<Integer> getNextMoves(int num, boolean[] visited, HashSet<Integer> dead){
        var next = new ArrayList<Integer>();
        for(var divisor=10; divisor<=10000; divisor*=10){
            var remainder = num % divisor;
            var quotient = num / divisor;

            var digit = remainder / (divisor/10);
            var digitPrev = digit == 0 ? 9 : digit-1;
            var digitNext = (digit + 1)%10;

            var num1 = quotient*divisor + digitPrev*(divisor/10) + remainder%(divisor/10);
            var num2 = quotient*divisor + digitNext*(divisor/10) + remainder%(divisor/10);
            
            if(!visited[num1] && !dead.contains(num1)) next.add(num1);
            if(!visited[num2] && !dead.contains(num2)) next.add(num2);
        }
        return next;
    }
}
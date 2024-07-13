class Solution {
    public List<Integer> survivedRobotsHealths(int[] positions, int[] healths, String directions) {
        var n = positions.length;
        var stack = new Stack<Integer>();

        var combined = new int[n][4];
        for(var i=0; i<n; i++){
            combined[i][0] = positions[i];
            combined[i][1] = healths[i];
            combined[i][2] = directions.charAt(i) == 'L' ? 0 : 1;   // 0=L, 1=R
            combined[i][3] = i;     // actual index
        }
        Arrays.sort(combined, (c1, c2) -> c1[0] - c2[0]);

        // pq to sort based on actual index
        var pq = new PriorityQueue<int[]>((a1, a2) -> Integer.compare(a1[3], a2[3]));

        for(var curr=0; curr<n; curr++){
            if(combined[curr][2] == 1)  // R direction, nothing in stack can collide
                stack.push(curr);
            else if(stack.isEmpty())    // L direction, and no competitor
                pq.offer(combined[curr]);
            else {  // collide
                var fight = true;
                while(fight){
                    var prev = stack.pop();
                    if(combined[prev][1] == combined[curr][1])  // both have same health, both are out
                        fight = false;
                    else if(combined[prev][1] > combined[curr][1]){ // robot going right wins, fight ends
                        combined[prev][1]--;
                        if(combined[prev][1] > 0)
                            stack.push(prev);
                        fight = false;
                    }
                    else{
                        combined[curr][1]--;
                        if(combined[curr][1] > 0){
                            if(stack.isEmpty() || combined[stack.peek()][2] == 0){
                                pq.offer(combined[curr]);
                                fight = false;
                            }   
                        }   
                        else fight = false;
                    }
                }
            }
        }

        while(!stack.isEmpty()) pq.offer(combined[stack.pop()]);

        var ans = new ArrayList<Integer>();
        while (!pq.isEmpty()) {
            var arr = pq.poll();
            ans.add(arr[1]);
        }

        return ans;
    }
}
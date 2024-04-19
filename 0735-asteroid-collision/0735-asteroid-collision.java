public class Solution {
    public int[] asteroidCollision(int[] asteroids) {
        var stack = new Stack<Integer>();
        for(var a : asteroids){
            var explode = false;
            while(a < 0 && stack.size() > 0 && !explode){
                if(stack.peek() < 0) break;
                if(stack.peek() > Math.abs(a)){
                    explode = true;
                    break;
                }
                var top = stack.pop();
                if(top == Math.abs(a)) explode = true;
            }
            if(!explode) stack.push(a);
        }

        // var ans = stack.toArray();
        var ans = stack.stream().mapToInt(c -> c).toArray();
        Collections.reverse(Arrays.asList(ans));
        return ans;
    }
}
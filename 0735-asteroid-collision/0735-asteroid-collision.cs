public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        var stack = new Stack<int>();
        foreach(var a in asteroids){
            var explode = false;
            while(a < 0 && stack.Count > 0 && !explode){
                if(stack.Peek() < 0) break;
                if(stack.Peek() > Math.Abs(a)){
                    explode = true;
                    break;
                }
                var top = stack.Pop();
                if(top == Math.Abs(a)) explode = true;
            }
            if(!explode) stack.Push(a);
        }

        var ans = stack.ToArray();
        Array.Reverse(ans);
        return ans;
    }
}
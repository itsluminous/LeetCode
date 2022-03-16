public class Solution {
    public bool ValidateStackSequences(int[] pushed, int[] popped) {
        int pu=0, po = 0, n = pushed.Length;
        var stack = new Stack<int>();
        while(pu < n && po < n){
            stack.Push(pushed[pu++]);
            while(stack.Count > 0 && stack.Peek() == popped[po] && po < n){
                stack.Pop();
                po++;
            }
        }
        
        if(pu < n || po < n) return false;
        return true;
    }
}
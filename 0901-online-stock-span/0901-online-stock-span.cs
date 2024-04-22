public class StockSpanner {
    Stack<(int, int)> stack;

    public StockSpanner() {
        stack = new Stack<(int, int)>();
    }

    public int Next(int price) {
        var ans = 1;
        while(stack.Count > 0 && stack.Peek().Item1 <= price)
            ans += stack.Pop().Item2;
        stack.Push((price, ans));
        return ans;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
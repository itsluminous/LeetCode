public class MyStack
{
	/** Initialize your data structure here. */
	Queue<int> queue;
	Queue<int> temp;

	public MyStack()
	{
		queue = new Queue<int>();
	}

	/** Push element x onto stack. */
	public void Push(int x)
	{
		queue.Enqueue(x);
	}

	/** Removes the element on top of the stack and returns that element. */
	public int Pop()
	{
		if (Empty()) return -1;

		temp = new Queue<int>();

		while (queue.Count > 1)
			temp.Enqueue(queue.Dequeue());

		int pop = queue.Dequeue();
		queue = temp;

		return pop;
	}

	/** Get the top element. */
	public int Top()
	{
		if (Empty()) return -1;

		temp = new Queue<int>();

		while (queue.Count > 1)
			temp.Enqueue(queue.Dequeue());

		int top = queue.Dequeue();
		temp.Enqueue(top);
		queue = temp;

		return top;
	}

	/** Returns whether the stack is empty. */
	public bool Empty()
	{
		return queue.Count == 0;
	}
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */
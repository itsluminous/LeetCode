public class TaskManager {
    // similar implementation as LRU cache with hashmap for keeping pointers
    private SortedSet<Task> sortedTasks;
    private Dictionary<int, Task> taskMap;

    public TaskManager(IList<IList<int>> tasks) {
        sortedTasks = new SortedSet<Task>();
        taskMap = new Dictionary<int, Task>();

        foreach (var task in tasks) {
            int userId = task[0], taskId = task[1], priority = task[2];
            Add(userId, taskId, priority);
        }
    }
    
    public void Add(int userId, int taskId, int priority) {
        var task = new Task(userId, taskId, priority);
        sortedTasks.Add(task);
        taskMap[taskId] = task;
    }
    
    public void Edit(int taskId, int newPriority) {
        if (taskMap.TryGetValue(taskId, out var task)) {
            sortedTasks.Remove(task);
            task.Priority = newPriority;
            sortedTasks.Add(task);
        }
    }
    
    public void Rmv(int taskId) {
        if (taskMap.TryGetValue(taskId, out var task)) {
            sortedTasks.Remove(task);
            taskMap.Remove(taskId);
        }
    }
    
    public int ExecTop() {
        if (sortedTasks.Count == 0) return -1;

        var topTask = sortedTasks.Min;
        sortedTasks.Remove(topTask);
        taskMap.Remove(topTask.TaskId);
        return topTask.UserId;
    }
}

public class Task : IComparable<Task> {
    public int UserId { get; set; }
    public int TaskId { get; set; }
    public int Priority { get; set; }

    public Task(int userId, int taskId, int priority)
    {
        UserId = userId;
        TaskId = taskId;
        Priority = priority;
    }

    public int CompareTo(Task other)
    {
        if (this.Priority != other.Priority)
            return other.Priority.CompareTo(this.Priority); // Descending priority

        return other.TaskId.CompareTo(this.TaskId); // Descending taskId
    }

    public override bool Equals(object obj)
    {
        if (obj is Task other)
            return TaskId == other.TaskId;

        return false;
    }

    public override int GetHashCode()
    {
        return TaskId.GetHashCode();
    }
}

/**
 * Your TaskManager object will be instantiated and called as such:
 * TaskManager obj = new TaskManager(tasks);
 * obj.Add(userId,taskId,priority);
 * obj.Edit(taskId,newPriority);
 * obj.Rmv(taskId);
 * int param_4 = obj.ExecTop();
 */
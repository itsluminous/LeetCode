public class Solution {
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength) {
        Array.Sort(tasks);
        Array.Sort(workers);
        int ans = 0, tLen = tasks.Length, wLen = workers.Length;

        // if wLen is smaller, in best case we can do wLen tasks only
        // if tLen is smaller, then obviously we cannot do more tasks than tLen
        int left = 1, right = Math.Min(tLen, wLen);

        // binary search to find right idx in tasks, till which all tasks can be completed
        while (left <= right) {
            var mid = left + (right - left) / 2;
            if (CanDo(tasks, workers, pills, strength, mid)) {
                ans = mid;
                left = mid + 1;
            }
            else
                right = mid - 1;
        }

        return ans;
    }

    private bool CanDo(int[] tasks, int[] workers, int pills, int strength, int count) {
        int wLen = workers.Length;
        var workerStrength = new SortedList<int, int>();

        // put last `count` workers in this map, as they are the strongest
        for (var i = wLen - count; i < wLen; i++) {
            if (!workerStrength.ContainsKey(workers[i]))
                workerStrength[workers[i]] = 0;
            workerStrength[workers[i]]++;
        }

        for (var i = count - 1; i >= 0; i--) {
            // get strongest worker
            var lastKey = workerStrength.Keys[workerStrength.Count - 1];

            // if worker can do task directly
            if (lastKey >= tasks[i]) {
                workerStrength[lastKey]--;
                if (workerStrength[lastKey] == 0)
                    workerStrength.Remove(lastKey);
            }
            else {
                // no pills left
                if (pills == 0) return false;

                // find a worker who can barely do task after pill
                int required = tasks[i] - strength;
                var keys = workerStrength.Keys.ToArray();
                int idx = Array.BinarySearch(keys, required);
                if (idx < 0) idx = ~idx;
                if (idx >= keys.Length) return false;

                var ceiling = keys[idx];
                pills--;
                workerStrength[ceiling]--;
                if (workerStrength[ceiling] == 0)
                    workerStrength.Remove(ceiling);
            }
        }

        return true;
    }
}
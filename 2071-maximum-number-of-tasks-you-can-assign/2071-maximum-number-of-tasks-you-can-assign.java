class Solution {
    public int maxTaskAssign(int[] tasks, int[] workers, int pills, int strength) {
        Arrays.sort(tasks);
        Arrays.sort(workers);
        int ans = 0, tLen = tasks.length, wLen = workers.length;
        
        // if wLen is smaller, in best case we can do wLen tasks only
        // if tLen is smaller, the obviously we cannot do more tasks than tLen
        int left = 1, right = Math.min(tLen, wLen);

        // binary search to find right idx in tasks, till which all tasks can be completed
        while(left <= right){
            var mid = left + (right - left) / 2;
            if(canDo(tasks, workers, pills, strength, mid)){
                ans = mid;
                left = mid + 1;
            }
            else
                right = mid - 1;
        }

        return ans;
    }

    private boolean canDo(int[] tasks, int[] workers, int pills, int strength, int count) {
        int tLen = tasks.length, wLen = workers.length;
        var workerStrength = new TreeMap<Integer, Integer>();   // count of workers for each strength val
        
        // put last `count` workers in this map, as they are the strongest
        for(var i=wLen-count; i<wLen; i++)
            workerStrength.put(workers[i], workerStrength.getOrDefault(workers[i], 0) + 1);
        
        // try to assign the `count` tasks to these workers
        // we can do it asc, but desc will help in early exit
        for(var i=count-1; i>=0; i--){
            var currStrength = workerStrength.lastKey();

            // if this worker has enough strength to do task, then great!
            if(currStrength >= tasks[i]){
                workerStrength.put(currStrength, workerStrength.get(currStrength) - 1);
                if(workerStrength.get(currStrength) == 0)
                    workerStrength.remove(currStrength);
            }
            else{
                // don't have pills to boost strength
                if(pills == 0) return false;
                
                // find a worker who can barely do task after taking pill
                currStrength = workerStrength.ceilingKey(tasks[i] - strength);
                if(currStrength == null) return false;

                // use one pill
                pills--;
                workerStrength.put(currStrength, workerStrength.get(currStrength) - 1);
                if(workerStrength.get(currStrength) == 0)
                    workerStrength.remove(currStrength);
            }
        }
        return true;
    }
}
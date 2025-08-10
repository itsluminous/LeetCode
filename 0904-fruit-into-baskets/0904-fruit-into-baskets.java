class Solution {
    public int totalFruit(int[] fruits) {
        var uniq = new HashMap<Integer, Integer>();
        int n = fruits.length, ans = 1, left = 0;

        for(var right = 0; right < n; right++){
            uniq.put(fruits[right], uniq.getOrDefault(fruits[right], 0) + 1);
            while(uniq.size() > 2){
                uniq.put(fruits[left], uniq.get(fruits[left]) - 1);
                if(uniq.get(fruits[left]) == 0) uniq.remove(fruits[left]);
                left++;
            }
            ans = Math.max(ans, right - left + 1);
        }
        return ans;
    }
}
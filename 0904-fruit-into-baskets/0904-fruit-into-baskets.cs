public class Solution {
    public int TotalFruit(int[] fruits) {
        var uniq = new Dictionary<int, int>();
        int n = fruits.Length, ans = 1, left = 0;

        for(var right = 0; right < n; right++) {
            if (!uniq.ContainsKey(fruits[right])) uniq[fruits[right]] = 0;
            uniq[fruits[right]]++;

            while (uniq.Count > 2){
                uniq[fruits[left]]--;
                if(uniq[fruits[left]] == 0) uniq.Remove(fruits[left]);
                left++;
            }
            ans = Math.Max(ans, right - left + 1);
        }
        return ans;
    }
}

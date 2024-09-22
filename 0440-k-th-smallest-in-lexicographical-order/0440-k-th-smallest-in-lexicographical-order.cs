public class Solution {
    public int FindKthNumber(int n, int k) {
        var curr = 1;
        k--;

        while(k > 0){
            // how many steps are needed to move from curr to curr+1
            var steps = CalculateSteps(n, curr, curr+1);

            // if all steps can fit within bound of k, then we can jump to next one
            if(steps <= k){
                curr++;
                k -= steps;
            }
            // else, we need to try next level in tree
            else {
                curr *= 10;
                k--;
            }
        }

        return curr;
    }

    private int CalculateSteps(int n, long num1, long num2){
        long steps = 0;
        while(num1 <= n){
            // if n = 102 & num1 = 100, then 102 - 100 = 2, but we want 3 (100, 101, 102)
            // hence we do Min(n+1, num2) instead of Min(n, num2)
            steps += Math.Min(n+1, num2) - num1;
            // move to next level
            num1 *= 10;
            num2 *= 10;
        }

        return (int)steps;
    }
}

// TLE
public class SolutionTLE {
    public int FindKthNumber(int n, int k) {
        long curr = 1;

        for (int i = 1; i <= n; i++, k--) {
            if(k == 1) return (int)curr;

            // increasing no. of digit 
            if (curr * 10 <= n)
                curr *= 10;
            // going to next number
            else if (curr % 10 != 9 && curr + 1 <= n)
                curr++;
            // going backwards
            else {  
                curr /= 10;
                while(curr % 10 == 9) curr /= 10;
                curr++;
            }
        }

        return 1;
    }
}
public class Solution {
    IList<int> ans = new List<int>();

    public IList<int> LexicalOrder(int n, int curr = 1) {
        Helper(0, n);
        return ans;
    }

    private void Helper(int seed, int max){
        seed *= 10;
        for(var i=0; i<10; i++){
            if(seed + i == 0) continue;
            if(seed + i > max) break;
            ans.Add(seed + i);
            Helper(seed + i, max);
        }
    }
}

// Accepted
public class SolutionAlt {
    IList<int> ans = new List<int>();

    public IList<int> LexicalOrder(int n, int curr = 1) {
        if(curr > n) return ans;
        
        ans.Add(curr);
        LexicalOrder(n, curr * 10);

        // we don't want to repeat a number ending with 0 which is already covered
        if(curr % 10 != 9)  
            LexicalOrder(n, curr + 1);
            
        return ans;
    }
}
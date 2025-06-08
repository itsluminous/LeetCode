class Solution {
    List<Integer> ans = new ArrayList<>();

    public List<Integer> lexicalOrder(int n) {
        helper(0, n);
        return ans;
    }

    private void helper(int seed, int max){
        seed *= 10;
        for(var i=0; i<10; i++){
            if(seed + i == 0) continue;
            if(seed + i > max) break;
            ans.add(seed + i);
            helper(seed + i, max);
        }
    }
}

// Accepted
class SolutionAlt {
    List<Integer> ans = new ArrayList<>();

    public List<Integer> lexicalOrder(int n) {
        lexicalOrder(n, 1);
        return ans;
    }

    private void lexicalOrder(int n, int curr) {
        if(curr > n) return;
        
        ans.add(curr);
        lexicalOrder(n, curr * 10);

        // we don't want to repeat a number ending with 0 which is already covered
        if(curr % 10 != 9)  
            lexicalOrder(n, curr + 1);
    }
}
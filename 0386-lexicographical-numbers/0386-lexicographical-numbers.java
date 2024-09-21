class Solution {
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
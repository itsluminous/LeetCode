class Solution {
    public int finalValueAfterOperations(String[] operations) {
        var ans = 0;
        for(var op : operations)
            if(op.equals("X++") || op.equals("++X")) ans++;
            else ans--;
        return ans;
    }
}
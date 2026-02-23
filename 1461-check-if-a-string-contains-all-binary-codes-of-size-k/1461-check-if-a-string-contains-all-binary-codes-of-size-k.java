class Solution {
    public boolean hasAllCodes(String s, int k) {
        var str = new HashSet<String>();
        for(int i=0, j=k; j<=s.length(); i++, j++)
            str.add(s.substring(i, j));
        
        var expectedCount = (1 << k);   // this is max number possible with k binary digits
        var actualCount = str.size();

        // if total items in set is not same as max possible, then some numbers are missing
        return expectedCount == actualCount;
    }
}
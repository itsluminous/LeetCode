class Solution {
    public boolean checkStrings(String s1, String s2) {
        var n = s1.length();
        int[] oddFreq = new int[26], evenFreq = new int[26];
        for(var i=0; i<n; i+=2) evenFreq[s1.charAt(i) - 'a'] += 1;
        for(var i=1; i<n; i+=2) oddFreq[s1.charAt(i) - 'a'] += 1;

        for(var i=0; i<n; i+=2){
            evenFreq[s2.charAt(i) - 'a'] -= 1;
            if(evenFreq[s2.charAt(i) - 'a'] < 0) return false;
        }
        for(var i=1; i<n; i+=2){
            oddFreq[s2.charAt(i) - 'a'] -= 1;
            if(oddFreq[s2.charAt(i) - 'a'] < 0) return false;
        }
        return true;
    }
}
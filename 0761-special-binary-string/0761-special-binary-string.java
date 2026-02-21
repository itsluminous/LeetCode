// very important observation : when reading from left, count of 1 should always be >= 0
// so a special string should always start with 1
// and we would want special strings with most 1s to be at start
class Solution {
    public String makeLargestSpecial(String s) {
        int count = 0, l = 0;
        var strings = new ArrayList<String>();
        for(var r=0; r<s.length(); r++){
            if(s.charAt(r) == '1') count++;
            else count--;

            if(count == 0){
                strings.add("1" + makeLargestSpecial(s.substring(l+1, r)) + "0");
                l = r+1;
            }
        }
        Collections.sort(strings, Collections.reverseOrder());
        return String.join("", strings);
    }
}
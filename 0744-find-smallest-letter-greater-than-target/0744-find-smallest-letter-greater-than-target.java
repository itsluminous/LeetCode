class Solution {
    public char nextGreatestLetter(char[] letters, char target) {
        var smallest = letters[0];
        var diff = 30;

        for(var ch : letters){
            var curr = ch - target;
            if(curr > 0 && curr < diff){
                diff = curr;
                smallest = ch;
            }
        }

        return smallest;
    }
}
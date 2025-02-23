class Solution {
    public boolean hasSameDigits(String s) {
        var digits = new ArrayList<Integer>();
        for(var ch : s.toCharArray())
            digits.add(ch - '0');

        while(digits.size() > 2){
            var newDigits = new ArrayList<Integer>();
            for(var i=0; i<digits.size() - 1; i++){
                var num1 = digits.get(i);
                var num2 = digits.get(i+1);
                var num3 = (num1 + num2) % 10;
                newDigits.add(num3);
            }
            digits = newDigits;
        }

        return digits.get(0) == digits.get(1);
    }
}
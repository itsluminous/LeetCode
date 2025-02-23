public class Solution {
    public bool HasSameDigits(string s) {
        var digits = new List<int>();
        foreach(var ch in s)
            digits.Add(ch - '0');

        while(digits.Count > 2){
            var newDigits = new List<int>();
            for(var i=0; i<digits.Count - 1; i++){
                var num1 = digits[i];
                var num2 = digits[i+1];
                var num3 = (num1 + num2) % 10;
                newDigits.Add(num3);
            }
            digits = newDigits;
        }

        return digits[0] == digits[1];
    }
}
public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        if (numerator == 0) return "0";

        var ans = new StringBuilder();

        // handle sign
        if ((numerator < 0 || denominator < 0) && !(numerator < 0 && denominator < 0)) ans.Append("-");

        long num = Math.Abs((long)numerator);
        long den = Math.Abs((long)denominator);

        // integer part
        ans.Append(num / den);
        num %= den;
        if (num == 0) return ans.ToString();

        // fraction part
        ans.Append(".");
        var map = new Dictionary<long, int>(); // position when a digit was seen
        map[num] = ans.Length;

        while (num != 0) {
            num *= 10;
            ans.Append(num / den);
            num %= den;

            // found repeating numerator
            if (map.ContainsKey(num)) {
                int left = map[num];
                ans.Insert(left, "(");
                ans.Append(")");
                break;
            } 
            else
                map[num] = ans.Length;
        }

        return ans.ToString();
    }
}
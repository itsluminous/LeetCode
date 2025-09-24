class Solution {
    public String fractionToDecimal(int numerator, int denominator) {
        if(numerator == 0) return "0";

        var ans = new StringBuilder();
        if((numerator < 0 || denominator < 0) && !(numerator < 0 && denominator < 0)) ans.append("-");

        long num = Math.abs((long)numerator);
        long den = Math.abs((long)denominator);

        // integer part
        ans.append(num / den);
        num %= den;
        if(num == 0) return ans.toString();

        // fraction part
        ans.append(".");
        var map = new HashMap<Long, Integer>(); // position when a digit was seen
        map.put(num, ans.length());

        while(num != 0){
            num *= 10;
            ans.append(num / den);
            num %= den;

            // found repeating numerator
            if(map.containsKey(num)){
                var left = map.get(num);
                ans.insert(left, "(");
                ans.append(")");
                break;
            }
            else
                map.put(num, ans.length());
        }

        return ans.toString();
    }
}
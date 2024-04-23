public class Solution {
    public string IntToRoman(int num) {
        var dict = new Dictionary<int, string>(){
            {1000, "M"}, {900, "CM"}, {500, "D"}, {400, "CD"}, {100, "C"}, 
            {90, "XC"}, {50, "L"}, {40, "XL"}, {10, "X"}, 
            {9, "IX"}, {5, "V"}, {4, "IV"}, {1, "I"}
        };

        var ans = new StringBuilder();
        foreach(var (decim, roman) in dict){
            if(num == 0) break;
            while(num >= decim){
                ans.Append(roman);
                num -= decim;
            }
        }

        return ans.ToString();
    }
}

// Accepted - O(1)
public class SolutionQuick {
    public string IntToRoman(int num) {
        var M = new string[]{"", "M", "MM", "MMM"};
        var C = new string[]{"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"};
        var X = new string[]{"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"};
        var I = new string[]{"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"};
        return M[num/1000] + C[(num%1000)/100] + X[(num%100)/10] + I[num%10];
    }
}
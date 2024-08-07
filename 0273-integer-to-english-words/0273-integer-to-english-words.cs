public class Solution {
    public string NumberToWords(int num) {
        if(num == 0) return "Zero";

        var sb = new StringBuilder();
        if(num >= 1_000_000_000){
            var curr = num / 1_000_000_000;
            num %= 1_000_000_000;
            sb.Append(LessThanThousand(curr)).Append("Billion ");
        }

        if(num >= 1_000_000){
            var curr = num / 1_000_000;
            num %= 1_000_000;
            sb.Append(LessThanThousand(curr)).Append("Million ");
        }

        if(num >= 1_000){
            var curr = num / 1_000;
            num %= 1_000;
            sb.Append(LessThanThousand(curr)).Append("Thousand ");
        }

        sb.Append(LessThanThousand(num));
        return sb.ToString().Trim();
    }

    private string LessThanThousand(int num){
        if(num >= 1000) return "";

        string[] numbers1To19 = {
            "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine ",
            "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ",
            "Seventeen ", "Eighteen ", "Nineteen "
        };

       string[] multiplesOf10 = {
            "", "Ten ", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety "
        };

        var sb = new StringBuilder();

        if(num >= 100){
            sb.Append(numbers1To19[num / 100]).Append("Hundred ");
            num %= 100;
        }

        if(num < 20){
            sb.Append(numbers1To19[num]);
        }
        else{
            sb.Append(multiplesOf10[num / 10]);
            num %= 10;
            sb.Append(numbers1To19[num]);
        }

        return sb.ToString();
    }
}
public class Solution {
    string[] lessThan20 = {"","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine","Ten","Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
    string[] tens = {"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
    string[] thousands = {"", "Thousand", "Million", "Billion"};
    
    public string NumberToWords(int num) {
        if(num == 0) return "Zero";
        var words = "";
        
        for(int i=0; num>0; num/=1000, i++){
            if (num % 1000 != 0)
    	        words = helper(num % 1000) + thousands[i] + " " + words;
        }
        return words.Trim();
    }
    
    private string helper(int num) {
        switch(num){
            case 0:
                return "";
            case int n when n < 20:
                return lessThan20[num] + " ";
            case int n when n < 100:
                return tens[num/10] + " " + helper(num % 10);
            default:
                return lessThan20[num / 100] + " Hundred " + helper(num % 100);
        }
    }
}

//Accepted
public class SolutionBig {
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
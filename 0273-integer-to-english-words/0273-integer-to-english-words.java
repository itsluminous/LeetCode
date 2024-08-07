class Solution {
    public String numberToWords(int num) {
        String[] lessThan20 = {"","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine","Ten","Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        String[] tens = {"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
        String[] thousands = {"", "Thousand", "Million", "Billion"};

        if(num == 0) return "Zero";
        var words = "";
        for(var i=0; num>0; num /= 1000, i++){
            if(num % 1000 != 0)
                words = helper(num % 1000, lessThan20, tens, thousands) + thousands[i] + " " + words;
        }

        return words.trim();
    }

    private String helper(int num, String[] lessThan20, String[] tens, String[] thousands){
        if(num == 0) return "";
        if(num < 20) return lessThan20[num] + " ";
        if(num < 100) return tens[num / 10] + " " + helper(num % 10, lessThan20, tens, thousands);
        return lessThan20[num / 100] + " Hundred " + helper(num % 100, lessThan20, tens, thousands);
    }
}

// Accepted
class SolutionBig {
    public String numberToWords(int num) {
        if(num == 0) return "Zero";

        var sb = new StringBuilder();
        if(num >= 1_000_000_000){
            var curr = num / 1_000_000_000;
            num %= 1_000_000_000;
            sb.append(lessThanThousand(curr)).append("Billion ");
        }

        if(num >= 1_000_000){
            var curr = num / 1_000_000;
            num %= 1_000_000;
            sb.append(lessThanThousand(curr)).append("Million ");
        }

        if(num >= 1_000){
            var curr = num / 1_000;
            num %= 1_000;
            sb.append(lessThanThousand(curr)).append("Thousand ");
        }

        sb.append(lessThanThousand(num));
        return sb.toString().trim();
    }

    private String lessThanThousand(int num){
        if(num >= 1000) return "";

        String[] numbers1To19 = {
            "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine ",
            "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ",
            "Seventeen ", "Eighteen ", "Nineteen "
        };

       String[] multiplesOf10 = {
            "", "Ten ", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety "
        };
        
        

        var sb = new StringBuilder();

        if(num >= 100){
            sb.append(numbers1To19[num / 100]).append("Hundred ");
            num %= 100;
        }

        if(num < 20){
            sb.append(numbers1To19[num]);
        }
        else{
            sb.append(multiplesOf10[num / 10]);
            num %= 10;
            sb.append(numbers1To19[num]);
        }

        return sb.toString();
    }
}
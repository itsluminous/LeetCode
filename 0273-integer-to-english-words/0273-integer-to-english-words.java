class Solution {
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
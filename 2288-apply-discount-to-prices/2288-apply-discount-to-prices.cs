using System.Globalization;

public class Solution {
    public string DiscountPrices(string sentence, int discount) {
        var words = sentence.Split(" ");
        decimal disc = discount * 1.00m / 100;
        var provider = new CultureInfo("en-US");
        var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        
        for(var i=0; i<words.Length; i++){
            var w = words[i];
            if(w[0] != '$') continue;
            try
            {
                var number = 1.00m * Decimal.Parse(w, style, provider);
                number = Decimal.Round(number - number * disc, 2);
                words[i] = "$" + number.ToString();
            }
            catch (FormatException)
            {
               continue;
            }
        }
        
        var str = String.Join(" ", words);
        return str;
    }
}
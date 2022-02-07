public class Solution {
    public long SmallestNumber(long num) {
        // step 1 : get sign of number
        var sign = 1;
        if(num < 0){
            sign = -1;
            num = -1 * num;
        }
        
        // step 2 : if number is positive, sort ascending, else sort descending
        var charDigits = num.ToString().ToCharArray();
        List<char> sortedDigits = new List<char>();
        if(sign == 1) sortedDigits = charDigits.OrderBy(x => x).ToList();
        else sortedDigits = charDigits.OrderByDescending(x => x).ToList();
        
        // step 3 : if number is positive, swap first non-zero digit with first digit
        if(sign == 1 && sortedDigits[0] == '0'){
            for(var i = 0; i<sortedDigits.Count; i++){
                if(sortedDigits[i] != '0'){
                    sortedDigits[0] = sortedDigits[i];
                    sortedDigits[i] = '0';
                    break;
                }
            }
        }
        
        // step 4 : merge all the characters and then return result with appropriate sign
        var sortedString = String.Join("",sortedDigits);
        return sign*Convert.ToInt64(sortedString);
    }
}
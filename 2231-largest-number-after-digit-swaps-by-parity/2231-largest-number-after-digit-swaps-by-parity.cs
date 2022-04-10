public class Solution {
    public int LargestInteger(int num) {
        // convert number into array of single digits
        int[] arr = num.ToString().Select(o=> Convert.ToInt32(o) - 48 ).ToArray();
        
        int len = arr.Length, e=0, o=0;
        int[] evenArr = new int[len], oddArr = new int[len];
        
        // split into separate even and odd list
        foreach(var n in arr){
            if(n%2 == 0) evenArr[e++] = n;
            else oddArr[o++] = n;
        }
        
        // sort descending
        evenArr = evenArr.OrderByDescending(c => c).ToArray();
        oddArr = oddArr.OrderByDescending(c => c).ToArray();
        
        e=0; o=0;
        var result = 0;
        for(var i=0; i<len; i++){
            result *= 10;
            if(arr[i]%2 == 0) result += evenArr[e++];
            else result += oddArr[o++];
        }
        
        return result;
    }
}
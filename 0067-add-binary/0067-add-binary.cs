public class Solution {
    public string AddBinary(string a, string b) {
        var sb = new StringBuilder();
        int carry = 0;
        for(int n1=a.Length-1, n2=b.Length-1; n1>=0 || n2>=0; n1--, n2--){
            var sum = carry;
            if(n1 >= 0) sum += a[n1] - '0';
            if(n2 >= 0) sum += b[n2] - '0';
            sb.Append(sum % 2);     // if sum==2 or sum==0 append 0
            carry = sum/2;          // if sum==2 we have a carry, else no
        }
        if(carry == 1) sb.Append(carry);    // add leftover carry
        return new string(sb.ToString().Reverse().ToArray());
    }
}
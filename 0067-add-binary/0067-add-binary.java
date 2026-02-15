class Solution {
    public String addBinary(String a, String b) {
        var sb = new StringBuilder();
        int carry = 0;
        for(int n1=a.length()-1, n2=b.length()-1; n1>=0 || n2>=0; n1--, n2--){
            var sum = carry;
            if(n1 >= 0) sum += a.charAt(n1) - '0';
            if(n2 >= 0) sum += b.charAt(n2) - '0';
            sb.append(sum % 2);     // if sum==2 or sum==0 append 0
            carry = sum/2;          // if sum==2 we have a carry, else no
        }
        if(carry == 1) sb.append(carry);    // add leftover carry
        return sb.reverse().toString();
    }
}
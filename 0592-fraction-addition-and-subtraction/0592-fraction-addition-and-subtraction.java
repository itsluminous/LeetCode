class Solution {
    public String fractionAddition(String exp) {
        int ansNumr = 0, ansDenm = 0, n = exp.length();
        for(var i=0; i<n;){
            int numr = 1, denm = 1;
            if(exp.charAt(i) == '-'){
                numr = -1;
                i++;
            }
            else if(exp.charAt(i) == '+')
                i++;

            var str = new StringBuilder();
            while(i < n && Character.isDigit(exp.charAt(i)))
                str.append(exp.charAt(i++));
            numr *= Integer.parseInt(str.toString());
            i++;

            str = new StringBuilder();
            while(i < n && Character.isDigit(exp.charAt(i)))
                str.append(exp.charAt(i++));
            denm = Integer.parseInt(str.toString());

            if(ansDenm == 0){
                ansNumr = numr;
                ansDenm = denm;
            }
            else{
                ansNumr = ansNumr*denm + ansDenm*numr;
                ansDenm *= denm;
            }

            var hcf = gcd(Math.abs(ansNumr), ansDenm);
            ansNumr /= hcf;
            ansDenm /= hcf;
        }

        var ans = new StringBuilder();
        ans.append(ansNumr);
        ans.append("/");
        ans.append(ansDenm);

        return ans.toString();
    }
	
	private int gcd(int a, int b) {
		  if (b == 0) return a;
		  return gcd(b, a % b);
    }
}
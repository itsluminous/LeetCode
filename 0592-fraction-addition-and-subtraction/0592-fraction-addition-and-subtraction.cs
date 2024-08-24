public class Solution {
    public string FractionAddition(string exp) {
        int ansNumr = 0, ansDenm = 0, n = exp.Length;
        for(var i=0; i<n;){
            int numr = 1, denm = 1;
            if(exp[i] == '-'){
                numr = -1;
                i++;
            }
            else if(exp[i] == '+')
                i++;

            var str = new StringBuilder();
            while(i < n && char.IsDigit(exp[i]))
                str.Append(exp[i++]);
            numr *= int.Parse(str.ToString());
            i++;

            str = new StringBuilder();
            while(i < n && char.IsDigit(exp[i]))
                str.Append(exp[i++]);
            denm = int.Parse(str.ToString());

            if(ansDenm == 0){
                ansNumr = numr;
                ansDenm = denm;
            }
            else{
                ansNumr = ansNumr*denm + ansDenm*numr;
                ansDenm *= denm;
            }

            var hcf = GCD(Math.Abs(ansNumr), ansDenm);
            ansNumr /= hcf;
            ansDenm /= hcf;
        }

        var ans = new StringBuilder();
        ans.Append(ansNumr);
        ans.Append("/");
        ans.Append(ansDenm);

        return ans.ToString();
    }
	
	private int GCD(int a, int b) {
		  if (b == 0) return a;
		  return GCD(b, a % b);
    }
}
class Solution {
    public int NumSteps(string s) {
        int steps = 0, carry = 0;

        // carry will never become zero once it changes to 1, because of how the rules are in question
        for(var i = s.Length-1; i > 0; i--){
            if(s[i] - '0' + carry == 1){
                steps += 2; // one step to add 1, and one step to divide by 2
                carry = 1;
            } else {
                steps += 1;
            }
        }

        return steps + carry;
    }
}

// This fails for really long string, because conversion to long fails
// Eg. 1111110011101010110011100100101110010100101110111010111110110010
class SolutionFailed {
    public int NumSteps(string s) {
        var num = Convert.ToInt64(s, 2);

        var steps = 0;
        while(num != 1){
            if((num & 1) == 1) num++;
            else num >>= 1;
            steps++;
        }

        return steps;
    }
}
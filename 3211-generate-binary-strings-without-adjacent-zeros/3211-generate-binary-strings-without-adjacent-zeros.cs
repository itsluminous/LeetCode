public class Solution {
    List<string> ans = new();

    public IList<string> ValidStrings(int n) {
        Helper(n, new StringBuilder());
        return ans;
    }

    private void Helper(int n, StringBuilder sb){
        if(n == 0){
            ans.Add(sb.ToString());
            return;
        }

        if(sb.Length == 0 || sb[sb.Length - 1] == '1'){
            sb.Append('0');
            Helper(n-1, sb);
            sb.Length--;
        }

        sb.Append('1');
        Helper(n-1, sb);
        sb.Length--;
    }
}
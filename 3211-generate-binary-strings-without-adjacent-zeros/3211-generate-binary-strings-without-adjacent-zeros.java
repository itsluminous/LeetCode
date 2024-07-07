class Solution {
    List<String> ans = new ArrayList<>();

    public List<String> validStrings(int n) {
        helper(n, new StringBuilder());
        return ans;
    }

    private void helper(int n, StringBuilder sb){
        if(n == 0){
            ans.add(sb.toString());
            return;
        }

        if(sb.isEmpty() || sb.charAt(sb.length() - 1) == '1'){
            sb.append('0');
            helper(n-1, sb);
            sb.deleteCharAt(sb.length() - 1);
        }

        sb.append('1');
        helper(n-1, sb);
        sb.deleteCharAt(sb.length() - 1);
    }
}
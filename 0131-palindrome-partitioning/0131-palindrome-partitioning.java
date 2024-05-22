class Solution {
    List<List<String>> ans;

    public List<List<String>> partition(String s) {
        ans = new ArrayList<>();
        partition(s, 0, new ArrayList<String>());
        return ans;
    }

    private void partition(String s, int start, List<String> curr){
        if(start == s.length()){
            ans.add(new ArrayList(curr));
            return;
        }

        for(var i=start; i<s.length(); i++){
            if(!isPalindrome(s, start, i)) continue;
            curr.add(s.substring(start, i+1));
            partition(s, i+1, curr);
            curr.remove(curr.size() - 1);
        }
    }

    private boolean isPalindrome(String s, int left, int right){
        while(left < right)
            if(s.charAt(left++) != s.charAt(right--))
                return false;
        return true;
    }
}
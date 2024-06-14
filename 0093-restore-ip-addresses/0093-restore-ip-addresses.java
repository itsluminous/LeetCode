class Solution {
    List<String> ans;
    public List<String> restoreIpAddresses(String s) {
        ans = new ArrayList<>();
        backtrack(s, new StringBuilder(), 4, 0);
        return ans;
    }

    private void backtrack(String s, StringBuilder curr, int parts, int idx){
        var n = s.length();
        if(idx == n || n < parts) return;
        if(parts == 1 && idx < n){
            var partStr = s.substring(idx);
            if(partStr.length() > 3) return;
            var part = Integer.parseInt(partStr);
            if(part > 255 || !partStr.equals(Integer.toString(part))) return;
            
            var prevLength = curr.length();
            curr.append(partStr);
            ans.add(curr.toString());
            curr.setLength(prevLength);
            return;
        }

        for(var i=1; i<=3 && idx+i < n; i++){
            var partStr = s.substring(idx, idx+i);
            var part = Integer.parseInt(partStr);
            if(part > 255 || !partStr.equals(Integer.toString(part))) continue;

            var prevLength = curr.length();
            curr.append(partStr);
            curr.append(".");
            backtrack(s, curr, parts-1, idx+i);
            curr.setLength(prevLength);
        }
    }
}
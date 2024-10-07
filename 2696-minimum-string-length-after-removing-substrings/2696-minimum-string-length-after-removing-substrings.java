class Solution {
    public int minLength(String s) {
        var stack = new Stack<Character>();
        for(var ch : s.toCharArray()){
            if(stack.isEmpty())
                stack.push(ch);
            else if(stack.peek() == 'A' && ch == 'B')
                stack.pop();
            else if(stack.peek() == 'C' && ch == 'D')
                stack.pop();
            else
                stack.push(ch);
        }
        return stack.size();
    }
}

class SolutionNoStack {
    public int minLength(String s) {
        int n = s.length(), l = 0, r = 1;
        var len = n;
        while(r < n){
            if((s.charAt(l) == 'A' && s.charAt(r) == 'B') || (s.charAt(l) == 'C' && s.charAt(r) == 'D')){
                len -= 2;
                if(l > 0) l--;
            }
            else{
                l = r;
            }
            r++;
        }

        return len;
    }
}
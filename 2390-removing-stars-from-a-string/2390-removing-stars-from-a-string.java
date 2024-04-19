public class Solution {
    public String removeStars(String s) {
        var stack = new ArrayList<Character>();
        for(var ch : s.toCharArray())
            if(ch == '*') stack.remove(stack.size()-1);
            else stack.add(ch);
        return new String(stack.stream().mapToInt(c -> c).toArray(), 0, stack.size());
    }
}
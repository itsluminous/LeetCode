class Solution {
    int points = 0;

    public int maximumGain(String s, int x, int y) {
        var bigger = x > y ? "ab" : "ba";
        var smaller = bigger.equals("ab") ? "ba" : "ab";
        var pointmap = Map.of("ab", x, "ba", y);

        s = match(s, bigger, pointmap.get(bigger));
        match(s, smaller, pointmap.get(smaller));

        return points;
    }

    private String match(String s, String target, int point){
        var stack = new Stack<Character>();
        for(var ch : s.toCharArray()){
            if(ch == target.charAt(1) && !stack.isEmpty() && stack.peek() == target.charAt(0)){
                stack.pop();
                points += point;
            }
            else
                stack.push(ch);
        }

        var sb = new StringBuilder();
        while(!stack.isEmpty())
            sb.append(stack.pop());
        return sb.reverse().toString();
    }
}
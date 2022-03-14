public class Solution {
    public string SimplifyPath(string path) {
        var split = path.Split("/");
        var stack = new Stack<string>();
        foreach(var word in split){
            if(String.IsNullOrEmpty(word) || word == ".")
                continue;
            else if(word == "..")
                { if(stack.Count > 0) stack.Pop(); }
            else
                stack.Push(word);
        }
        
        if(stack.Count == 0)
            return "/";
        
        // stack2 to reverse the path
        var stack2 = new Stack<string>();
        var count = stack.Count;
        for(var i=0; i<count; i++)
            stack2.Push(stack.Pop());
        
        // pop all dirs from stack2 and add it to result
        var sb = new StringBuilder();
        for(var i=0; i<count; i++){
            sb.Append("/");
            sb.Append(stack2.Pop());
        }
        
        return sb.ToString();
    }
}
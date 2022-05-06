public class Solution {
    public string RemoveDuplicates(string s, int k) 
    {
	   Stack<(char c, int frequency)> stack = new Stack<(char, int)>();

		foreach (char c in s)
		{
			if (stack.Count > 0 && stack.Peek().c == c)
			{
				var top = stack.Pop();
				top.frequency++;

				if (top.frequency != k)
				{
					stack.Push(top);
				}
			}
			else
			{
				stack.Push((c, 1));
			}
		}

		StringBuilder result = new StringBuilder();
		var resultList = stack.ToArray().Reverse();
		foreach ((char c, int frequency) in resultList)            
		{
			result.Append(c, frequency);
		}
		return result.ToString();
    }
    
    public string RemoveDuplicates1(string s, int k) {
        int n = s.Length, currLen = 0;
        char curr = '0';
        StringBuilder sb = new StringBuilder(), currsb = new StringBuilder();
        
        while(s.Length > 0){
            for(var i=0; i<n; i++){
                if(currLen == 0){       // starting new substring
                    curr = s[i];
                    currLen++;
                    currsb.Append(s[i]);
                }
                else if(s[i] == curr){  // if curr char is part of existing substring
                    currLen++;
                    currsb.Append(s[i]);
                }   
                else{                   // if curr char is different from prev substring
                    Console.WriteLine($"currsb={currsb.ToString()}");
                    if(currsb.Length < k)
                        sb.Append(currsb);
                    else{
                        var remaining = currsb.Length % k;
                        sb.Append(currsb.ToString(0, remaining));
                    }
                    currsb = new StringBuilder();
                    currLen = 0;
                    curr = '0';
                }
            }
            var newstr = sb.ToString();
            Console.WriteLine($"s={s}, newstr={newstr}");
            if(newstr.Equals(s)) break; // cannot minify now
            s = newstr;
        }
        return s;
    }
}



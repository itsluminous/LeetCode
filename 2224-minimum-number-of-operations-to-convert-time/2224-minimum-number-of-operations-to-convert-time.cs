public class Solution {
    public int ConvertTime(string current, string correct) {
        var curr = current.Split(":");
        var corr = correct.Split(":");
        
        int currH = Convert.ToInt32(curr[0]), currM = Convert.ToInt32(curr[1]);
        int corrH = Convert.ToInt32(corr[0]), corrM = Convert.ToInt32(corr[1]);
        
        int currMin = 60*currH + currM, corrMin = 60*corrH + corrM;
        var diff = corrMin - currMin;
        var operations = new []{60, 15, 5, 1};
        
        var steps = 0;
        foreach(var op in operations){
            steps += diff/op;
            diff %= op;
        }
          
        return steps;
    }
}

// Accepted - Too complicated to read
public class Solution1 {
    Dictionary<int, (int, int)> dict = new Dictionary<int, (int, int)>();
    int minSt= int.MaxValue;

    public int ConvertTime(string current, string correct) {
        var curr = current.Split(":");
        var corr = correct.Split(":");

        int currH = Convert.ToInt32(curr[0]), currM = Convert.ToInt32(curr[1]);
        int corrH = Convert.ToInt32(corr[0]), corrM = Convert.ToInt32(corr[1]);

        var ans = 0;
        var (st, hr) = ConvertM(currM, corrM, 0, 0);
        ans += st;
        currH += hr;
        ans += ConvertH(currH, corrH);

        return ans;
    }

    private (int, int) ConvertM(int curr, int corr, int steps, int addHour){
        if(curr >= 60){
            curr %= 60;
            addHour++;
        }
        if(steps > minSt) return (int.MaxValue, 0);
        // Console.WriteLine($"curr={curr}, corr={corr}, steps = {steps}, hr = {addHour}");

        if(dict.ContainsKey(curr) && dict[curr].Item1 < steps) return dict[curr];
        if(curr == corr){
            minSt = Math.Min(minSt, steps);
            return (steps, addHour);
        }

        steps++;
        var st1 = ConvertM(curr+1, corr, steps, addHour);
        var st5 = ConvertM(curr+5, corr, steps, addHour);
        var st15 = ConvertM(curr+15, corr, steps, addHour);

        if (st1.Item1 < st5.Item1){
            var currst = st1.Item1 < st15.Item1 ? st1 : st15;
            minSt = Math.Min(minSt, currst.Item1);
            dict[curr] = currst;
            return currst;
        }
        else{
            var currst = st5.Item1 < st15.Item1 ? st5 : st15;
            minSt = Math.Min(minSt, currst.Item1);
            dict[curr] = currst;
            return currst;
        }
    }

    private int ConvertH(int curr, int corr){
        if(curr <= corr)
            return (corr - curr);

        var steps = 0;
        do{
            curr++;
            steps++;
        } while(curr % 24 != corr);
        return steps;
    }
}
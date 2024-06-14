public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        int n = words.Length;
        var ans = new List<string>();

        var curr = new List<string>();
        int currWordLen = 0, currMinSpace = -1;
        foreach (var word in words)
        {
            if (currWordLen + currMinSpace + 1 + word.Length <= maxWidth)
            {
                curr.Add(word);
                currWordLen += word.Length;
                currMinSpace++;
            }
            else
            {
                ans.Add(ListToString(curr, maxWidth - currWordLen, false));
                curr = new List<string>();
                curr.Add(word);
                currWordLen = word.Length;
                currMinSpace = 0;
            }
        }

        ans.Add(ListToString(curr, maxWidth - currWordLen, true));
        return ans;
    }

    private string ListToString(List<string> list, int totalSpace, bool last)
    {
        Console.WriteLine(list[0] + " : space=" + totalSpace + ", n=" + list.Count);
        var n = list.Count;
        var sb = new StringBuilder();
        sb.Append(list[0]);
        if (n == 1)
        {
            sb.Append(Space(totalSpace));
            return sb.ToString();
        }

        if (last)
        {
            for (var i = 1; i < n; i++)
            {
                sb.Append(" ");
                totalSpace--;
                sb.Append(list[i]);
            }
            sb.Append(Space(totalSpace));
            return sb.ToString();
        }

        var spaceBetween = totalSpace / (n - 1);
        var spaceExtra = totalSpace % (n - 1);
        for (var i = 1; i < n; i++)
        {
            sb.Append(Space(spaceBetween));
            if (spaceExtra > 0)
            {
                sb.Append(" ");
                spaceExtra--;
            }
            sb.Append(list[i]);
        }

        return sb.ToString();
    }

    private string Space(int count)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < count; i++)
            sb.Append(" ");
        return sb.ToString();
    }
}
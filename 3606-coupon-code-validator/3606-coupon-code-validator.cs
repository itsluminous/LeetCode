public class Solution {
    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive) {
        var blPriority = new Dictionary<string, int>
        {
            ["electronics"] = 0,
            ["grocery"] = 1,
            ["pharmacy"] = 2,
            ["restaurant"] = 3
        };

        return Enumerable.Range(0, code.Length)
            .Where(i => isActive[i]
                        && blPriority.ContainsKey(businessLine[i])
                        && IsValidCode(code[i]))
            .Select(i => (Priority: blPriority[businessLine[i]], Code: code[i]))
            .OrderBy(x => x.Priority)
            .ThenBy(x => x.Code, StringComparer.Ordinal)
            .Select(x => x.Code)
            .ToList();
    }

    private bool IsValidCode(string code)
    {
        if (string.IsNullOrEmpty(code)) return false;
        return code.All(ch => char.IsLetterOrDigit(ch) || ch == '_');
    }
}
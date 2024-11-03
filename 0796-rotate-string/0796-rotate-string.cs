public class Solution {
    public bool RotateString(string s, string goal) {
        if(s.Length != goal.Length) return false;

        s += s;
        return s.IndexOf(goal) >= 0;
    }
}
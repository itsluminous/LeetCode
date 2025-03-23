public class Solution {
    public long MinTime(int[] skill, int[] mana) {
        int n = skill.Length, m = mana.Length;

        // completionTime = time when each wizard completed potion
        var completionTime = new long[n];
        completionTime[0] = skill[0] * mana[0];
        for(var i=1; i<n; i++)
            completionTime[i] = completionTime[i-1] + skill[i] * mana[0];

        // now for potion 1 onwards, find out time taken
        for(var p=1; p<m; p++){
            // a wizard can start either after finishing time of prev potion or after prev wizard hands over
            completionTime[0] += skill[0] * mana[p];
            for(var i=1; i<n; i++)
                completionTime[i] = Math.Max(completionTime[i], completionTime[i-1]) + skill[i] * mana[p];

            // retrospectively update timings for prev wizards
            for(var i=n-2; i>=0; i--)
                completionTime[i] = completionTime[i+1] - skill[i+1] * mana[p];
        }

        // ans will be time when last wizard finishes last potion
        return completionTime[^1];
    }
}

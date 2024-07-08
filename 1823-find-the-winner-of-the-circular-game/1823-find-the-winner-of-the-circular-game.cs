// O(n)
public class Solution {
    public int FindTheWinner(int n, int k) {
        var idx = 0;    // for only 1 person, ans is person at idx 0 (i.e. person 1)
        
        for(var i=2; i<=n; i++)
            idx = (idx + k) % i;    // ans if there are "i" people in circle

        return idx + 1; // person at idx 0 is person 1, similarly for other idx
    }
}

// accepted - simulation - O(n^2)
public class SolutionSim {
    public int FindTheWinner(int n, int k) {
        var players = new LinkedList<int>();
        for(var i=1; i<=n; i++) players.AddLast(i);

        k--;    // for 0-indeing
        var idx = 0;
        while(players.Count > 1){
            idx = (idx + k) % players.Count;
            RemoveAt(idx, players);
        }

        return players.First.Value;
    }

    private void RemoveAt(int idx, LinkedList<int> players){
        var p = players.First;
        for(var i=0; i<idx; i++)
            p = p.Next;
        players.Remove(p);
    }
}
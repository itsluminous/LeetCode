// O(n)
class Solution {
    public int findTheWinner(int n, int k) {
        var idx = 0;    // for only 1 person, ans is person at idx 0 (i.e. person 1)
        
        for(var i=2; i<=n; i++)
            idx = (idx + k) % i;    // ans if there are "i" people in circle

        return idx + 1; // person at idx 0 is person 1, similarly for other idx
    }
}

// accepted - simulation - O(n^2)
class SolutionSim {
    public int findTheWinner(int n, int k) {
        var players = new LinkedList<Integer>();
        for(var i=1; i<=n; i++) players.add(i);

        k--;    // for 0-indeing
        var idx = 0;
        while(players.size() > 1){
            idx = (idx + k) % players.size();
            players.remove(idx);
        }

        return players.get(0);
    }
}
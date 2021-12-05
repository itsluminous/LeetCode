// Explaination - https://www.youtube.com/watch?v=WYqsg5dziaQ
public class Solution {
    Dictionary<string, SortedList<string, string>> flights = new Dictionary<string, SortedList<string, string>>();
    List<string> path = new List<string>();

    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        // Create adjacency list which tells which all airports are destination for a given airport
        var comparer = new DuplicateKeyComparer<string>();
        foreach(var ticket in tickets){
            Console.WriteLine($"{ticket[0]} - {ticket[1]}");
            if(!flights.ContainsKey(ticket[0])) flights[ticket[0]] = new SortedList<string, string>(comparer);
            flights[ticket[0]].Add(ticket[1], ticket[1]);
        }
        Travel("JFK");
        return path;
    }

    private void Travel(string airport){
        // Perform a DFS on all connected airports
        var destinations = flights.ContainsKey(airport) ? flights[airport] : null;
        while(destinations != null && destinations.Count > 0){
            var dest = destinations.Values[0];
            destinations.RemoveAt(0);
            Travel(dest);
        }

        // Insert at beginning else you will get path in reverse
        path.Insert(0, airport);
    }
}

// Custome comparer to allow duplicates in sorted list
// Eg for : [["TIA","ANU"],["ANU","JFK"],["JFK","ANU"],["ANU","EZE"],["TIA","ANU"]]
public class DuplicateKeyComparer<TKey> :IComparer<TKey> where TKey : IComparable
{
    public int Compare(TKey x, TKey y)
    {
        int result = x.CompareTo(y);
        if (result == 0) return 1; // Handle equality as being greater.
        return result;
    }
}
public class Solution
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        var owner = new Dictionary<string, string>();                // maps all emails to a user
        var mailAlias = new Dictionary<string, SortedSet<string>>(); // key = parent email, value = alias mails
        var uf = new UnionFind();

        // initialize the owner and add emails to UnionFind
        foreach (var acc in accounts) {
            for (var i = 1; i < acc.Count; i++) {
                uf.Add(acc[i]);                               // add email to UnionFind
                owner[acc[i]] = acc[0];                       // key is email, value is owner's name
            }
        }

        // Union emails associated with the same account
        foreach (var acc in accounts) {
            var primaryEmail = acc[1];
            for (var i = 2; i < acc.Count; i++)
                uf.Union(primaryEmail, acc[i]);
        }

        // group emails by their root parent
        foreach (var acc in accounts) {
            var primaryEmail = acc[1];
            var root = uf.Find(primaryEmail);
            if (!mailAlias.ContainsKey(root))
                mailAlias[root] = new SortedSet<string>(StringComparer.Ordinal);
            
            // add each email to the corresponding root group
            for (var i = 1; i < acc.Count; i++)
                mailAlias[root].Add(acc[i]);                   
        }

        // create final result set
        var result = new List<IList<string>>();
        foreach (var key in mailAlias.Keys) {
            var emails = mailAlias[key].ToList();
            emails.Insert(0, owner[key]);                    // insert owner's name at the beginning
            result.Add(emails);
        }

        return result;
    }
}

public class UnionFind
{
    private Dictionary<string, string> parents;

    public UnionFind()
    {
        parents = new Dictionary<string, string>();
    }

    public void Add(string s)
    {
        if (!parents.ContainsKey(s))
            parents[s] = s; // Initially, each email is its own parent
    }

    public string Find(string s)
    {
        if (parents[s] != s)
            parents[s] = Find(parents[s]);
        return parents[s];
    }

    public void Union(string s1, string s2)
    {
        string root1 = Find(s1);
        string root2 = Find(s2);
        if (root1 != root2)
            parents[root2] = root1;
    }
}

class Solution {
    public List<List<String>> accountsMerge(List<List<String>> accounts) {
        var owner = new HashMap<String, String>();                  // maps all emails to a user
        var mailAlias = new HashMap<String, TreeSet<String>>();     // key = parent email, value = alias mails
        var uf = new UnionFind();

        // initialize the owner and add emails to UnionFind
        for (var acc : accounts) {
            for (var i = 1; i < acc.size(); i++) {
                uf.add(acc.get(i));                 // add email to UnionFind
                owner.put(acc.get(i), acc.get(0));  // key is email, value is owner's name
            }
        }

        // Union emails associated with the same account
        for (var acc : accounts) {
            var primaryEmail = acc.get(1);
            for (var i = 2; i < acc.size(); i++)
                uf.union(primaryEmail, acc.get(i));
        }

        // group emails by their root parent
        for (var acc : accounts) {
            var primaryEmail = acc.get(1);
            var root = uf.find(primaryEmail);
            mailAlias.putIfAbsent(root, new TreeSet<>());
            
            // add each email to the corresponding root group
            for (var i = 1; i < acc.size(); i++)
                mailAlias.get(root).add(acc.get(i));                   
        }

        // create final result set
        var result = new ArrayList<List<String>>();
        for (var key : mailAlias.keySet()) {
            var emails = new ArrayList(mailAlias.get(key));
            emails.add(0, owner.get(key));                    // insert owner's name at the beginning
            result.add(emails);
        }

        return result;
    }
}

public class UnionFind{
    private HashMap<String, String> parents;

    public UnionFind() {
        parents = new HashMap<String, String>();
    }

    public void add(String s) {
        if (!parents.containsKey(s))
            parents.put(s, s); // Initially, each email is its own parent
    }

    public String find(String s) {
        if (parents.get(s) != s)
            parents.put(s, find(parents.get(s)));
        return parents.get(s);
    }

    public void union(String s1, String s2) {
        String root1 = find(s1);
        String root2 = find(s2);
        if (root1 != root2)
            parents.put(root2, root1);
    }
}
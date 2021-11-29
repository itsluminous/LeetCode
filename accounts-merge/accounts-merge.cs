public class Solution {
    Dictionary<string,string> parents;
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        var owner = new Dictionary<string, string>();               // maps all emails to a user
        parents = new Dictionary<string,string>();                  // maps parent mail id for each mail id
        var uf = new Dictionary<string,SortedSet<string>>();        // get all emails from one primary email id
        
        // initialize parents & owner
        foreach(var acc in accounts){
            for (var i = 1; i < acc.Count; i++) {
                parents[acc[i]] = acc[i];           // all are self parent initially
                owner[acc[i]] = acc[0];             // key is email and value is owner name
            }
        }
        
        // put all emails associated to same parent email in one set
        foreach(var acc in accounts){
            var p = Find(acc[1]);
            for (var i = 2; i < acc.Count; i++) {
                var curr = Find(acc[i]);
                parents[curr] = p;
            }
        }
        
        // for each parent mail id, create a sorted set of linked mail ids
        foreach(var acc in accounts){
            var p = Find(acc[1]);
            if(!uf.ContainsKey(p))
                uf[p] = new SortedSet<string>(StringComparer.Ordinal);
            for (var i = 1; i < acc.Count; i++)
                uf[p].Add(acc[i]);
        }
        
        // create final result set
        var result = new List<IList<string>>();
        foreach(var key in uf.Keys){
            var emails = uf[key].ToList();
            emails.Insert(0, owner[key]);   // Add name of person who owns all these emails
            result.Add(emails);
        }
        
        return result;
    }
    
    private string Find(string s){
        if(parents[s] != s)
            parents[s] = Find(parents[s]);
        return parents[s];
    }
}
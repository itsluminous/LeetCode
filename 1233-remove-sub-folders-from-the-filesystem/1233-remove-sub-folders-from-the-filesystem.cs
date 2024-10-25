public class Solution {
    public IList<string> RemoveSubfolders(string[] folder) {
        Array.Sort(folder);
        var parents = new List<string>();

        var parent = "foo";
        foreach(var path in folder){
            if(path.StartsWith(parent + "/")) continue;
            parent = path;
            parents.Add(parent);
        }

        return parents;
    }
}
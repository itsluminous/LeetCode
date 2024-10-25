class Solution {
    public List<String> removeSubfolders(String[] folder) {
        Arrays.sort(folder);
        var parents = new ArrayList<String>();

        var parent = "foo";
        for(var path : folder){
            if(path.startsWith(parent + "/")) continue;
            parent = path;
            parents.add(parent);
        }

        return parents;
    }
}
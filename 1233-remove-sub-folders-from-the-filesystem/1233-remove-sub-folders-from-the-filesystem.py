class Solution:
    def removeSubfolders(self, folder: List[str]) -> List[str]:
        folder.sort()
        parents = []

        parent = "foo"
        for path in folder:
            if path.startswith(parent + "/"): continue
            parent = path
            parents.append(parent)

        return parents
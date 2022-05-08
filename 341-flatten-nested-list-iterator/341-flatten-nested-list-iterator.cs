public class NestedIterator {
    
    List<int> flatList = new List<int>();
    int idx = 0;

    public NestedIterator(IList<NestedInteger> nestedList) {
        foreach(var nestedItem in nestedList){
            if(nestedItem.IsInteger())
                flatList.Add(nestedItem.GetInteger());
            else
                AddItems(nestedItem);
        }
    }

    public bool HasNext() {
        return idx < flatList.Count;
    }

    public int Next() {
        return flatList[idx++];
    }
    
    private void AddItems(NestedInteger nestedInteger){
        if(nestedInteger.IsInteger())
            flatList.Add(nestedInteger.GetInteger());
        else
            foreach(var nestInt in nestedInteger.GetList())
                AddItems(nestInt);
    }
}

/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
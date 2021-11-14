public class CombinationIterator {
    List<string> list = new List<string>();
    int index=0;
    public CombinationIterator(string characters, int combinationLength) {
        GetCombinations(characters, combinationLength, 0, new StringBuilder());
        list.Sort();    // to get items alphabetically
    }
    
    private void GetCombinations(string characters, int len, int start, StringBuilder sb){
        // if substring is of enough size, we add it to list
        if(len == 0){
            list.Add(sb.ToString());
            return;
        }
        // continue looking for combination
        for(int i=start; i+len<=characters.Length; i++){
            sb.Append(characters[i]);
            GetCombinations(characters, len-1, i+1, sb);
            sb.Length--;    // delete the i-th char
        }
    }
    
    public string Next() {
        return list[index++];
    }
    
    public bool HasNext() {
        return !(index == list.Count);
    }
}

/**
 * Your CombinationIterator object will be instantiated and called as such:
 * CombinationIterator obj = new CombinationIterator(characters, combinationLength);
 * string param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
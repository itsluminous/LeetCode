public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        var trie = new Trie();
        trie.Build(products);
        return trie.Search(searchWord);
    }
}

public class Trie{
    List<string> suggestions;
    Trie[] next;

    public Trie(){
        suggestions = new List<string>();
        next = new Trie[26];
    }

    public void AddSuggestion(string word){
        suggestions.Add(word);
        suggestions = suggestions.OrderBy(w => w).Take(3).ToList();
    }

    public void Build(string[] words){
        foreach(var word in words){
            var curr = next;
            foreach(var ch in word){
                if(curr[ch-'a'] == null)  curr[ch-'a'] = new Trie();
                curr[ch-'a'].AddSuggestion(word);
                curr = curr[ch-'a'].next;
            }
        }
    }

    public IList<IList<string>> Search(string word){
        var result = new List<IList<string>>();
        var curr = next;
        foreach(var ch in word){
            if(curr == null || curr[ch-'a'] == null){
                result.Add([]);
                curr = null;    // mark it so that now onwards no substring will be checked
                continue;
            }
            result.Add(curr[ch-'a'].suggestions);
            curr = curr[ch-'a'].next;
        }

        return result;
    }
}
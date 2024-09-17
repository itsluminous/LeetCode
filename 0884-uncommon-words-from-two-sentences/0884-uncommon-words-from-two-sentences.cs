public class Solution {
    public string[] UncommonFromSentences(string s1, string s2) {
        var (s1words, s1once) = MakeSets(s1);
        var (s2words, s2once) = MakeSets(s2);

        s1once.ExceptWith(s2words);
        s2once.ExceptWith(s1words);
        s1once.UnionWith(s2once);
        
        return s1once.ToArray();
    }

    private (HashSet<string>, HashSet<string>) MakeSets(string s){
        HashSet<string> words = new(), once = new();

        foreach(var word in s.Split(" "))
            if(once.Contains(word))
                once.Remove(word);
            else if(words.Add(word))
                once.Add(word);

        return (words, once);
    }
}
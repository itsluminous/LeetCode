class Solution {
    public List<List<String>> findLadders(String beginWord, String endWord, List<String> wordList) {
        var words = new HashSet<String>(wordList);
        var visited = new HashSet<String>();
        Map<String, List<String>> prevWordMap = new HashMap<>();     // to find prev word for any given word
        var hasEnd = false;  // to know if endWord is possible or not

        if(!words.contains(endWord)) return new ArrayList<>();
        
        // BFS to reach end word and track all relationships in prevWordMap
        Queue<String> queue = new LinkedList<>();
        queue.offer(beginWord);

        while(!queue.isEmpty()){
            var levelvisit = new HashSet<String>();  // words visited in curr level, using set to avoid duplicates
            for(var k=queue.size(); k>0; k--){
                var word = queue.poll();

                if(word.equals(endWord)){
                    hasEnd = true;
                    break;  // because we are not interested in any sequence bigger than shortest
                }
                
                for(var i=0; i<word.length(); i++){
                    var chars = word.toCharArray();
                    for(var ch='a'; ch<='z'; ch++){
                        chars[i] = ch;
                        var newWord = new String(chars);
                        if(!words.contains(newWord) || visited.contains(newWord)) continue;

                        levelvisit.add(newWord);
                        prevWordMap.putIfAbsent(newWord, new ArrayList<>());
                        prevWordMap.get(newWord).add(word);
                    }
                }
            }
            
            visited.addAll(levelvisit);
            queue.addAll(levelvisit);
        }
        
        if(!hasEnd) return new ArrayList<>();

        // DFS to backtrack path from endWord to beginWord
        List<List<String>> ans = new ArrayList<>();
        List<String> path = new ArrayList<>();
        
        dfs(endWord, beginWord, prevWordMap, path, ans);
        return ans;
    }

    private void dfs(String word, String beginWord, Map<String, List<String>> prevWordMap, 
                     List<String> path, List<List<String>> ans){
        path.add(word);
        if(word.equals(beginWord)){
            var newPath = new ArrayList<>(path);
            Collections.reverse(newPath);
            ans.add(newPath);
        }
        else{
            for(var next : prevWordMap.get(word))
                dfs(next, beginWord, prevWordMap, path, ans);
        }
            
        path.remove(path.size() - 1);
    }
}
class Solution {
    public int ladderLength(String beginWord, String endWord, List<String> wordList) {
        var set = new HashSet<String>(wordList);

        Queue<String> queue = new LinkedList<>();
        queue.offer(beginWord);

        for(var steps=2; !queue.isEmpty(); steps++){
            for(var count=queue.size(); count >0; count--){
                var word = queue.poll();
                var found = transformWord(word, endWord, queue, set);
                if(found) return steps;
            }
        }

        return 0;
    }

    private boolean transformWord(String startWord, String endWord, Queue<String> queue, HashSet<String> set){
        // try to replace every char in startWord one by one
        for(var i=0; i<startWord.length(); i++){
            var chars = startWord.toCharArray();
            for(var j=0; j<26; j++){
                chars[i] = (char)('a' + j);
                var newWord = new String(chars);
                if(set.contains(newWord)){
                    if(newWord.equals(endWord)) return true;
                    queue.offer(newWord);
                    set.remove(newWord);
                }
            }
        }

        return false;
    }
}
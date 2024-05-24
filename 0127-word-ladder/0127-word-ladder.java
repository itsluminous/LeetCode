class Solution {
    public int ladderLength(String beginWord, String endWord, List<String> wordList) {
        var set = new HashSet<String>(wordList);
        if(!set.contains(endWord)) return 0;

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

    // try to replace every char in startWord one by one
    private boolean transformWord(String startWord, String endWord, Queue<String> queue, HashSet<String> set){
        for(var i=0; i<startWord.length(); i++){
            var chars = startWord.toCharArray();
            for(var ch='a'; ch<='z'; ch++){
                chars[i] = ch;
                var newWord = new String(chars);
                if(newWord.equals(endWord)) return true;
                
                if(set.contains(newWord)){
                    queue.offer(newWord);
                    set.remove(newWord);
                }
            }
        }

        return false;
    }
}
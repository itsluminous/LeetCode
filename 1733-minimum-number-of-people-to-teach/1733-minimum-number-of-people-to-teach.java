class Solution {
    public int minimumTeachings(int n, int[][] languages, int[][] friendships) {
        var needToLearn = new HashSet<Integer>();
        for(var friendship : friendships){
            int f0 = friendship[0] - 1, f1 = friendship[1] - 1;    // convert to 0-based indexing
            
            // check if there is any common language
            var knownLang = new HashSet<Integer>();
            for(var lang : languages[f0]) knownLang.add(lang);

            var matchFound = false;
            for(var lang : languages[f1]){
                if(knownLang.contains(lang)){
                    matchFound = true;
                    break;
                }
            }

            if(matchFound) continue;    // no effort needed
            needToLearn.add(f0);
            needToLearn.add(f1);
        }

        // find out language that most people speak, out of those who need to learn
        var maxCount = 0;
        var langCount = new int[n+1];   // indicates how many people speak a language
        for(var f : needToLearn){
            for(var lang : languages[f]){
                langCount[lang]++;
                maxCount = Math.max(maxCount, langCount[lang]);
            }
        }

        return needToLearn.size() - maxCount;   // these many people need to learn the maxCount language
    }
}
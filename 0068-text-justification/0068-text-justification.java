class Solution {
    public List<String> fullJustify(String[] words, int maxWidth) {
        var n = words.length;
        var ans = new ArrayList<String>();
        
        var curr = new ArrayList<String>();
        int currWordLen = 0, currMinSpace = -1;
        for(var word : words){
            if(currWordLen + currMinSpace + 1 + word.length() <= maxWidth){
                curr.add(word);
                currWordLen += word.length();
                currMinSpace++;
            }
            else{
                ans.add(listToString(curr, maxWidth - currWordLen, false));
                curr = new ArrayList<String>();
                curr.add(word);
                currWordLen = word.length();
                currMinSpace = 0;
            }
        }

        ans.add(listToString(curr, maxWidth - currWordLen, true));
        return ans;
    }

    private String listToString(ArrayList<String> list, int totalSpace, boolean last){
        System.out.println(list.get(0) + " : space=" + totalSpace + ", n=" + list.size());
        var n = list.size();
        var sb = new StringBuilder();
        sb.append(list.get(0));
        if(n == 1){
            sb.append(space(totalSpace));
            return sb.toString();
        }

        if(last){
            for(var i=1; i<n; i++){
                sb.append(" ");
                totalSpace--;
                sb.append(list.get(i));
            }
            sb.append(space(totalSpace));
            return sb.toString();
        }

        var spaceBetween = totalSpace / (n-1);
        var spaceExtra = totalSpace % (n-1);
        for(var i=1; i<n; i++){
            sb.append(space(spaceBetween));
            if(spaceExtra > 0){
                sb.append(" ");
                spaceExtra--;
            }
            sb.append(list.get(i));
        }

        return sb.toString();
    }

    private String space(int count){
        var sb = new StringBuilder();
        for(var i=0; i<count; i++)
            sb.append(" ");
        return sb.toString();
    }
}
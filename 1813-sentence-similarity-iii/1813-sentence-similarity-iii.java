class Solution {
    public boolean areSentencesSimilar(String sentence1, String sentence2) {
        String[] shoort = sentence1.split(" "), loong = sentence2.split(" ");
        if(shoort.length > loong.length){
            var tmp = shoort;
            shoort = loong;
            loong = tmp;
        }
        
        int sl = 0, sr = shoort.length-1;
        int ll = 0, lr = loong.length-1;
        while(sl <= sr && shoort[sl].equals(loong[ll])){
            sl++; ll++;
        }
        while(sr >= 0 && shoort[sr].equals(loong[lr])){
            sr--; lr--;
        }

        return sr < sl;
    }
}
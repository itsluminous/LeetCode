public class Solution {
    public bool AreSentencesSimilar(string sentence1, string sentence2) {
        string[] shoort = sentence1.Split(), loong = sentence2.Split();
        if(shoort.Length > loong.Length)
            (shoort, loong) = (loong, shoort);
        
        int sl = 0, sr = shoort.Length-1;
        int ll = 0, lr = loong.Length-1;
        while(sl <= sr && shoort[sl] == loong[ll]){
            sl++; ll++;
        }
        while(sr >= 0 && shoort[sr] == loong[lr]){
            sr--; lr--;
        }

        return sr < sl;
    }
}
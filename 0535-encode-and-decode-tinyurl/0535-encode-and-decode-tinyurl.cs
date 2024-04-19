public class Codec {
    Dictionary<string,string> index = new Dictionary<string, string>();
    int LEN = 6;
    string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    // Encodes a URL to a shortened URL
    public string encode(string longUrl) {
        var key = "";
        do{
            key = generateNewKey();
        } while(index.ContainsKey(key));
        index[key] = longUrl;
        return key;
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {
        if(!index.ContainsKey(shortUrl)) return string.Empty;
        return index[shortUrl];
    }

    private string generateNewKey(){
        var sb = new StringBuilder();
        var random = new Random();
        for(var i=0; i<LEN; i++){
            var idx = random.Next(chars.Length);
            sb.Append(chars[idx]);
        }
        return sb.ToString();
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));
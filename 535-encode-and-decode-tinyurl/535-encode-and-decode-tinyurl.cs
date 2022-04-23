public class Codec {
    
    Dictionary<string,string> dict = new Dictionary<string,string>();

    // Encodes a URL to a shortened URL
    public string encode(string longUrl) {
        var bytes = Guid.NewGuid().ToByteArray();
        var base64String = Convert.ToBase64String(bytes);
        dict[base64String] = longUrl;
        Console.WriteLine(base64String);
        return base64String;
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {
        return dict[shortUrl];
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));
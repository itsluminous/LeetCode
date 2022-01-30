// Rolling hash - Rabin karp algorithm
public class Solution {
    public string SubStrHash(string s, int power, int modulo, int k, int hashValue) {
        int res = 0, n = s.Length;
        long curr = 0, lastPower = 1;
        
        // we do hasing from reverse, to avoid division operation later
        for(var i=n-1; i>=0; i--){
            var val = s[i]-'a' + 1;
            curr = (curr*power + val) % modulo; // add the current char in total hash value
            
            if(i+k >= n){   // no need of rolling out anything
                lastPower = (lastPower * power) % modulo;
            }
            else{           // remove last char's hash value
                var lastCharVal = s[i+k]-'a' + 1;
                curr = ((curr - lastCharVal * lastPower) % modulo + modulo) % modulo;
            }
            
            if(curr == hashValue) res = i;  // cannot return here because we have to return first match (from left side)
        }
        
        return s.Substring(res, k);
    }
}

// Does not work for bigger k - probably due to number limit
public class Solution1 {
    public string SubStrHash(string s, int power, int modulo, int k, int hashValue) {
        var n = s.Length;
        var cache = new long[s.Length];
        
        // fill up for single digits
        for(var i=0; i<n; i++){
            var val = s[i]-'a' + 1;
            var hash = val%modulo;
            if(k ==1 && hash == hashValue) return s[i].ToString();
            cache[i] = val;
        }
        
        // now two letter onwards
        for(var w=1; w<k; w++){
            for(var i=0; w+i<n; i++){
                var lastCharVal = s[i+w] -'a' + 1;
                var val = cache[i] + lastCharVal*Math.Pow(power,w);
                var hash = Convert.ToInt32(val%modulo);
                Console.WriteLine($"i={i}, w={w}, word={s.Substring(i, w+1)}, cache[{i}]={cache[i]}, last={lastCharVal}, pow={Math.Pow(power,w)}, val={val}, hash={val%modulo}");
                if(w+1 == k && hash == hashValue) return s.Substring(i, w+1);
                cache[i] = (long)val; 
            }
        }
        
        return string.Empty;
    }
}


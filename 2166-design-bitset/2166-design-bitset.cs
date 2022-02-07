public class Bitset {
    int size;
    HashSet<int> ones, zeroes;
    
    public Bitset(int siz) {
        size = siz;
        ones = new HashSet<int>();
        zeroes = new HashSet<int>();
        for(var i=0; i<size; i++) zeroes.Add(i);
    }
    
    public void Fix(int idx) {
        ones.Add(idx);
        zeroes.Remove(idx);
    }
    
    public void Unfix(int idx) {
        ones.Remove(idx);
        zeroes.Add(idx);
    }
    
    public void Flip() {
        var temp = ones;
        ones = zeroes;
        zeroes = temp;
    }
    
    public bool All() {
        return ones.Count == size;
    }
    
    public bool One() {
        return ones.Count > 0;
    }
    
    public int Count() {
        return ones.Count;
    }
    
    public string ToString() {
        var sb = new StringBuilder();
        for(var i=0; i<size; i++){
            if(ones.Contains(i)) sb.Append("1");
            else sb.Append("0");
        }
        return sb.ToString();
    }
}

/**
 * Your Bitset object will be instantiated and called as such:
 * Bitset obj = new Bitset(size);
 * obj.Fix(idx);
 * obj.Unfix(idx);
 * obj.Flip();
 * bool param_4 = obj.All();
 * bool param_5 = obj.One();
 * int param_6 = obj.Count();
 * string param_7 = obj.ToString();
 */
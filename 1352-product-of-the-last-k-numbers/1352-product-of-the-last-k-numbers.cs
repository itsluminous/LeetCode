public class ProductOfNumbers {
    List<int> products;

    public ProductOfNumbers() {
        products = new();
        products.Add(1);
    }
    
    public void Add(int num) {
        // if num == 0, restart valid products list
        if(num == 0){
            products = new();
            products.Add(1);
        }
        else{
            var prod = products[^1];
            products.Add(prod * num);
        }
    }
    
    public int GetProduct(int k) {
        var n = products.Count;
        if(k > n-1) return 0;   // it means at least one 0 exists within k elements
        return products[^1] / products[n-k-1];
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */
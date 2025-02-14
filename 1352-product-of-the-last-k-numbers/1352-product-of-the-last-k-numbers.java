class ProductOfNumbers {
    List<Integer> products;

    public ProductOfNumbers() {
        products = new ArrayList<>();
        products.add(1);
    }
    
    public void add(int num) {
        // if num == 0, restart valid products list
        if(num == 0){
            products = new ArrayList<>();
            products.add(1);
        }
        else{
            var prod = products.get(products.size() - 1);
            products.add(prod * num);
        }
    }
    
    public int getProduct(int k) {
        var n = products.size();
        if(k > n-1) return 0;   // it means at least one 0 exists within k elements
        return products.get(n-1) / products.get(n-k-1);
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.add(num);
 * int param_2 = obj.getProduct(k);
 */
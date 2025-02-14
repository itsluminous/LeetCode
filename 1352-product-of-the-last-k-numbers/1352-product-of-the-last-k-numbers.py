class ProductOfNumbers:

    def __init__(self):
        self.products = []
        self.products.append(1)

    def add(self, num: int) -> None:
        # if num == 0, restart valid products list
        if num == 0:
            self.products = []
            self.products.append(1)
        else:
            prod = self.products[-1]
            self.products.append(prod * num)

    def getProduct(self, k: int) -> int:
        n = len(self.products)
        if k > n-1: return 0   # it means at least one 0 exists within k elements
        return self.products[-1] // self.products[n-k-1]


# Your ProductOfNumbers object will be instantiated and called as such:
# obj = ProductOfNumbers()
# obj.add(num)
# param_2 = obj.getProduct(k)
class Solution:
    def findAllRecipes(self, recipes: List[str], ingredients: List[List[str]], supplies: List[str]) -> List[str]:
        self.ans = set()
        self.visited = set()
        self.supp = set(supplies)

        # map of recipe to ingredients
        self.recipeMap = {recipes[i] : ingredients[i] for i in range(len(recipes))}

        # check if we can make each dish
        for dish in recipes:
            self.canMake(dish)
        
        return list(self.ans)

    def canMake(self, dish: string) -> bool:
        if dish in self.supp: return True            # if this is basic supply
        if dish not in self.recipeMap: return False  # we don't know how to make it

        # if we already attempted making it, then check if we were able to make it
        if dish in self.visited:
            return dish in self.ans
        
        self.visited.add(dish)
        for ingrd in self.recipeMap[dish]:
            # if we cannot procure even a single ingredient, then we cannot make dish
            if not self.canMake(ingrd):
                return False

        # successfully prepared the dish
        self.ans.add(dish)
        return True
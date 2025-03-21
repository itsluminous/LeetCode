public class Solution {
    HashSet<string> ans, visited, supp;
    Dictionary<string, IList<string>> recipeMap;

    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies) {
        ans = new();
        visited = new();
        supp = new HashSet<string>(supplies);

        // map of recipe to ingredients
        recipeMap = new();
        for(var i=0; i<recipes.Length; i++)
            recipeMap[recipes[i]] = ingredients[i];
        
        // check if we can make each dish
        foreach(var dish in recipes)
            CanMake(dish);
        
        return ans.ToList();
    }

    private bool CanMake(string dish){
        if(supp.Contains(dish)) return true;            // if this is basic supply
        if(!recipeMap.ContainsKey(dish)) return false;  // we don't know how to make it

        // if we already attempted making it, then check if we were able to make it
        if(visited.Contains(dish))
            return ans.Contains(dish);
        
        visited.Add(dish);
        foreach(var ingrd in recipeMap[dish]){
            // if we cannot procure even a single ingredient, then we cannot make dish
            if(!CanMake(ingrd))
                return false;
        }

        // successfully prepared the dish
        ans.Add(dish);
        return true;
    }
}
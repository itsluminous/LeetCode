class Solution {
    HashSet<String> ans, visited, supp;
    HashMap<String, List<String>> recipeMap;

    public List<String> findAllRecipes(String[] recipes, List<List<String>> ingredients, String[] supplies) {
        ans = new HashSet<>();
        visited = new HashSet<>();
        supp = new HashSet<String>(Arrays.asList(supplies));

        // map of recipe to ingredients
        recipeMap = new HashMap<>();
        for(var i=0; i<recipes.length; i++)
            recipeMap.put(recipes[i], ingredients.get(i));
        
        // check if we can make each dish
        for(var dish : recipes)
            canMake(dish);
        
        return new ArrayList<>(ans);
    }

    private boolean canMake(String dish){
        if(supp.contains(dish)) return true;            // if this is basic supply
        if(!recipeMap.containsKey(dish)) return false;  // we don't know how to make it

        // if we already attempted making it, then check if we were able to make it
        if(visited.contains(dish))
            return ans.contains(dish);
        
        visited.add(dish);
        for(var ingrd : recipeMap.get(dish)){
            // if we cannot procure even a single ingredient, then we cannot make dish
            if(!canMake(ingrd))
                return false;
        }

        // successfully prepared the dish
        ans.add(dish);
        return true;
    }
}
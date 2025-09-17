class Food implements Comparable<Food> {
    String name;
    int rating;

    public Food(String n, int r){
        name = n;
        rating = r;
    }

    @Override
    public int compareTo(Food other){
        if(rating == other.rating) return name.compareTo(other.name);   // lexicographical sort
        return other.rating - rating;   // desc sort
    }
}

class FoodRatings {
    Map<String, Integer> foodRatingMap;
    Map<String, String> foodCuisineMap;
    Map<String, PriorityQueue<Food>> cuisineFoodMap;

    public FoodRatings(String[] foods, String[] cuisines, int[] ratings) {
        foodRatingMap = new HashMap<>();
        foodCuisineMap = new HashMap<>();
        cuisineFoodMap = new HashMap<>();

        for(var i=0; i<foods.length; i++){
            foodRatingMap.put(foods[i], ratings[i]);
            foodCuisineMap.put(foods[i], cuisines[i]);
            cuisineFoodMap.computeIfAbsent(cuisines[i], k -> new PriorityQueue<>()).add(new Food(foods[i], ratings[i]));
        }
    }
    
    public void changeRating(String food, int newRating) {
        foodRatingMap.put(food, newRating);
        var cuisine = foodCuisineMap.get(food);
        cuisineFoodMap.get(cuisine).add(new Food(food, newRating)); // we don't remove old rating from pq
    }
    
    public String highestRated(String cuisine) {
        var top = cuisineFoodMap.get(cuisine).peek();

        // remove older ratings from pq
        while(foodRatingMap.get(top.name) != top.rating) {
            cuisineFoodMap.get(cuisine).poll();
            top = cuisineFoodMap.get(cuisine).peek();
        }

        return top.name;
    }
}

/**
 * Your FoodRatings object will be instantiated and called as such:
 * FoodRatings obj = new FoodRatings(foods, cuisines, ratings);
 * obj.changeRating(food,newRating);
 * String param_2 = obj.highestRated(cuisine);
 */
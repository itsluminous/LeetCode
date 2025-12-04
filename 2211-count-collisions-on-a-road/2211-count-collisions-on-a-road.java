class Solution {
    public int countCollisions(String directions) {
        var ans = 0;
        var cars = new Stack<Character>();    // we need to track only stationary and right moving cars

        for(var dir : directions.toCharArray()){
            if(dir == 'R')
                cars.push('R');
            else if(dir == 'S' && cars.isEmpty())
                cars.push('S');
            else if(dir == 'S'){
                while(!cars.isEmpty() && cars.pop() == 'R')
                    ans++;
                cars.push('S');
            }
            else if(dir == 'L' && cars.isEmpty())
                continue;
            else {
                if(cars.peek() == 'S'){
                    ans++;
                    continue;
                }
                cars.pop();
                ans += 2;
                while(!cars.isEmpty() && cars.pop() == 'R')
                    ans++;
                cars.push('S');
            } 
        }

        return ans;
    }
}
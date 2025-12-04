public class Solution {
    public int CountCollisions(string directions) {
        var ans = 0;
        var cars = new Stack<char>();    // we need to track only stationary and right moving cars

        foreach(var dir in directions){
            if(dir == 'R')
                cars.Push('R');
            else if(dir == 'S' && cars.Count == 0)
                cars.Push('S');
            else if(dir == 'S'){
                while(cars.Count > 0 && cars.Pop() == 'R')
                    ans++;
                cars.Push('S');
            }
            else if(dir == 'L' && cars.Count == 0)
                continue;
            else {
                if(cars.Peek() == 'S'){
                    ans++;
                    continue;
                }
                cars.Pop();
                ans += 2;
                while(cars.Count > 0 && cars.Pop() == 'R')
                    ans++;
                cars.Push('S');
            } 
        }

        return ans;
    }
}
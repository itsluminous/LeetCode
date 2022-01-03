public class Solution {
    public bool AsteroidsDestroyed(int mass, int[] asteroids) {
        Array.Sort(asteroids);
        long lmass = mass;
        foreach(var ast in asteroids){
            if(ast > lmass) return false;
            lmass += ast;
        }
        return true;
    }
}
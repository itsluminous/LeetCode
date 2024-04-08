public class Solution {
    public int countStudents(int[] students, int[] sandwiches) {
        int n = students.length, circleStudentCount = 0, squareStudentCount = 0;
        // count how many students prefer each sandwich type
        for(var i=0; i<n; i++){
            if(students[i] == 0) circleStudentCount++;
            else squareStudentCount++;
        }

        // for every sandwich, if there is a student anywhere who can eat, then continue, else break
        var k = 0;
        for(; k < n; k++){
            if(sandwiches[k] == 0){
                if(circleStudentCount == 0) break;
                else circleStudentCount--;
            }
            else{
                if(squareStudentCount == 0) break;
                else squareStudentCount--;
            }
        }

        // k students could eat sandwiches
        // so those who could not eat is total minus k
        return n-k;
    }
}
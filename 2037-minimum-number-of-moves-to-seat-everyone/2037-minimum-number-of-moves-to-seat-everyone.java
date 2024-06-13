class Solution {
    public int minMovesToSeat(int[] seats, int[] students) {
        Arrays.sort(seats);
        Arrays.sort(students);

        var moves = 0;
        for(var i=0; i<seats.length; i++)
            moves += Math.abs(students[i] - seats[i]);
        
        return moves;
    }
}
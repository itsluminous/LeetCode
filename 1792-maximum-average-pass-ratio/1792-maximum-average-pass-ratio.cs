public class Solution {
    public double MaxAverageRatio(int[][] classes, int extraStudents) {
        // sort classes by gain desc, i.e. the class which sees max benefit on adding a student
        var maxHeap = new PriorityQueue<double[], double>();
        foreach(var classs in classes){
            int pass = classs[0], total = classs[1];
            var g = Gain((double)pass, (double)total);
            maxHeap.Enqueue(new double[]{g, pass, total}, -g);
        }

        // add extra students to classes where max gain is seen
        while(extraStudents-- > 0){
            var classs = maxHeap.Dequeue();
            double pass = classs[1] + 1, total = classs[2] + 1;  // +1 because we add extra student
            var g = Gain(pass, total);
            maxHeap.Enqueue(new double[]{g, pass, total}, -g);
        }

        // calculate final avg
        double allTotal = 0;
        while(maxHeap.Count > 0){
            var classs = maxHeap.Dequeue();
            double pass = classs[1], total = classs[2];
            allTotal += (pass / total);
        }

        return allTotal / classes.Length;
    }

    private double Gain(double pass, double total){
        return (pass+1) / (total+1)   -   pass / total;
    }
}
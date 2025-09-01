class Solution {
    public double maxAverageRatio(int[][] classes, int extraStudents) {
        // sort classes by gain desc, i.e. the class which sees max benefit on adding a student
        var maxHeap = new PriorityQueue<double[]>((a,b) -> Double.compare(b[0], a[0]));    // sort desc
        for(var classs : classes){
            int pass = classs[0], total = classs[1];
            var g = gain((double)pass, (double)total);
            maxHeap.offer(new double[]{g, pass, total});
        }

        // add extra students to classes where max gain is seen
        while(extraStudents-- > 0){
            var classs = maxHeap.poll();
            double pass = classs[1] + 1, total = classs[2] + 1;  // +1 because we add extra student
            maxHeap.offer(new double[]{gain(pass, total), pass, total});
        }

        // calculate final avg
        double allTotal = 0;
        while(!maxHeap.isEmpty()){
            var classs = maxHeap.poll();
            double pass = classs[1], total = classs[2];
            allTotal += (pass / total);
        }

        return allTotal / classes.length;
    }

    private double gain(double pass, double total){
        return (pass+1) / (total+1)   -   pass / total;
    }
}
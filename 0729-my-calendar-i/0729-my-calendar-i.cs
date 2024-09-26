class MyCalendar {
    List<Interval> cal;

    public MyCalendar() {
        cal = new List<Interval>();
    }
    
    public bool Book(int start, int end) {
        var interval = new Interval(start, end);
        var idx = cal.BinarySearch(interval, new IntervalComparer());
        if(idx >= 0) return false;

        // negative means no match found
        cal.Insert(~idx, interval);
        return true;
    }
}

class IntervalComparer : IComparer<Interval> {
    public int Compare(Interval int1, Interval int2){
        if(int1.end <= int2.start) return -1;
        if(int2.end <= int1.start) return 1;
        return 0;
    }
}

class Interval(int start, int end) {
    public int start { get; } = start;
    public int end { get; } = end;
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * boolean param_1 = obj.book(start,end);
 */
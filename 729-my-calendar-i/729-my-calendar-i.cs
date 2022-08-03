public class MyCalendar {
    List<Interval> cal;
    
    public MyCalendar() {
        cal = new List<Interval>();
    }
    
    public bool Book(int start, int end) {
        var interval = new Interval(start, end);
        var idx = cal.BinarySearch(interval, new IntervalComparer());
        if(idx < 0){            // negative means no match found
            cal.Insert(~idx, interval);
            return true;
        }
        return false;
    }
}

public class IntervalComparer : IComparer<Interval>
{
    public int Compare(Interval int1, Interval int2)
    {
        if(int1.end <= int2.start) return -1;
        if(int2.end <= int1.start) return 1;
        return 0;
    }
}

public class Interval {
    public int start;
    public int end;
    
    public Interval(int startval, int endval){
        this.start = startval;
        this.end = endval;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */
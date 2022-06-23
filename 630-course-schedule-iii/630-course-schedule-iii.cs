// copy paste
public class Solution {
    public int ScheduleCourse(int[][] courses) {
        
        if(courses == null || courses.Length == 0)
            return 0;
        
        Array.Sort(courses, (a,b) => a[1] - b[1]);
        SortedDictionary<int,List<int[]>> dic = new SortedDictionary<int,List<int[]>>();
        int totalDuration = 0, cnt = 0;
        for(int i = 0; i < courses.Length; i++)
        {
			// case1
            if(totalDuration + courses[i][0] <= courses[i][1])
            {
                totalDuration += courses[i][0];
                if(dic.ContainsKey(courses[i][0]))
                    dic[courses[i][0]].Add(courses[i]);
                else
                    dic.Add(courses[i][0],new List<int[]>(){courses[i]});
                cnt++;
            }
            else
            {
				// case2
                if(dic.ContainsKey(courses[i][0]))
                    dic[courses[i][0]].Add(courses[i]);
                else
                    dic.Add(courses[i][0],new List<int[]>(){courses[i]});              
                totalDuration += courses[i][0];
                
				// remove the course that takes the longest time
                var max = dic.Last().Value[dic.Last().Value.Count - 1];
                totalDuration -= max[0];
                dic.Last().Value.RemoveAt(dic.Last().Value.Count - 1);     
                if(dic.Last().Value.Count == 0)
                    dic.Remove(max[0]);
            }
        }
        
        return cnt;
    }
}
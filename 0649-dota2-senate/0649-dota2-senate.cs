public class Solution {
    public string PredictPartyVictory(string senate) {
        int countR = 0, countD = 0, banR = 0, banD = 0;
        
        var queue = new Queue<char>();
        foreach(var ch in senate){
            queue.Enqueue(ch);
            if(ch == 'R') countR++;
            else countD++;
        }

        while(queue.Count > 0){
            var curr = queue.Dequeue();
            if(curr == 'R' && banR > 0){
                banR--;
                countR--;
            }
            else if(curr == 'R'){
                banD++;
                queue.Enqueue('R');
            }
            else if(curr == 'D' && banD > 0){
                banD--;
                countD--;
            }
            else{   // 'D'
                banR++;
                queue.Enqueue('D');
            }

            if(countD == 0) return "Radiant";
            if(countR == 0) return "Dire";
        }

        return string.Empty;
    }
}
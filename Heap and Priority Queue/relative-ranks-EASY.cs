public class Solution {
    public string[] FindRelativeRanks(int[] score) {
      var q = new System.Collections.Generic.PriorityQueue<int, int>(new IntComparison());
      for(int i=0; i<score.Length; i++){
          q.Enqueue(i, score[i]);
      }
      string[] res = new string[score.Length];
      int ind=0;
      while(q.Count>0){
          int temp = q.Dequeue();
          if(ind==0){
              res[temp] = "Gold Medal";
          }else if(ind==1){
              res[temp] = "Silver Medal";
          }else if(ind==2){
              res[temp] = "Bronze Medal";
          }else
            res[temp] = (ind+1).ToString();
        ind++;
      }
      return res;
    }
}
public class IntComparison: IComparer<int>{
    public int Compare(int x, int y){
        return y-x;
    }
}
/*
Sort the array highest to lowest using Priority queue
    Create new array based on position, it should have position and index.
    Use this new array to generate new array
*/
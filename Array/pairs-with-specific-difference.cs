using System;
using System.Collections.Generic;
class Solution
{
    //input:  arr = [0, -1, -2, 2, 1], k = 1
    public static int[,] FindPairsWithGivenDifference(int[] arr, int k)
    {
      //Declare variables
      var resList = new List<List<int>>();
      //Store all nums in hashset, treat them as x
      var hashSet = new HashSet<int>();
      for(int i=0; i<arr.Length; i++){
        hashSet.Add(arr[i]);
      }

      //Loop each num in array - treat them as y
      for(int i=0; i<arr.Length; i++){
        int y = arr[i];
        //Find x 
        int x = k + y; 
        //Check if hashset contains x value
        if(x!=y && hashSet.Contains(x)){
          var pair = new List<int>();
          pair.Add(x);
          pair.Add(y);
          resList.Add(pair);
        }
      }

      if(resList.Count==0)
        return new int[0,0];

      //Convert result list into int[,] array
      int[,] res = new int[resList.Count, 2];
      for(int i=0; i<resList.Count; i++){
        res[i, 0] = resList[i][0];
        res[i, 1] = resList[i][1];
      }
      return res;
    }

    static void Main(string[] args)
    {

    }
}
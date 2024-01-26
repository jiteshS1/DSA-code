public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
     int[,] arr = new int[text1.Length+1, text2.Length+1];

     for(int i=text1.Length-1; i>=0; i--)
     {
         for(int j=text2.Length-1; j>=0; j--){
            if(text1[i]==text2[j]){
                arr[i,j] = 1 + arr[i+1,j+1];  
            }else
            {
                arr[i,j] = System.Math.Max(arr[i,j+1], arr[i+1,j]);
            }
         }
     }
     return arr[0,0];   
    }
}
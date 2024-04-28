public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int max = -1;
        for(int i=0; i<heights.Length; i++){
            int l = i-1, r = i+1;
            bool lFlag = true, rFlag = true;
            int curMax = heights[i];
            while(lFlag || rFlag){
                if(l<0 || heights[l] < heights[i]){
                    lFlag = false;
                }else{
                    curMax += heights[i]; 
                    l--;
                }

                if(r>=heights.Length || heights[r] < heights[i]){
                    rFlag = false;
                }else{
                    curMax += heights[i]; 
                    r++;
                }
            }
            max = System.Math.Max(max, curMax);
        }
        return max;
    }
}
/*
Above solution getting time limit exceed message TC: O(n^2), SC: O(1)
-------------------Better solution TC, SC: O(n)--------------------
public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int max = -1;
        Stack<int[]> st = new Stack<int[]>(); 
        for(int i=0; i<heights.Length; i++){
            int startIndex = i;
            while(st.Count() > 0 && 
                heights[i] < st.Peek()[1]){
                var val = st.Pop();
                startIndex = val[0];
                max = System.Math.Max(max, (val[1] * (i - startIndex)));
            }
            st.Push(new int[2]{startIndex, heights[i]});
        }
        while(st.Count()>0){
            var val = st.Pop();
            int startIndex = val[0];
            max = System.Math.Max(max, (val[1] * (heights.Length - startIndex)));
        }
        return max;
    }
}
*/
public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        System.Collections.Generic.PriorityQueue<int[], int> q = new(new IntComparer());
        for(int r=0; r < points.Length; r++){
            q.Enqueue(points[r], (points[r][0] * points[r][0]) + (points[r][1] * points[r][1]));
            if(q.Count > k){
                q.Dequeue();
            }
        }
        int[][] res = new int[k][];
        int i=0;
        while(i<k){
            res[i++] = q.Dequeue();
        }
        return res;
    }
    private class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }

}
/*
Loop points array
    Get distance from origin using formula
        Add returned answer in PQ

    Fetch k values from answer array
        Add it in result    
*/
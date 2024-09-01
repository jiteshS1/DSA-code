public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var prevRow = new List<int>();
        
        for(int i=0; i<=rowIndex; i++){
            var row = new List<int>(new int[i+1]);
            for(int j=0; j<=i; j++){
                if(j==0 || j==i)
                    row[j]=1;
                else{
                    if(j-1>=0 && j<prevRow.Count())
                        row[j] = prevRow[j-1] + prevRow[j];
                }
            }
            prevRow = row;
        }
        return prevRow;
    }
}
/*
    TC: O(rowIndex ^ 2), SC: O(rowIndex)
*/
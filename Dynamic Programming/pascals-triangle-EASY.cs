public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var res = new List<IList<int>>();
        var prevRow = new List<int>();

        for(int i=1; i<=numRows; i++){
            var row = new List<int>(new int[i]); 
            for(int j=0; j<i; j++){
                if(j==0 || j==i-1){
                    row[j] = 1;
                }else{
                    if(j-1>=0 && j < prevRow.Count())
                        row[j] = prevRow[j-1] + prevRow[j];
                }
            }
            res.Add(row);
            prevRow = row;
        }

        return res;
    }
}
/*
    TC, SC: O(numRows^2)
*/
public class Solution {
    public int MaxDistance(IList<IList<int>> arrays) {
        //Initialize variables
        int diff = Int32.MinValue; 

        //Update min & max from first array
        int min = arrays[0][0]; 
        int max = arrays[0][arrays[0].Count - 1]; 

        for(int i = 1; i < arrays.Count; i++){
            int curMin = arrays[i][0],
                curMax = arrays[i][arrays[i].Count - 1];

            //Update absolute difference
            diff = Math.Max(Math.Abs(max - curMin), diff);
            diff = Math.Max(Math.Abs(curMax - min), diff);

            //Update min & max values
            min = Math.Min(min, curMin);
            max = Math.Max(max, curMax);
        }
        return diff;
    }
}
/*
TC: O(n), SC:(1)
- Max distance
- Find min. & max number, make sure that these two nums are not from same array

- Initialize min as int min value & max as int max value
- Difference as 0
- From first array initialize update min & max
- Loop arrays in list
    - Calculate abolute difference between min & currentMax, & max & currentMin
    - Update max difference
    - Update min & max value

Dry Run:
(5,6)(7,8)(1,2)(1,3)
res = 7
min = 1
max = 8
*/
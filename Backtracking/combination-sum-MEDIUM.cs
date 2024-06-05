public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var res = new List<IList<int>>();
        RecFunction(candidates, new List<int>(), 0, target, res);
        return res;
    }
    
    private void RecFunction(int[] candidates, List<int> temp, int sum, int target, List<IList<int>> res) {
        if (sum == target) {
            res.Add(new List<int>(temp));
            return;
        }
        if (sum > target) {
            return;
        }
        for (int i = 0; i < candidates.Length; i++) {
            if (temp.Count > 0 && candidates[i] < temp[temp.Count - 1]) {
                continue; // Skip to ensure combinations are non-decreasing
                //For each recursive call, the for-loop starts from i = 0, 
                //but only elements that are greater than or equal to the last added element 
                //(to avoid duplicate combinations in different orders).
            }
            temp.Add(candidates[i]);
            RecFunction(candidates, temp, sum + candidates[i], target, res);
            temp.RemoveAt(temp.Count - 1); // Correctly remove the last element
        }
    }
}
/*

### Time Complexity

The time complexity of this algorithm is determined by the number of possible combinations and the cost of generating each combination. Here's a detailed analysis:

1. **Number of Combinations**:
   - The total number of combinations is dependent on the target value and the candidates. In the worst case, where all candidates are small compared to the target, the number of combinations can grow exponentially.
   - If \( n \) is the number of candidates and the target is \( T \), the complexity is \( O(2^T) \) in the worst case because each number can either be included or excluded, and the target can be formed in multiple ways using different combinations of candidates.

2. **Generating Combinations**:
   - Generating each combination involves iterating through the candidates and making recursive calls. The cost of adding and removing elements from `temp` is \( O(1) \).
   - Each valid combination (which sums up to the target) is added to the result list, which takes \( O(k) \) where \( k \) is the average length of the combinations.

Combining these factors, the overall time complexity is:
\[ O(2^T * k) \]
Where \( k \) is typically less than or equal to \( T \).

### Space Complexity

The space complexity includes:

1. **Result Storage**:
   - The result list `res` stores all valid combinations. In the worst case, there can be \( O(2^T) \) combinations, and each combination can have up to \( T \) elements.
   - Therefore, the space required for storing the results is \( O(T * 2^T) \).

2. **Recursive Call Stack**:
   - The maximum depth of the recursive call stack is equal to the target divided by the smallest candidate (in the worst case). However, for simplicity, it can be considered \( O(T) \).

3. **Temporary List `temp`**:
   - The temporary list `temp` also requires space proportional to the depth of the recursion, which is \( O(T) \).

Combining these factors, the overall space complexity is:
\[ O(T * 2^T) \]

### Summary

- **Time Complexity**: \( O(2^T * k) \) where \( T \) is the target value and \( k \) is the average length of the combinations.
- **Space Complexity**: \( O(T * 2^T) \)

These complexities indicate that the solution is exponential in terms of both time and space, which is expected for problems involving combination generation with constraints.

-----------------Better Solution--------------------------
public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var res = new List<IList<int>>();
        DFS(0, res, new List<int>(), 0, candidates, target);
        return res;
    }
    public void DFS(int i, List<IList<int>> res, List<int> temp, int sum, int[] candidates, int target){
        if(sum ==  target)
        {
            res.Add(new List<int>(temp));
            return;
        }
        if(i >= candidates.Length || sum > target){
            return;
        }
        temp.Add(candidates[i]);
        DFS(i, res, temp, sum+candidates[i], candidates, target);
        temp.Remove(candidates[i]);

        DFS(i+1, res, temp, sum, candidates, target);
    }
}
TC, SC: O(2^T)
*/

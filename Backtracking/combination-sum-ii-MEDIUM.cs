using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        // Sort candidates array
        Array.Sort(candidates); // O(n * log n)
        var res = new List<IList<int>>();
        DFS(0, 0, new List<int>(), res, candidates, target);
        return res;
    }

    private void DFS(int index, int sum, List<int> currentCombination, List<IList<int>> result, 
                     int[] candidates, int target) {
        if (sum == target) {
            result.Add(new List<int>(currentCombination));
            return;
        }
        
        if (sum > target || index >= candidates.Length)
            return;

        for (int i = index; i < candidates.Length; i++) {
            // Skip duplicates
            if (i > index && candidates[i] == candidates[i - 1])
                continue;
            
            currentCombination.Add(candidates[i]);
            DFS(i + 1, sum + candidates[i], currentCombination, result, candidates, target);
            currentCombination.RemoveAt(currentCombination.Count - 1); // Remove last value in list
        }
    }
}
/*
    TC: O(2^n)
    SC: O(n . 2^n)
*/
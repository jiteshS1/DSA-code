public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var hs = new System.Collections.Generic.HashSet<int>();
        for(int i=0; i<nums.Length; i++){
            if(hs.Contains(nums[i]))
                return true;
            else
                hs.Add(nums[i]);
        }
        return false;
    }
}
/*
----By sorting array
TC: O(n * log n)
SC: O(1)
public bool ContainsDuplicate(int[] nums) {
    Array.Sort(nums);
    for (int i = 1; i < nums.Length; i++) {
        if (nums[i] == nums[i - 1])
            return true;
    }
    return false;
}

------------Better code:
HashSet<int> set = new HashSet<int>(nums);
        
        return nums.Length != set.Count;
*/
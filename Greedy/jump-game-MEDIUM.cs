public class Solution {
    public bool CanJump(int[] nums) {
        int maxIndex = 0;
        for(int i=0; i<nums.Length && i <= maxIndex; i++){
            if(maxIndex < nums[i] + i)
                maxIndex = nums[i] + i;
            if(maxIndex >= nums.Length-1)
                return true;
        }
        return false;
    }
}
/*
TC: O(n), SC: O(1)
[2,3,1,1,4]

maxReachIndex=0
Loop through each num in nums & i <= maxReachIndex
    if maxReachIndex < num + i
        maxReachIndex = num + i
    if maxReachIndex is >= length-1
        return true

return false
*/
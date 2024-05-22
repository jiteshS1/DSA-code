public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var res = new int[nums.Length];

        res[0] = 1;
        for(int i=1; i<nums.Length; i++){
            res[i] = res[i-1] * nums[i-1]; 
        }

        int prev = 1;
        for(int i=nums.Length-2; i>=0; i--){
            int temp = res[i];
            res[i] = prev * nums[i+1];
            prev = res[i]; 
            res[i] *= temp;
        }

        return res;
    }
}
/*
TC: O(n)
SC: O(1) Questions says: The output array does not count as extra space for space complexity analysis
*/
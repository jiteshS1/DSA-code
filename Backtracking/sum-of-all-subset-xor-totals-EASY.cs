public class Solution {
    public int SubsetXORSum(int[] nums) {
        return GetXOR(0, 0, nums);
    }
    int GetXOR(int i, int xor, int[] nums){
        if(i >= nums.Length)
        {
            return xor;
        }

        //Include current val in subset
        int leftXOR = GetXOR(i+1, xor ^ nums[i], nums);

        //Don't include current val in subset
        int rightXOR = GetXOR(i+1, xor, nums);

        return leftXOR + rightXOR;
    }
}
/*
#Brute force approach
- Get all subsets
- Loop each subset
    - Convert value to bit
    - XOR it
- add XOR bit to int result in solution

#Optimal solution:
- Use bitwise operator in subset method directly
*/
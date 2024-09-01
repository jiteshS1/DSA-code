public class Solution {
    public int SingleNumber(int[] nums) {
        int res = 0;
        foreach(var num in nums){
            res = res ^ num; //XOR
        }
        return res;
    }
}
/*
TC: O(n) SC: O(1)
In XOR if bits are same it will return 0, else 1 
*/
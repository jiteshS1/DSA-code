public class Solution {
    public int ClimbStairs(int n) {
        int one=1, two=1, temp;
        for(int i=n-2; i>=0; i--)
        {
            temp = one;
            one = one + two;
            two = temp;
        }
        return one;
    }
}
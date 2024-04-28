public class Solution {
    public int HammingWeight(int n) {
        int res=0;
        while(n>0){
            if(n%2 == 1) 
                res++;            
            
            n /= 2;
        }
        return res;
    }
}
/*
TC: O(log(n)), SC: O(1)
--------------Better approach----------------------
public int hammingWeight(int n)
{
    int res = 0;
    while (n != 0)
    {
        n &= (n - 1); // It will remove last set bit always
        res++;
    }
    return res;
}


1st approach:
Use internal method Convert.ToString(n, 2) it will give binary string
    then count number of set bit

2nd approach:
Don't use internal method


*/
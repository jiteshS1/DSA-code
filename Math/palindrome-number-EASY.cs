public class Solution {
    public bool IsPalindrome(int x) {
        if(x == 0)  
            return true;
        if(x < 0)
            return false;
        int multiplier = 1, num = x, res = 0;

        while(num != 0){
            int rem = num % 10;
            num /= 10;
            if(multiplier == 1){
                if(rem == 0)
                    return false;
                res = rem;
                multiplier = 10;
            }else{                
                res = res * multiplier;
                res = res + rem;
            }
        }

        if(res == x)
            return true;
        else
            return false;
    }
}
/*
num = 152
2 * 1 = 2 , num = 15
2 * 10 = 20+5 = 25, num = 1
25 * 10 = 250+1 = 251  

- Initialize multiplier as 1
- Loop till x != 0 
- Get remainder num % 10
    - num = num / 10
- If multiplier is 1
    - res = rem
else 
    - multiple as 10
    - res = res * multiplier
    - res = res + rem
*/
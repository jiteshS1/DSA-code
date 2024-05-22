public class Solution {
    public int Reverse(int x) {
        int res = 0;
        while(x!=0){
            int rem = x % 10;
            x -= rem;
            x /= 10;
            
            // Check for overflow before updating the result
            //Coorect condition:
            if (res > int.MaxValue / 10 || (res == int.MaxValue / 10 && rem > 7)) return 0; //to 2,147,483,647 % 10 = 7 
            if (res < int.MinValue / 10 || (res == int.MinValue / 10 && rem < -8)) return 0; //-2,147,483,648 

            // if(res > (Math.Pow(2, 31)-1)/10) return 0;
            // if(res < Math.Pow(-2, 31)/10) return 0;
            // if (res > int.MaxValue / 10) return 0;
            // if (res < int.MinValue / 10) return 0;

            res = (res * 10) +  rem;
        }
        int final = 0;
        return res;
    }
}
/*
-123
rem - 3, -2, -1
x -12, -1, 0
res -3, -32,  

123
rem 3, 2, 1 
x 12, 1, 0
res: 3, 2, 1
res : 32

120
rem 0 
x 12
res 0 2 1

*/
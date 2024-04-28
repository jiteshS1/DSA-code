public class Solution {
    public int BalancedStringSplit(string s) {
        int res=0, flag=0;
        foreach(char ch in s){
            if(ch == 'L'){
                flag++;
            }else if(ch == 'R'){
                flag--;
            }
            if(flag==0)
                res++;
        }
        return res;
    }
}
/*
TC: O(n), SC: O(1)

flag = 0
result = 0
Loop each char in s
    if char is l
        flag++
    if char is r
        flag--
    if flag == 0
        result++

*/
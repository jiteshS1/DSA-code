public class Solution {
    public int LongestValidParentheses(string s) {
        int res = 0, cRes = 0;

        var st = new Stack<int>();
        for(int i=0; i<s.Length; i++){
            char ch = s[i];
            if(ch == '('){
                //If char is opening bracket, add in stack
                st.Push(cRes);
                cRes = 0;
            }else if(ch == ')') {
                //If char is closing bracket
                //Check if i have an opening bracket in stack
                if(st.Count()>0){
                    int prevCount = st.Pop();
                    cRes = cRes + 2 + prevCount;
                    res = System.Math.Max(res, cRes);
                }else{
                    //Stack is empty
                    //That means it is in valid parenthesis
                    //Reset cRes
                    cRes = 0;
                }
            }
        }
        return res;
    }
}
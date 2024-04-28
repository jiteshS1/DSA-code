public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> st = new Stack<int>();
        foreach(string str in tokens){
            if(str=="+" || str=="-" || str=="*" || str=="/"){
                if(st.Count() >= 2){
                    int num2 = st.Pop();
                    int num1 = st.Pop();
                    st.Push(Eval(num1, num2, str));
                }
            }else{
                int num = Convert.ToInt32(str);
                st.Push(num);
            }
        }
        return st.Pop();
    }
    public int Eval(int num1, int num2, string op){
        if(op == "+")
            return num1 + num2;
        else if(op == "-")
            return num1 - num2;
        else if(op == "*")
            return num1 * num2;
        else 
            return num1 / num2;
    }
}
/*
TC, SC: O(n)
*/
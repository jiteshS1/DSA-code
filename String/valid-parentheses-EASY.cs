public class Solution {
    public bool IsValid(string s) {
        int[] arr = new int[10000];
        int top=-1;
        char[] chars = s.ToCharArray();
        for(int i=0; i<chars.Length; i++)
        {
            if(chars[i]=='(' || chars[i]=='{' || chars[i]=='[')
            {
                arr[++top] = chars[i];
            }else if(top<0){
                return false;
            }else if((arr[top]=='(' && chars[i]==')')
                    || (arr[top]=='{' && chars[i]=='}')
                    || (arr[top]=='[' && chars[i]==']')){
                    top--;
                }else
                    return false;
        }
        if(top==-1)
            return true;
        else
            return false;
    }
}
/*
    var chars
    stack of array will have opening brackets   
        Insert from end
        Top will point to end
    Pop if same type opening bracket is available in index. Unitil top<0
        otherwise return false;
    
*/
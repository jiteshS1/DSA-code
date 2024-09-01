public class Solution {
    public string ConvertToTitle(int columnNumber) {
        //Declare variables
        var sb = new StringBuilder();
        int numerator = columnNumber;

        //Do a while loop till numerator value becomes less then 26
        while(numerator > 26){
            //Calculate remainder
            int rem = numerator % 26;

            if(rem > 0){
                //Convert number to char
                rem = rem - 1;
                char ch = Convert.ToChar('A' + rem);
                //Add char in res string 
                sb.Append(ch);
            }else{
                //If remainder is 0 add last char Z
                sb.Append('Z');
                numerator = numerator - 1;
            }

            //Divide numerator by 26
            numerator = numerator / 26;
        }

        //Convert numberator to char
        numerator = numerator - 1;
        char startChar = Convert.ToChar('A' + numerator);
        //Add char in res string 
        sb.Append(startChar);

        string res = sb.ToString();

        //Reverse string
        char[] charArray = res.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
/*
TC, SC: O(log 26 n)
1-26 (A-Z)
27-52 (A(A-Z))
53-78 (B(A-Z))

eg: 28 > 28-26 = 2

28/26 = 1
28%26 = 2

701/26 = 2 
*/
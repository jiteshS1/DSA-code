public class Solution {
    public string AddBinary(string a, string b) {
        int aLen = a.Length-1, bLen = b.Length-1, sum=0;
        byte carry=0;
        var res = new List<int>();
        var sb = new System.Text.StringBuilder();
        while(aLen >=0 || bLen >=0)
        {
            sum=carry;
            if(aLen >= 0)
                sum += (int) (a[aLen--]-'0');
            if(bLen >= 0)
                sum += (int) (b[bLen--]-'0');
            
            if(sum>1)
                carry = 1;
            else
                carry = 0;

            res.Add(sum%2);
        }
        if(carry>0)
            res.Add(1);
        
        int len = res.Count-1;
        while(len>=0){
             sb.Append(res[len--]); 
        }
        return sb.ToString();
    }
}
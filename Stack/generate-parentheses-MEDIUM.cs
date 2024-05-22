 public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        IList<string> res = new List<string>();
        BackTracking(n, n, new StringBuilder(), ref res);
        return res;
    }
    public void BackTracking(int open, int close, StringBuilder str, ref IList<string> res)
    {
        if (open == 0  && close == 0)
        {
            res.Add(str.ToString());
            return;
        }
        if (close > open)
        {
            str.Append(")");
            BackTracking(open, close-1, str, ref res);
            str.Remove(str.Length - 1, 1);//Remove last bracket
        }
        if (open > 0)
        {
            str.Append("(");
            BackTracking(open - 1, close, str, ref res);
            str.Remove(str.Length - 1, 1);//Remove last bracket
        }
    }
}
/*
TC: O(4^n), SC: O(n)
*/
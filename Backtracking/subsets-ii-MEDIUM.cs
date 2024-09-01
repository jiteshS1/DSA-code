public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        var res = new List<IList<int>>();
        var set = new HashSet<string>();
        var sb = new StringBuilder();
        var temp = new List<int>();
        BackTracking(res, set, sb, temp, nums, 0);
        return res;
    }
    public void BackTracking(List<IList<int>> res, HashSet<string> set,
        StringBuilder sb, List<int> temp, int[] nums, int i)
    {
        if(i >= nums.Length){
            if(!set.Contains(sb.ToString())){
                set.Add(sb.ToString());
                res.Add(new List<int>(temp));
            }
            return;
        }
        string str = GetString(nums[i]);
        sb.Append(str);
        temp.Add(nums[i]);
        BackTracking(res, set, sb, temp, nums, i+1);

        if(str.Contains("-")){
            sb.Remove(sb.Length-2, 2);//Remove last 2 char
        }else
            sb.Remove(sb.Length-1, 1);//Remove last char

        temp.RemoveAt(temp.Count()-1);
        BackTracking(res, set, sb, temp, nums, i+1);
    }
    public string GetString(int i){
        if(i==10)
            return "x";
        else if(i==-10)
            return "-x";
        else
            return ""+i;
    }
}
/*
    TC, SC: O(n * 2^n)
*/
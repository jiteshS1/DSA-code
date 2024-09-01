public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var st = new Stack<int[]>();
        var res = new int[temperatures.Length];

        st.Push(new int[2]{ temperatures[0], 0 });
        
        for(int i=1; i<temperatures.Length; i++){
            //Pop from stack till stack is empty or st.Peek temp is more
            while(st.Count()>0 && st.Peek()[0] < temperatures[i]){
                var tempDet = st.Pop();
                int index = tempDet[1];
                res[index] = i-index; //Difference will be the days gap
            }
            st.Push(new int[2]{ temperatures[i], i });
        }
        while(st.Count()>0){
            var tempDet = st.Pop();
            int index = tempDet[1];
            res[index] = 0;
        }
        return res;
    }
}
/*
TC, SC: O(n)
*/
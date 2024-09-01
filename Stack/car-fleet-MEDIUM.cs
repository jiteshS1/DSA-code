public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var indexedArray = position.Select((value, index) => new IndexedValue {Value = value, Index = index}).ToArray();

        var sortedPostn = indexedArray.OrderBy(x=> x.Value).ToArray();

        var st = new Stack<int[]>();
        st.Push(new int[2]{sortedPostn[0].Value, sortedPostn[0].Index});

        for(int i=1; i<sortedPostn.Length; i++){
            while(st.Count()>0){
                //Calculate time to reach target
                var prevPostn = st.Peek();
                float prevTime = (float) (target - prevPostn[0])/speed[prevPostn[1]];

                float curTime =  (float) (target - sortedPostn[i].Value)/speed[sortedPostn[i].Index];
                
                if(prevTime>curTime){
                    break;
                }else{
                    //Pop from stack
                    st.Pop();
                }
            }
            //Add in stack
            st.Push(new int[2]{sortedPostn[i].Value, sortedPostn[i].Index});
        }
        int res = 0;
        while(st.Count()>0){
            st.Pop();
            res++;
        }
        return res;
    }
}
public class IndexedValue
{
    public int Value { get; set; }
    public int Index { get; set; }
}
/*
    TC: O(n logn), SC: O(n)
*/
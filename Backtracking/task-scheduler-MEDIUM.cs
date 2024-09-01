public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] charsCount = new int[26];
        foreach(char ch in tasks){
            charsCount[ch - 'A'] += 1;
        }
        
        var pq = new PriorityQueue<char, int>(new IntegerComparer());
        int interval = 0;
        
        for(int i=0; i<26; i++){
            //Push chars with count in PQ
            if(charsCount[i]>0)
                pq.Enqueue(Convert.ToChar('A'+i), charsCount[i]);
        }
        int ind = 0;
        var queue = new Queue<CharIntPair>();
        while(pq.Count > 0 || queue.Count()>0){
            //Check if I can add back to PQ from queue
            if(queue.Count() > 0){
                var pair = queue.Peek();
                if(pair.nextIndex <= ind){
                    pq.Enqueue(pair.ch, pair.count);
                    queue.Dequeue();
                }
            }
            if(pq.Count > 0)
            {
                int count;
                char ch;
                //Use current char from PQ
                pq.TryPeek(out ch, out count);
                if(count-1 > 0)
                {
                    queue.Enqueue(new CharIntPair(count-1, ind+n+1, ch));
                }
                pq.Dequeue();
            }
            interval++;
            ind++;
        }

        return interval;
    }
}
class CharIntPair{
    public int count;
    public int nextIndex;
    public char ch;
    public CharIntPair(int count, int nextIndex, char ch){
        this.count = count;
        this.nextIndex = nextIndex;
        this.ch = ch;
    }
}
class IntegerComparer: IComparer<int>{
    public int Compare(int x, int y){
        return y.CompareTo(x);
    }
}
/*
    TC: O(T +D), SC: O(T)
*/
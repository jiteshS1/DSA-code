public class Solution {
    public string ReorganizeString(string s) {
        //Edge case
        if(s.Length == 1)
            return s;
        
        //Declaring variabes
        int[] charCount = new int[26];
        var pq = new PriorityQueue<char, int>(new IntegerComparer());

        //Count char in string
        for(int i = 0; i < s.Length; i++){
            charCount[s[i] - 'a']++;
        }

        //Enqueue values in PQ
        for(int i = 0; i < 26; i++){
            if(charCount[i] > 0){
                pq.Enqueue(Convert.ToChar('a'+i), charCount[i]);
            }
        }

        ElementDetails prev = null;
        var sb = new StringBuilder();

        //Loop PQ till it is empty
        while(pq.Count > 0){
            int count = 0;
            char ch = '\0';
            pq.TryPeek(out ch, out count);
            pq.Dequeue();
            count--;

            sb.Append(ch);

            if(prev != null && prev.count > 0){
                //Enqueue again in PQ
                pq.Enqueue(prev.ch, prev.count);
                prev = null;
            }
            prev = new ElementDetails(ch, count);
        }
        string res = "";
        if(sb.ToString().Length == s.Length)
            res = sb.ToString();

        return res;
    }
    class IntegerComparer: IComparer<int>{
        public int Compare(int x, int y){
            return y.CompareTo(x);
        }
    }
    class ElementDetails{
        public char ch;
        public int count;
        public ElementDetails(char ch, int count){
            this.ch = ch;
            this.count = count;
        }
    }
}
/*
TC, SC: O(n)
Store char count in an aray
From char array create PQ that returns max element first
Loop till PQ is not empty
- Dequeue from PQ
- Add char in result
- Reduce count
- If prev not null & count is > 0 then add that element in PQ
- Store current element in prev
- 

*/
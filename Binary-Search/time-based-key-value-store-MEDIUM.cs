public class TimeMap {
    System.Collections.Generic.Dictionary<string, List<TimeDetail>> dict;
    public TimeMap() {
        dict  = new System.Collections.Generic.Dictionary<string, List<TimeDetail>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if(dict.ContainsKey(key)){
            var list = dict[key];
            var obj = new TimeDetail(value, timestamp);
            list.Add(obj);
        }else{
            var list = new List<TimeDetail>();
            var obj = new TimeDetail(value, timestamp);
            list.Add(obj);
            dict.Add(key, list);
        }
    }
    
    public string Get(string key, int timestamp) {
        if(dict.ContainsKey(key)){
            var list = dict[key];
            int l=0, r= list.Count()-1, m=0;
            if(r>=0)
            {
                while(l<=r){
                    m= l+((r-l)/2);///(l+r)/2;
                    if(timestamp>list[m].timeStamp){
                        l=m+1;
                    }else if(timestamp<list[m].timeStamp){
                        r=m-1;
                    }else 
                        return list[m].value;
                }
                if(l-1<list.Count() && l-1>=0)
                     return list[l-1].value;
                else
                     return "";
            }else
                return "";
        }else
            return "";
    }
}
public class TimeDetail{
    public string value;
    public int timeStamp;
    public TimeDetail(string value, int timestamp){
        this.value = value;
        this.timeStamp = timestamp;
    }

}
/*
Dictionary for storing keys and pointer to an array location having value for particular stamp, timestamps for that particular 
O(1) for searching dictionary
Timestamp are in increasing order
O(log(n)) for searching in array

I can crete Dictionary object as
Dictionary<string, IList<(int time, string value)>> _map = new();

public class TimeMap {
private readonly Dictionary<string, IList<(int time, string value)>> _map = new();
    
    public void Set(string key, string value, int timestamp) {
       if (!_map.ContainsKey(key))
      {
    _map[key] = new List<(int, string)>();
       }

      _map[key].Add((timestamp, value)); 
    }
    
    public string Get(string key, int timestamp) {
      string result = string.Empty;
        if (!_map.ContainsKey(key))
        {
          return result;
        }

     var list = _map[key];

    var left = 0;
var right = list.Count - 1;

while (left <= right)
{
    var mid = (right + left) / 2;
    if (list[mid].time == timestamp)
    {
        return list[mid].value;
    }

    if (list[mid].time <= timestamp)
    {
        left = mid + 1;
    }
    else
    {
        right = mid - 1;
    }
}

return left == 0 ? string.Empty : list[left - 1].value;   
    }
}

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */

*/

/**
 * Your TimeMap object will be instantiated and called as such:
 * TimeMap obj = new TimeMap();
 * obj.Set(key,value,timestamp);
 * string param_2 = obj.Get(key,timestamp);
 */
public class RandomizedSet {
    System.Collections.Generic.Dictionary<int,int> dict;
    System.Collections.Generic.List<int> listValue;  
    public RandomizedSet() {
        dict = new System.Collections.Generic.Dictionary<int,int>();
        listValue = new System.Collections.Generic.List<int>();
    }
    
    public bool Insert(int val) {
        if(dict.ContainsKey(val))
            return false;
        else
        {
            dict.Add(val, listValue.Count);
            listValue.Add(val);
            return true;
        }
    }
    
    public bool Remove(int val) {
        if(dict.ContainsKey(val))
        {
            dict[val];
            dict.Remove(val)
            return true;
        }
        else
            return false;
    }
    
    public int GetRandom() {
        System.Random rand = new System.Random();
        int index = rand.Next(listValue.Count);
        return listValue[index];  //Wrong method as probability of getting each number is not same. 
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
 /*Below is better solution*/
 public class RandomizedSet {
    Dictionary<int, int> dict;
    List<int> list;

    public RandomizedSet() {
        dict = new Dictionary<int, int>();
        list = new List<int>();    
    }
    
    public bool Insert(int val) {
        if(dict.ContainsKey(val))
            return false;
        else{
            int index = list.Count();
            dict.Add(val, index);
            list.Add(val);
            return true;
        }
    }
    
    public bool Remove(int val) {
        if(dict.ContainsKey(val))
        {
            int index = dict[val];
            list[index] = list[list.Count()-1]; //Replace value with last list value
            //Update index in dictionary for last value
            dict[list[index]] = index;
            dict.Remove(val);
            list.RemoveAt(list.Count()-1);
            return true;
        }
        else{
            return false;
        }
    }
    
    public int GetRandom() {
        int total = list.Count();
        var rand = new Random();
        int randomIndex = rand.Next(total);
        return list[randomIndex];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
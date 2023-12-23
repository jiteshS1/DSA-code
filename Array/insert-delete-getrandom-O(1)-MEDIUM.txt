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
        return listValue[index]; 
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
public class Trie {
    public Node root;
    public Trie() {
        root = new Node();
    }
    public void Insert(string word) {
        var tmp = root;
        for(int i=0; i<word.Length; i++){
            if(tmp.ContainsChar(word[i])){
                tmp = tmp.GetChar(word[i]);
            }else{
                tmp = tmp.InsertChar(word[i]);
            }
        }
        tmp.SetEnd();
    }
    
    public bool Search(string word) {
       var tmp = root;
       for(int i=0; i<word.Length; i++){
           if(tmp.ContainsChar(word[i]))
           {
               tmp = tmp.GetChar(word[i]);
           }else{
               return false;
           }
       }
       return tmp.wordEnd;
    }
    
    public bool StartsWith(string prefix) {
       var tmp = root;
       for(int i=0; i<prefix.Length; i++){
           if(tmp.ContainsChar(prefix[i]))
           {
               tmp = tmp.GetChar(prefix[i]);
           }else{
               return false;
           }
       }
       return true;
    }

}
public class Node {
    public Node[] child; 
    public bool wordEnd;
    public Node() {
        child = new Node[26];
        wordEnd = false;
    }
    public bool ContainsChar(char ch){
        if(child[ch-'a']!=null)
            return true;
        else
            return false;
    }
    public Node GetChar(char ch){
        if(child[ch-'a']!=null)
            return child[ch-'a'];
        else
            return null;
    }
    public Node InsertChar(char ch){
        child[ch - 'a'] = new Node();
        return child[ch - 'a'];
    }
    public void SetEnd(){
        wordEnd = true;
    }
}
/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
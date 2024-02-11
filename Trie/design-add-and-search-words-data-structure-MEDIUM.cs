public class WordDictionary {
    Node root;
    public WordDictionary() {
        root = new Node();
    }
    
    public void AddWord(string word) {
        var tmp = root;
        for(int i=0; i<word.Length; i++){
            if(tmp.Contains(word[i]))
            {
                tmp = tmp.Get(word[i]);
            }else{
                tmp = tmp.Insert(word[i]);
            }
        }
        tmp.isEnd = true;
    }
    
    public bool Search(string word) {
        return CheckWord(word, root);
    }
    public bool CheckWord(string word, Node node){
        for(int i=0; i<word.Length; i++){
                if(word[i]!='.')
                {
                    if(node.Contains(word[i]))
                    {
                        node = node.Get(word[i]);
                    }else{
                        return false;
                    }
                }else{
                    for(int j=0; j<26; j++){
                        if (node.child[j] != null) {
                            var res = CheckWord(word.Substring(i + 1), node.child[j]);
                            if (res) {
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            return node.isEnd;
    }
}
public class Node{
    public Node[] child;
    public bool isEnd;
    public Node(){
        child = new Node[26];
        isEnd = false;
    }
    public bool Contains(char ch){
        if(child[ch-'a']!=null)
            return true;
        else return false;
    }
    public Node Get(char ch){
        if(child[ch-'a']!=null)
            return child[ch-'a'];
        else return null;
    }
    public Node Insert(char ch){
        child[ch-'a'] = new Node();
        return child[ch-'a'];
    }
} 
/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */
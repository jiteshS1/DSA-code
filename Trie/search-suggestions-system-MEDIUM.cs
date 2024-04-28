public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        Node root = new Node();
        Node cur = root;
        //Insert all products in trie
        foreach(var prd in products){
            foreach(char ch in prd){
                if(cur.Contains(ch))
                    cur = cur.Get(ch);
                else
                    cur = cur.Insert(ch);
                //Add suggestions
                cur.sugg.Add(prd);
                cur.sugg.Sort();
                if(cur.sugg.Count()>3)
                    cur.sugg.RemoveRange(3, cur.sugg.Count()-3);
            }
            cur.isEnd = true;
            cur = root;
        }

        //Fetch suggestions
        IList<IList<string>> res = new List<IList<string>>();
        string word = "";
        foreach(char ch in searchWord){
            IList<string> sug = new List<string>();
            if(cur.Contains(ch)){
                cur = cur.Get(ch);
            }
            res.Add(cur.sugg);
        }
        return res;
    }
}
public class Node{
    public Node[] child;
    public bool isEnd;
    public List<string> sugg;
    public Node(){
        child = new Node[26];
        isEnd = false;
        sugg = new List<string>();
    }
    public bool Contains(char ch){
        if(child[ch - 97]!=null) 
            return true;
        else 
            return false;
    }
    public Node Get(char ch){
        if(child[ch - 97]!=null) 
            return child[ch - 97];
        else 
            return null;
    }
    public Node Insert(char ch){
        var res = new Node();
        child[ch - 97] = res;
        return res;
    }
}
/*
- Use trie to store products
#Method to return 3 suggestions:
    I/P: Node
    Output: list of string
    - if count is 3 return the list
    - Store char in curr string
    - if isEnd true
        - store current string in res
        - reset current string
    - Loop 26 times
        - if location is not null
            - call same method with that node 


--------------working C# Solution-------------------
public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        TrieNode root = new();
        //O(nlog(n))
        Array.Sort(products);
        //O(M), Space O(M) M: Number of characters in searchWord
        TrieNode node = root;
        foreach(var c in searchWord){
            if(!node.Children.ContainsKey(c))
                node.Children[c] = new TrieNode();
            node = node.Children[c];
        }

        //O(N * k) N: total number of characters. k: average len of product
        for(int i=0; i<products.Length; i++){
            string word = products[i];
            node = root;
            foreach(var c in word){
                if(!node.Children.ContainsKey(c))
                    break;
                node = node.Children[c];
                if(node.TopWords.Count<3)
                    node.TopWords.Add(word);
            }
        }

        //O(M)
        TrieNode cur = root;
        List<IList<string>> ret = new();
        foreach(var c in searchWord){
            cur = cur.Children[c];
            ret.Add(cur.TopWords);
        }
        return ret;
    }
}

public class TrieNode {
    public Dictionary<char, TrieNode> Children = new();
    public List<string> TopWords = new();
    public bool IsWord;
    public TrieNode(){}
}

https://leetcode.com/problems/search-suggestions-system/solutions/4170605/trie-implementation-with-time-space-complexity-analysis/?source=submission-noac
*/
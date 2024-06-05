public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        var dict = new Dictionary<string, List<string>>();
        wordList.Add(beginWord);

        //Prepare list of simmilar words
        for(int i=0; i<wordList.Count(); i++){
            for(int j=0; j<wordList.Count(); j++){
                if(wordList[i]!=wordList[j]){
                    if(IsSingleCharChange(wordList[i], wordList[j])){
                        if(dict.ContainsKey(wordList[i])){
                            dict[wordList[i]].Add(wordList[j]);
                        }else{
                            dict[wordList[i]] = new List<string>(){wordList[j]};
                        }
                    }
                }
            }    
        }

        var q = new Queue<string>();
        q.Enqueue(beginWord);
        var vis = new HashSet<string>();
        int res = 0;
        while(q.Count()>0){
            int len = q.Count();
            for(int i=0; i<len; i++){
                var word = q.Dequeue();
                if(word == endWord)
                    return res+1;
                vis.Add(word);
                if(dict.ContainsKey(word)){
                    var neighbour = dict[word];
                    for(int j=0; j<neighbour.Count(); j++){
                        if(!vis.Contains(neighbour[j])){
                            q.Enqueue(neighbour[j]);
                        }
                    }
                }
            }
            res++;
        }
        return 0;
    }
    public bool IsSingleCharChange(string word1, string word2){
        int i=0, acceptable = 1;
        while(i < word1.Length){
            if(word1[i] == word2[i])
            {
                i++;
                continue;
            }else if(acceptable > 0){
                i++;
                acceptable--;
                continue;
            }else{
                return false;
            }
        }
        return true;
    }
}
/*
    TC, SC: O(n^2 * L)
*/
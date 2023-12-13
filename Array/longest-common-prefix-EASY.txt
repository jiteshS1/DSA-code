public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        char[] prefix= strs[0].ToCharArray();
        for(int i=1; i<strs.Length; i++)
        {
            char[] charAr=strs[i].ToCharArray();
                    bool notSame=false;
                    for(int j=0; j<prefix.Length; j++)
                    {
                        if(charAr.Length>j && prefix[j]==charAr[j]  && notSame==false)
                        {
                            continue;
                        }else
                        {
                            notSame = true;
                            prefix[j]='\0';
                        }
                    }
                    if(prefix.Length>0 && prefix[0]=='\0')
                        return "";
        }
        return (new string(prefix)).Trim().TrimEnd('\0');
    }
}
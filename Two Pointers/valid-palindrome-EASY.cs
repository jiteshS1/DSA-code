public class Solution {
    public bool IsPalindrome(string s) {
        string res = RemoveUnwantedChars(s);
        int head = 0, tail = res.Length-1;
        while(head <= tail){
            if(res[head] == res[tail]){
                head++;
                tail--;
            }else 
                return false;
        }
        return true;
    }
    public string RemoveUnwantedChars(string s){
        string res = "";
        foreach(char ch in s){
            if((ch >= 'a' && ch <= 'z') 
            || (ch >= '0' && ch <= '9')){
                res += ch;
            }
            if(ch >= 'A' && ch <= 'Z'){
                int gap = ch - 'A';
                char tmp = (char) ('a' + gap);
                res += tmp;
            }
        }
        return res;
    }
}
/*
TC, SC: O(n)
#Method to remove unwanted chars O(n)
- Loop char in s
    - if in range then add in string
- return string

- Compare char from both side and return  
UT: 
""
"abghba"


------------------Below soution in Java with TC: O(n) & SC: O(1)--------------
class Solution {
    public boolean isPalindrome(String s) {
        if (s.isEmpty()) {
        	return true;
        }
        int start = 0;
        int last = s.length() - 1;
        while(start <= last) {
        	char currFirst = s.charAt(start);
        	char currLast = s.charAt(last);
        	if (!Character.isLetterOrDigit(currFirst )) {
        		start++;
        	} else if(!Character.isLetterOrDigit(currLast)) {
        		last--;
        	} else {
        		if (Character.toLowerCase(currFirst) != Character.toLowerCase(currLast)) {
        			return false;
        		}
        		start++;
        		last--;
        	}
        }
        return true;
    }
}

*/
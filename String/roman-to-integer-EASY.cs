public class Solution {
    public int RomanToInt(string s) {
        var roman = GetRomanNumerals();
        char[] list = s.ToCharArray();
        char first;
        first = list[0];
        int result=0, temp=0;
        Boolean lastAdded =false;
        for(int i=1; i<list.Length; i++){
            if(roman[first] > roman[list[i]])
            {
                result += roman[first];
                first = list[i];
                lastAdded =false;
            }else if(roman[first] < roman[list[i]]){
                temp = roman[list[i]] - roman[first];
                result += temp;
                lastAdded = true;
                if(i+1 < list.Length)
                {
                    first = list[++i];
                    lastAdded = false;
                }
            }else //When both are same
            {
                result += roman[first] + roman[list[i]];
                lastAdded = true;
                if(i+1 < list.Length)
                {
                    first = list[++i];
                    lastAdded = false;
                }
            }
        }
        if(lastAdded == false)
            result += roman[first];

        return result;
    }
    Dictionary<char, int> GetRomanNumerals(){
        var roman = new Dictionary<char, int>();
        roman.Add('I', 1);
        roman.Add('V', 5);
        roman.Add('X', 10);
        roman.Add('L', 50);
        roman.Add('C', 100);
        roman.Add('D', 500);
        roman.Add('M', 1000);
        return roman;
    }
}
/*
    Two pointers: fir, sec
    if fir>sec 
        Add fir value in result
    else if fir<sec
        subtract sec-fir and add in result
    else //same
        add fir & sec in result

    Simpler approach: (Python)
    class Solution:
    def romanToInt(self, s: str) -> int:
        translations = {
            "I": 1,
            "V": 5,
            "X": 10,
            "L": 50,
            "C": 100,
            "D": 500,
            "M": 1000
        }
        number = 0
        s = s.replace("IV", "IIII").replace("IX", "VIIII")
        s = s.replace("XL", "XXXX").replace("XC", "LXXXX")
        s = s.replace("CD", "CCCC").replace("CM", "DCCCC")
        for char in s:
            number += translations[char]
        return number
*/

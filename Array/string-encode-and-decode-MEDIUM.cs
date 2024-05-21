public class Solution {

    // Encode a list of strings into a single string
    public string Encode(IList<string> strs) {
        var sb = new StringBuilder();
        foreach(string str in strs){
            int len = str.Length;
            // Append the length of the string followed by a separator (e.g., ';')
            sb.Append(len).Append(';');
            sb.Append(str);
        }
        return sb.ToString();
    }

    // Decode a single string into a list of strings
    public List<string> Decode(string s) {
        var res = new List<string>();
        if(string.IsNullOrEmpty(s)){
            return res;
        }
        int len = 0;
        int i = 0;
        
        while (i < s.Length) {
            // Extract the length of the next string
            int separatorIndex = s.IndexOf(';', i);
            if (separatorIndex == -1) {
                // Invalid format, separator not found
                break;
            }
            if (!int.TryParse(s.Substring(i, separatorIndex - i), out len)) {
                // Invalid length format
                break;
            }
            // Move i to the start of the next string
            i = separatorIndex + 1;
            // Extract the next string using the length
            string tmp = s.Substring(i, len);
            res.Add(tmp);
            // Move i to the position after the extracted string
            i += len;
        }
        return res;
   }
}
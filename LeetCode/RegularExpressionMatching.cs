//正则表达式 匹配
// '*'匹配前面字符 0 ~ ∞ (所以第一个字符不能为'*'), '.'匹配当前位置一个字符
// same examples:
//isMatch("aa","a") → false
//isMatch("aa","aa") → true
//isMatch("aaa","aa") → false
//isMatch("aa", "a*") → true
//isMatch("aa", ".*") → true
//isMatch("ab", ".*") → true
//isMatch("ab", ".*c") → false
//isMatch("aab", "c*a*b") → true
//isMatch("aaa", "ab*ac*a") → true
//isMatch("bbbba", ".*a*a") → true
public class Solution {
    public bool IsMatch(string s, string p) {
        if (p == ".*") return true;
        
        int i, j;
        char prechar = '';
        for (i = 0, j = 0; i < s.Length; i++)
        {
            if (j >= p.Length) return false;
            if ((s[i] == p[j]) || (p[j] == '.')) ;
            else if (prechar != '' && p[j] == '*' && ((prechar == s[i]) || (prechar == '.'))) ;
            else
            {
                while (s[i] != p[j])
                {
                    if (j + 1 < p.Length) j++;
                    else return false;
                    if (p[j] == '*') j++;
                    else return false;
                }
            }

            if (p[j] != '*') 
            {
                prechar = p[j];
                j++;
            }
        }

        if (i == s.Length && j < p.Length)
            return false;

        return true;
    }
}
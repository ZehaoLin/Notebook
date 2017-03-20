//Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

//For example,
//"A man, a plan, a canal: Panama" is a palindrome.
//"race a car" is not a palindrome.
public class Solution {
    public bool IsPalindrome(string s) {//注意数字
        if (s == null || s.Length == 0) return true;//字符串为空
        s = s.ToLower();
        int i = 0, j = s.Length - 1;
        while (i < j)
        {
            while (i < j && !((s[i] >= 'a' && s[i] <= 'z') || (s[i] >= '0' && s[i] <= '9'))) i++;
            while (i < j && !((s[j] >= 'a' && s[j] <= 'z') || (s[j] >= '0' && s[j] <= '9'))) j--;
            if (s[i] != s[j]) return false;
            i++;
            j--;
        }

        return true;
    }
}
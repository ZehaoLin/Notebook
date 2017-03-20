
//动态规划方法求解
public class Solution {
    public string LongestPalindrome(string s) {
        if (s.Length == 0 || s == null) return null;
        if (s.Length == 1) return s;

        int maxLen = 0, left = 0;
        bool[,] dp = new bool[s.Length, s.Length];
        for (int j = 0; j < s.Length; j++)
        {
            for (int i = 0; i < j; i++)
            {
                if (j == i + 1 && s[i] == s[j])//两个元素相邻
                    dp[i, j] = true;
                else if (j - i >= 2 && s[i] == s[j])//两个元素不相邻 且两个元素相同
                {
                    if (dp[i + 1, j - 1] == true)//区间[i+1, j-1]为回文串 则区间[i, j]为回文串
                        dp[i, j] = true;
                }

                if ((dp[i, j] == true) && maxLen < j - i + 1)//刷新最大回文串长度
                {
                    maxLen = j - i + 1;
                    left = i;
                }
            }
            dp[j, j] = true;//指向同一个元素 为回文串
        }

        if (s.Length > 1 && maxLen == 0)//注意长度>1且无回文串的字符串
            return s.Substring(0, 1);

        return s.Substring(left, maxLen);
    }
}
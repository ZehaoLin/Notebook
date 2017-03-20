//马拉车算法
//找出字符串中最长的回文串
//source: http://articles.leetcode.com/longest-palindromic-substring-part-ii/
public class Manacher
{
    //预处理 插入'#' 使字符串长度变为奇数 插入'^$'为防止越界
    private static string PreProcess(string s)
    {
        int n = s.Length;
        if (n == 0) return "^$";
        string ret = "^";
        for (int i = 0; i < n; i++)
        {
            ret += "#" + s.Substring(i, 1);
        }

        ret += "#$";
        return ret;
    }

    public static string Manacher(string s)
    {
        string T = PreProcess(s);
        int n = T.Length;
        int[] P = new int[n];
        int C = 0, R = 0;
        for (int i = 1; i < n - 1; i++)
        {
            int i_mirror = 2 * C - i;// 是i' = C - (i - C)

            P[i] = (R > i) ? Math.Min(R - i, P[i_mirror]) : 0;

            //尝试将回文串中心移动到i
            while (T[i + 1 + P[i]] == T[i - 1 - P[i]])
                P[i]++;
            
            //如果回文串中心超过R 调整中心
            if (i + P[i] > R)
            {
                C = i;
                R = i + P[i];
            }
        }

        //在P中找出最大元素
        int maxLen = 0;
        int centerIndex = 0;
        for (int i = 1; i < n - 1; i++)
        {
            if (P[i] > maxLen)
            {
                maxLen = P[i];
                centerIndex = i;
            }
        }

        return s.Substring((centerIndex - 1 - maxLen)/2, maxLen);
    }
}

public class Solution {
    public string Convert(string s, int numRows) {
        //特殊用例检测
        if (s.Length == 0) return string.Empty;
        else if (s.Length <= 2) return s;
        if (numRows <= 1) return s;

        int i = 0;
        int gap = numRows - 2;//斜角间隔
        string[] res = new string[numRows];
        //ZigZag排布后，将同一行的练成一个字符串
        while (i < s.Length)
        {
            for (int j = 0; j < numRows && i < s.Length; j++)//向下
            {
                res[j] += s[i++];
            }

            for (int j = gap; j > 0 && i < s.Length; j--)//斜线
            {
                res[j] += s[i++];
            }
        }

        //遍历临时数组
        string str = string.Empty;
        for (i = 0; i < numRows; i++)
        {
            str += res[i];
        }

        return str;
    }
}
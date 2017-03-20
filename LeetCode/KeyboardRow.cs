//找出可以在美式键盘上一行打出的单词
//假设输入只有字母，无大小写之分
//输入的字符可以重复
public class Solution {
    public string[] FindWords(string[] words) {
        if (words == null || words.Length == 0) return new string[0];
        string[] alphabet = { "qwertyuiop", "asdfghjkl", "zxcvbnm" };
        List<string> list = new List<string>();

        for (int i = 0; i < words.Length; i++)
        {
            //找出字母表中的行数
            int row = 0;
            bool isFind = true;
            string word = words[i].ToLower();
            for (int j = 0; j < 3; j++)
            {
                if (alphabet[j].Contains(word[0]) == true)
                {
                    row = j;
                    break;
                }
            }

            for (int j = 0; j < word.Length; j++)
            {
                if (alphabet[row].Contains(word[j]) == false)
                {
                    isFind = false;
                    break;
                }
            }
            if (isFind) list.Add(words[i]);
        }

        return list.ToArray();
    }
}
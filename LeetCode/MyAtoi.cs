//字符串转换为整型(32-bit)
public class Solution {
    public int MyAtoi(string str) {
        //特殊例子
        //str = ""              return 0
        //str = "-"             return 0
        //str = "&^"            return 0
        //str = "asf"           return 0
        //str = "asf23"         return 0
        //str = "23asf"         return 23
        //str = "2as3f"         return 2
        //str = "-01"           return -1
        //str = "    1"         return 1
        //str = "325878912759"  return Int32.MaxValue
        //str = "2231243258"    return Int32.MaxValue
        //str = "-2384758484"   return Int32.MinValue
        if (str.Length == 0) return 0;
        str = str.TrimStart();
        int ret = 0;
        int i = 0;
        bool isPos = true;//是否为正
        if (str[0] == '-' || str[0] == '+')
        {
            isPos = str[0] == '+' ? true : false;
            i = 1;
        }

        for (; i < str.Length; i++)
        {
            if (str[i] >= '0' && str[i] <= '9')
            {
                if (ret > (Int32.MaxValue - (str[i] - '0')) / 10)
                    return isPos ? Int32.MaxValue : Int32.MinValue;

                ret = ret * 10 + (str[i] - '0');
            }
            else
                break;
        }

        return isPos ? ret : -ret;
    }
}
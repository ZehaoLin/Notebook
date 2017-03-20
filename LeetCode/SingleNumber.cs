//找出数组中唯一一个出现一次的元素 其他出现两个
//用XOR办法  n ^ n == 0
public class SolutionI {
    public int SingleNumber(int[] nums) {
        int ret = 0;
        foreach (var item in nums)
        {
            ret ^= item;
        }
        return ret;
    }
}

//找出数组中唯一一个出现一次的元素 其他出现三个
//普通办法
public class SolutionII {
    public int SingleNumber(int[] nums) {
        int n = nums.Length;
        if (n == 0) return 0;
        int ret = 0;
        int[] count = new int[32];
        for (int i = 0; i < 31; i++)//32bit int
        {
            for (int j = 0; j < n; j++)//将元素的每一位相加
            {
                if ((nums[j] >> i) & 1)
                    count[i]++;
            }

            ret |= ((count[i] % 3) << i);
        }
        return ret;
    }
}

//线性办法

//模拟三进制运算
//three, two, one     分别表示当前是否已经出现了3个1， 2个1, 1个1
//0       0   0       表示没有出现1
//0       0   1       表示出现了1个1
//0       1   0       表示出现了2个1
//0       1   1       表示出现了3个1，这时我们需要把它转化成
//1       0   0       也就是3进制计算的结果，我们得到three=1，然后把two和one清0
public class SolutionIII {
    public int SingleNumber(int[] nums) {
        int n = nums.Length;
        if (n == 0) return 0;
        int one = 0, two = 0, three = 0;
        for (int i = 0; i < n; i++)
        {
            two |= (one & nums[i]);//本来有1个1，现在又出现1个1 或者 本来就有两个1
            one ^= nums[i];// 如果本来就有一个1了，这次又出现一个1，那么这我们需要向two进一位（也就是上一步，将two设成1），这是我们需要将one清为0
            three = two & one;
            //出现3次1，请one twice
            two &= ~three;
            one &= ~three;
        }
        return one;
    }
}
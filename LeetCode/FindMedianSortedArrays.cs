/// 数组 nums1 和 nums2 已经排好序
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if (nums1 == null && nums2 == null) return 0.0;

        int[] mergeNums = new int[nums1.Length + nums2.Length];//合并数组
        double median = 0;//中位数
        int i = 0, j = 0;

        for (int k = 0; k < mergeNums.Length; k++)
        {
            if (i == nums1.Length) //nums1到达边界
            {
                while (j != nums2.Length)
                    mergeNums[k++] = nums2[j++];
                break;
            }
            else if (j == nums2.Length)
            {
                while (i != nums1.Length)
                    mergeNums[k++] = nums1[i++];
                break;
            }
            else if (nums1[i] < nums2[j])
                mergeNums[k] = nums1[i++];
            else
                mergeNums[k] = nums2[j++];
        }

        if (mergeNums.Length % 2 == 0)// 合并数组的个数为偶数
            median = (double)(mergeNums[mergeNums.Length / 2 - 1] + mergeNums[mergeNums.Length / 2]) / 2;
        else
            median = mergeNums[mergeNums.Length / 2];

        return median;
    }
}
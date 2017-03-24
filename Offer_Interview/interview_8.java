/**
 * 旋转数组的最小数字
 * 题目：把一个数组最开始的若干个元素搬到数组的末尾，我们称之为数组的旋转。输入一个递增排序的数组的一个旋转，输出旋转数组
 * 的最小元素。
 * 例子：
 *      输入: [3, 4, 5, 1, 2]
 *      输出：1
 */
public class Solution {
    public int arrayMin(int[] nums) {
        if (nums == null || nums.length == 0)
            return null;
        
        int index1 = 0;
        int index2 = nums.length - 1;
        int indexMid = index1;
        while (nums[index1] >= nums[index2]) {
            if (index2 - index1 == 1) {
                indexMid = index2;
                break;
            }

            indexMid = (index1 + index2) / 2;
            //index1,index2,indexMid元素的值相等，则进行顺序查找
            if (nums[index1] == nums[index2] && nums[index1] == nums[indexMid]) {
                return minInorder(nums, index1, index2);
            }
            //二分查找
            if (nums[indexMid] >= nums[index1]) {
                index1 = indexMid;
            } else if (nums[indexMid] <= nums[index2]) {
                index2 = indexMid;
            }
        }

        return indexMid;
    }

    public minInorder(int[] nums, int index1, int index2) {
        int ret = nums[index1];
        for (int i = 0; i <= index2; ++i) {
            if (ret > nums[i]) {
                ret = nums[i];
            }
        }

        return ret;
    }
} 
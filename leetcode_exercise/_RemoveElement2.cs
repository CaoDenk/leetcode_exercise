namespace leetcode;

/// <summary>
/// 27. 移除元素
/// </summary>
internal class _RemoveElement2
{

    public int RemoveElement(int[] nums, int val)
    {
        int repeat = 0;

        for (int k = 0; k < nums.Length; k++)
        {
            if (nums[k] == val)
                ++repeat;
        }
        int i = 0, j = nums.Length - 1;

        while (i < j)
        {
            if (nums[i] != val)
            {
                ++i;
            }
            else
            {
                Swap(nums, i, j--);
            }

            if (nums[j] == val)
            {
                --j;
            }
        }

        return nums.Length-repeat;
    }

    void Swap(int[] nums,int i,int j)
    {
        (nums[j], nums[i]) = (nums[i], nums[j]);
    }

    static void print(int ret ,int[] nums)
    {

        for(int i=0;i<ret;++i)
        {
            Console.WriteLine(nums[i]);
        }

    }


    static void Main()
    {
        _RemoveElement2 r =new();
        {
            //int[] nums=new int[]{3,2,2,3};
            //int ret=r.RemoveElement(nums,3);
            //print(ret,nums);

        }
        {
            int[] nums = [0, 1, 2, 2, 3, 0, 4, 2];
            int ret = r.RemoveElement(nums, 2);
            print(ret, nums);
        }

        Console.ReadKey();

    }


}

   // foreach(int i in nums)
        // {
        //     set.Add(i);
        // }

        // int j=0;
        // foreach(int v in set )
        // {

        //     nums[j]=v;
        //     ++j;
        // }

        // return set.Count;

        // int i=0;
        // List<int> delNeeded=new List<int>();

        
        // for(;i<nums.Length;++i)
        // {

        //     if(set.Contains(nums[i]))
        //     {
        //     //    del.Push(nums[i]);
        //         del.Append(nums[i]);
        //     }else
        //        set.Add(nums[i]);

        // }
        // for(int j=nums.Length-1;j>=0;--j)
        // {
        //     if(del.Count==0)
        //         break;

        // }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace VM_Pro
{
    [Serializable]
    internal class LeiBieModel
    {
        internal LeiBieModel()
        {
        }

        /// <summary>
        /// 缺陷的类别
        /// </summary>
        internal string LeiBie = string.Empty;

        /// <summary>
        /// 该缺陷的最小面积
        /// </summary>
        internal double MinArea = 0;

        [NonSerialized]
        /// <summary>
        /// 该缺陷的当前面积
        /// </summary>
        internal double BeforArea = 0;

        /// <summary>
        /// 该缺陷的最大面积
        /// </summary>
        internal double MaxArea = 9999900;

        /// <summary>
        /// 该缺陷的NG总数
        /// </summary>
        internal int NG = 0;

        /// <summary>
        /// 是否启用该类别检测的标志
        /// </summary>
        internal bool CheckEnable = false;

        [NonSerialized]
        /// <summary>
        /// 当前检测结果 False：NG True:OK
        /// </summary>
        internal bool CurrentResultOK = true;


        [NonSerialized]
        /// <summary>
        /// 当前缺陷的NG区域
        /// </summary>
        internal List<HObject> lst_NGRegion = new List<HObject>();

        /// <summary>
        /// 将所有的NG区域联合为一个
        /// </summary>
        /// <returns></returns>
        internal HObject AllRegionToOne()
        {
            HObject hobj = null;
            if (lst_NGRegion != null)
            {
                for (int i = 0; i < lst_NGRegion.Count; i++)
                {
                    if (i == 0)
                    {
                        hobj = lst_NGRegion[i];
                        continue;
                    }
                    HOperatorSet.Union2(hobj, lst_NGRegion[i], out hobj);
                }
            }
            return hobj;
        }

        /// <summary>
        /// 释放当前列表的NG区域
        /// </summary>
        internal void ClearAllNGRegion()
        {
            for (int i = 0; i < lst_NGRegion.Count; i++)
            {
                lst_NGRegion[i].Dispose();
            }
        }

    }
}

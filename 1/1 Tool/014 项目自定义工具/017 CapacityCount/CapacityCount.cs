using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Pro
{
    [Serializable]
    internal class CapacityCount : ToolBase
    {

        /// <summary>
        /// 类构造器
        /// </summary>
        /// <param name="toolName">工具名称</param>
        /// <param name="taskName">所属任务</param>
        /// <param name="toolType">工具类型</param>
        internal CapacityCount(string toolName, string taskName, ToolType toolType)
        {
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;
            taskFailKeepRun = true;
        }

        /// <summary>
        /// 运行工具
        /// </summary>
        /// <param name="updateImage">是否刷新图像</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            if (initRun)
            {
                toolRunStatu = "运行成功";
                return;
            }
            bool _isTaskRunSuccess = true;
            for (int i = 0; i < Task.FindTaskByName(taskName).L_toolList.Count; i++)
            {
                if (Task.FindTaskByName(taskName).L_toolList[i].toolName == toolName)
                {
                    break;
                }
                if (Task.FindTaskByName(taskName).L_toolList[i].toolRunStatu != "运行成功")
                {
                    _isTaskRunSuccess = false;
                    break;
                }
            }
            if (_isTaskRunSuccess)
            {
                FuncLib.AddOK();
            }
            else
            {
                FuncLib.AddNG();
            }
            toolRunStatu = "运行成功";

        }
    }
}

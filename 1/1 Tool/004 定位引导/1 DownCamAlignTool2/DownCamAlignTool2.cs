using HalconDotNet;
using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWindow.Model;

namespace VM_Pro
{
    [Serializable]
    /// <summary>
    /// 底部定位2
    /// </summary>
    internal class DownCamAlignTool2 : ToolBase
    {
        internal DownCamAlignTool2(string toolName, string taskName, ToolType toolType)
        {
            参数 = new ToolPar();
            this.toolName = toolName;
            this.taskName = taskName;
            this.toolType = toolType;

            safetyRange.XY.X = 10;
            safetyRange.XY.Y = 10;
            safetyRange.U = 10;
        }

        /// <summary>
        /// 启用基板
        /// </summary>
        internal bool enableBasedBoard = true;
        /// <summary>
        /// 机械手Mark1拍照位置坐标
        /// </summary>
        internal XYU photoPos1 = new XYU();
        /// <summary>
        /// 机械手Mark2拍照位置坐标
        /// </summary>
        internal XYU photoPos2 = new XYU();
        /// <summary>
        /// 制作模板时产品坐标
        /// </summary>
        internal XYU templateFeaturePos = new XYU();
        /// <summary>
        /// 制作模板时示教的放料位置坐标
        /// </summary>
        internal XYU templatePlacePos = new XYU();
        /// <summary>
        /// 模板放料位置补偿值
        /// </summary>
        internal XYU templatePlacePosOffset = new XYU();
        /// <summary>
        /// 做模板时的基板坐标
        /// </summary>
        internal XYU templateBasedBoardPos = new XYU();
        /// <summary>
        /// 安全范围
        /// </summary>
        internal XYU safetyRange = new XYU();
        /// <summary>
        /// 本次基板坐标
        /// </summary>
        internal XYU curBasedBoardPos = new XYU();


        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {
            Frm_DownCamAlignTool2.Instance.lbl_runTime.Text = "0 ms";
            Frm_DownCamAlignTool2.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
            Frm_DownCamAlignTool2.Instance.lbl_toolTip.Text = "暂无提示";
        }
        /// <summary>
        /// 绕点旋转
        /// </summary>
        /// <param name="curPos">当前被旋转的点</param>
        /// <param name="rotateCenter">旋转中心</param>
        /// <param name="rotateAngle">旋转角度，单位为度</param>
        /// <returns></returns>
        internal XYU Rotate_At(XYU curPos, XYU rotateCenter, double rotateAngle)
        {
            double rad = rotateAngle * Math.PI / 180;
            var res = new XYU();
            res.XY.X = rotateCenter.XY.X + (curPos.XY.X - rotateCenter.XY.X) * Math.Cos(rad) - (curPos.XY.Y - rotateCenter.XY.Y) * Math.Sin(rad);
            res.XY.Y = rotateCenter.XY.Y + (curPos.XY.X - rotateCenter.XY.X) * Math.Sin(rad) + (curPos.XY.Y - rotateCenter.XY.Y) * Math.Cos(rad);
            res.U = curPos.U + rotateAngle;
            if (res.U < -180)
            {
                res.U += 360;
            }
            else if (res.U >= 180)
            {
                res.U -= 360;
            }
            return res;
        }
        /// <summary>
        /// 运行工具    
        /// </summary>
        /// <param name="initRun">初始化运行</param>
        internal override void Run(bool trigedByTool = true, bool initRun = false, int alarm = 1)
        {
            toolRunStatu = "未知原因";
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            if (initRun)
            {
                参数 = new ToolPar();
                toolRunStatu = "运行成功";
                sw.Stop();
                return;
            }

            if (((ToolPar)参数).输入.元件Mark1 == null || ((ToolPar)参数).输入.元件Mark1.Count == 0)
            {
                toolRunStatu = "元件Mark1识别异常";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            if (((ToolPar)参数).输入.元件Mark2 == null || ((ToolPar)参数).输入.元件Mark2.Count == 0)
            {
                toolRunStatu = "元件Mark2识别异常";
                if (!initRun)
                    FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }

            if (enableBasedBoard)
            {
                if (((ToolPar)参数).输入.基板Mark1 == null || ((ToolPar)参数).输入.基板Mark1.Count == 0)
                {
                    toolRunStatu = "基板Mark1识别异常";
                    if (!initRun)
                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                    goto Exit;
                }

                if (((ToolPar)参数).输入.基板Mark2 == null || ((ToolPar)参数).输入.基板Mark2.Count == 0)
                {
                    toolRunStatu = "基板Mark2识别异常";
                    if (!initRun)
                        FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                    goto Exit;
                }
            }


            //获取特征点X,Y
            //根据PCB的两个Mark点，选取在两者之间的点，这样的话，其误差两点都可平分一些。  当然也可以选取,Mark1或者Mark2为特征点
            XYU curFeaturePos = new XYU();
            curFeaturePos.XY.X = (((ToolPar)参数).输入.元件Mark1[0].X + ((ToolPar)参数).输入.元件Mark2[0].X - (photoPos2.XY.X - photoPos1.XY.X)) / 2;
            curFeaturePos.XY.Y = (((ToolPar)参数).输入.元件Mark1[0].Y + ((ToolPar)参数).输入.元件Mark2[0].Y - (photoPos2.XY.Y - photoPos1.XY.Y)) / 2;
            //////curFeaturePos.XY.X = ((ToolPar)参数).输入.元件Mark1[0].X;   //直接选取Mark点作为特征点也可以，但精度可能差一些
            //////curFeaturePos.XY.Y = ((ToolPar)参数).输入.元件Mark1[0].Y;
            //获取特征点U
            //1.【mark2X，mark2Y】即为在拍照点1时，拍到Mark2的特征点坐标。 此计算是为了消除，相机拍完Mark1之后，移动了一定距离再去拍Mark2。 
            //这样一来:相当于相机在同一个位置，拍了Mark1跟Mark2两个特征点坐标
            double mark2X = ((ToolPar)参数).输入.元件Mark2[0].X - (photoPos2.XY.X - photoPos1.XY.X);
            double mark2Y = ((ToolPar)参数).输入.元件Mark2[0].Y - (photoPos2.XY.Y - photoPos1.XY.Y);
            HTuple tempAngle;
            //1.计算两点所成的直线与水平线的夹角
            HOperatorSet.AngleLx(((ToolPar)参数).输入.元件Mark1[0].X, ((ToolPar)参数).输入.元件Mark1[0].Y, mark2X, mark2Y, out tempAngle);
            curFeaturePos.U = tempAngle;

            if (enableBasedBoard)
            {
                double curCenterX = (((ToolPar)参数).输入.基板Mark1[0].X + ((ToolPar)参数).输入.基板Mark2[0].X + (FuncLib.FindPosByName("XYZU", "玻璃片拍照位2").L_point[0] - FuncLib.FindPosByName("XYZU", "玻璃片拍照位1").L_point[0])) / 2;
                double curCenterY = (((ToolPar)参数).输入.基板Mark1[0].Y + ((ToolPar)参数).输入.基板Mark2[0].Y + (FuncLib.FindPosByName("XYZU", "玻璃片拍照位2").L_point[1] - FuncLib.FindPosByName("XYZU", "玻璃片拍照位1").L_point[1])) / 2;
                //////double curCenterX = ((ToolPar)参数).输入.基板Mark1[0].X;
                //////double curCenterY = ((ToolPar)参数).输入.基板Mark1[0].Y;
                HTuple angle = 0;
                HOperatorSet.AngleLx(((ToolPar)参数).输入.基板Mark1[0].X, ((ToolPar)参数).输入.基板Mark1[0].Y, ((ToolPar)参数).输入.基板Mark2[0].X + (FuncLib.FindPosByName("XYZU", "玻璃片拍照位2").L_point[0] - FuncLib.FindPosByName("XYZU", "玻璃片拍照位1").L_point[0]), ((ToolPar)参数).输入.基板Mark2[0].Y + (FuncLib.FindPosByName("XYZU", "玻璃片拍照位2").L_point[1] - FuncLib.FindPosByName("XYZU", "玻璃片拍照位1").L_point[1]), out angle);
                if (angle > 0)
                    angle = -3.1415 + angle;

                curBasedBoardPos.XY.X = curCenterX;
                curBasedBoardPos.XY.Y = curCenterY;
                curBasedBoardPos.U = Math.Round(angle.D, 6);
            }

            //然后将机械手平移和旋转，使本次定位特征点和模板时的特征点重合
            double offsetU = templateFeaturePos.U - curFeaturePos.U;
            offsetU = -offsetU * 180 / Math.PI;             //此处有时需要负号，有时不需要    1.此处是将角度转化为弧度
            double robotPosAfterRotateU = photoPos1.U - offsetU;

            //首先机械手旋转使产品角度重合，计算旋转之后特征点的坐标 
            XYU curFeaturePosAfterRotate = Rotate_At(curFeaturePos, photoPos1, -offsetU);   //1.让当前特征点坐标绕拍照点选择这么多角度，使得当前特征点与模板特征点平行，不重合

            //计算本次定位特征点经过旋转后的机械坐标和模板时的机械坐标的平移量
            double offsetX = templateFeaturePos.XY.X - curFeaturePosAfterRotate.XY.X;   //1.模板X - 旋转后与模板平行的X
            double offsetY = templateFeaturePos.XY.Y - curFeaturePosAfterRotate.XY.Y;

            //机械手再平移这些量，然后当机械手移动到计算出来的位置时，产品和模板时的产品重合
            XYU robotPosAfterRotateUAndMoveXY = new XYU();
            robotPosAfterRotateUAndMoveXY.XY.X = photoPos1.XY.X + offsetX;
            robotPosAfterRotateUAndMoveXY.XY.Y = photoPos1.XY.Y + offsetY;
            //1. robotPosAfterRotateUAndMoveXY该点是机械坐标，并非特征点的坐标   理论上，在该点时，本次所持产品的特征点坐标会与模板产品的特征点坐标保持完全重合
            robotPosAfterRotateUAndMoveXY.U = robotPosAfterRotateU;   

            //如果机械手移动到上述点，则本次的产品与模板产品重合

            //计算做模板时，从拍照位置到放料位置旋转的角度
            double anglePhotoToPlace = (templatePlacePos + templatePlacePosOffset).U - photoPos1.U; //1.templatePlacePos 模板放料坐标 + templatePlacePosOffset 模板补偿坐标 - 拍照1角度

            double productPlaceMoveX = ((templatePlacePos + templatePlacePosOffset).XY.X - photoPos1.XY.X);
            double productPlaceMoveY = ((templatePlacePos + templatePlacePosOffset).XY.Y - photoPos1.XY.Y);

            //计算模板产品绕模板拍照位旋转这么多角度时模板特征点应该所处的位置
            XYU templateFeatureAfterRotate = Rotate_At(templateFeaturePos, photoPos1, anglePhotoToPlace);   //1.拍照位1的模板特征点 绕拍照位旋转一定角度。使得特征点与放料点平行

            //计算当前产品特征点绕当前产品计算出阿里的拍照位旋转这么多角度时产品应该所处的位置
            //1. templateFeaturePos 与 robotPosAfterRotateUAndMoveXY 平行，
            XYU curProdrctFeaturePosAfterRotate = Rotate_At(templateFeaturePos, robotPosAfterRotateUAndMoveXY, anglePhotoToPlace);
            robotPosAfterRotateUAndMoveXY.U += anglePhotoToPlace;   //1.补其角度后，该点会与模板放料点平行

            //还应该加上当前产品和模板产品绕拍照点旋转后的差值 
            double spanXXX = templateFeatureAfterRotate.XY.X - curProdrctFeaturePosAfterRotate.XY.X;
            double spanYYY = templateFeatureAfterRotate.XY.Y - curProdrctFeaturePosAfterRotate.XY.Y;


            //当前产品旋转后的机械手位置加上放料平移量，就是本次定位最终的放料坐标
            //1.放料位 =  在拍照位1计算出的当前产品特征点平行于模板放料点的坐标 + （模板特征点为了平行模板放料点 - 产品特征点为了平行模板放料点）的角度偏差所造成的平移量 
            //  + 模板放料点与拍照点的平移量
            ((ToolPar)参数).输出.位置.XY.X = Math.Round(robotPosAfterRotateUAndMoveXY.XY.X + spanXXX + productPlaceMoveX, 3);
            ((ToolPar)参数).输出.位置.XY.Y = Math.Round(robotPosAfterRotateUAndMoveXY.XY.Y + spanYYY + productPlaceMoveY, 3);
            ((ToolPar)参数).输出.位置.U = Math.Round(robotPosAfterRotateUAndMoveXY.U, 3);

            if (enableBasedBoard)
            {
                //上述只是求出了基板位置不变时的贴合位置，实际因基板位置也会有变动，所以需要补偿因基板所产生的变动
                //首先需要计算出做模板时产品被贴合之后特征点坐标
                XYU templateFeaturePosAfterPlace = new XYU();
                templateFeaturePosAfterPlace.XY.X = templateFeatureAfterRotate.XY.X + productPlaceMoveX;
                templateFeaturePosAfterPlace.XY.Y = templateFeatureAfterRotate.XY.Y + productPlaceMoveY;

                //先把角度摆正，计算本次计算出来的最终机械手贴合位绕模板贴合后特征点旋转基板变动的角度后的机械手位置
                //首先计算本次基板和模板基板的角度偏差
                if (curBasedBoardPos.U > 0)
                    curBasedBoardPos.U = -3.1415 + curBasedBoardPos.U;
                double spanAngle = curBasedBoardPos.U - templateBasedBoardPos.U;    //1.计算当前载具与模板载具的角度偏差
                spanAngle = -spanAngle * 180 / Math.PI;             //此处有时需要负号，有时不需要   1.将角度转成弧度
                XYU robotPosAfterRotateBaseAngle = Rotate_At(templateFeaturePosAfterPlace, ((ToolPar)参数).输出.位置, -spanAngle);

                //摆回去
                double dddX = templateFeaturePosAfterPlace.XY.X - robotPosAfterRotateBaseAngle.XY.X;
                double dddY = templateFeaturePosAfterPlace.XY.Y - robotPosAfterRotateBaseAngle.XY.Y;

                XYU newRobotPos = new XYU();
                newRobotPos.XY.X = ((ToolPar)参数).输出.位置.XY.X + dddX;
                newRobotPos.XY.Y = ((ToolPar)参数).输出.位置.XY.Y + dddY;

                double spanEEEEX = curBasedBoardPos.XY.X - templateBasedBoardPos.XY.X;
                double spanEEEEY = curBasedBoardPos.XY.Y - templateBasedBoardPos.XY.Y;

                //((ToolPar)参数).输出.位置.XY.X = newRobotPos.XY.X + spanEEEEX;
                //((ToolPar)参数).输出.位置.XY.Y = newRobotPos.XY.Y + spanEEEEY;
                //1. 最终放料位 = PCB放料位 + 模板载具与当前载具为矫正角度造成的偏移量 + 模板载具与当前载具原先存在的平移量
                ((ToolPar)参数).输出.位置.XY.X = ((ToolPar)参数).输出.位置.XY.X + dddX + spanEEEEX; 
                ((ToolPar)参数).输出.位置.XY.Y = ((ToolPar)参数).输出.位置.XY.Y + dddY + spanEEEEY;
                ((ToolPar)参数).输出.位置.U = ((ToolPar)参数).输出.位置.U - spanAngle;
            } 
              
            if (Frm_DownCamAlignTool2.hasShown && Frm_DownCamAlignTool2.taskName == taskName && Frm_DownCamAlignTool2.toolName == toolName)
            {
                Frm_DownCamAlignTool2.Instance.lbl_curFeaturePosX.Text = curFeaturePos.XY.X.ToString();
                Frm_DownCamAlignTool2.Instance.lbl_curFeaturePosY.Text = curFeaturePos.XY.Y.ToString();
                Frm_DownCamAlignTool2.Instance.lbl_curFeaturePosU.Text = curFeaturePos.U.ToString();

                Frm_DownCamAlignTool2.Instance.lbl_curPlacePosX.Text = ((ToolPar)参数).输出.位置.XY.X.ToString();
                Frm_DownCamAlignTool2.Instance.lbl_curPlacePosY.Text = ((ToolPar)参数).输出.位置.XY.Y.ToString();
                Frm_DownCamAlignTool2.Instance.lbl_curPlacePosU.Text = ((ToolPar)参数).输出.位置.U.ToString();
            }

            //安全管控
            XYU offset = ((ToolPar)参数).输出.位置 - (templatePlacePos + templatePlacePosOffset);
            if (Math.Abs(offset.XY.X) > safetyRange.XY.X)
            {
                toolRunStatu = string.Format("产品放料 X 坐标超限，当前差值：{0}  上限差值：{1} mm", Math.Abs(offset.XY.X), safetyRange.XY.X);
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }
            else if (Math.Abs(offset.XY.Y) > safetyRange.XY.Y)
            {
                toolRunStatu = string.Format("产品放料 Y 坐标超限，当前差值：{0}  上限差值：{1} mm", Math.Abs(offset.XY.Y), safetyRange.XY.Y);
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }
            else if (Math.Abs(offset.U) > safetyRange.U)
            {
                toolRunStatu = string.Format("产品放料 U 坐标超限，当前差值：{0}  上限差值：{1} 度", Math.Abs(offset.U), safetyRange.U);
                FuncLib.ShowMsg(string.Format("工具 [ {0} . {1} ] 运行失败，原因：{2}", taskName, toolName, toolRunStatu), InfoType.Error);
                goto Exit;
            }


            sw.Stop();
            toolRunStatu = "运行成功";
            Exit:
            if (Frm_UpCamAlignTool.hasShown && Frm_UpCamAlignTool.taskName == taskName && Frm_UpCamAlignTool.toolName == toolName)
            {
                long time = sw.ElapsedMilliseconds;
                Frm_UpCamAlignTool.Instance.lbl_runTime.Text = string.Format("{0} ms", time.ToString());

                if (toolRunStatu == "运行成功")
                    Frm_UpCamAlignTool.Instance.lbl_toolTip.ForeColor = Color.FromArgb(48, 48, 48);
                else
                    Frm_UpCamAlignTool.Instance.lbl_toolTip.ForeColor = Color.Red;

                Frm_UpCamAlignTool.Instance.lbl_toolTip.Text = toolRunStatu.ToString();
            }
        }

        #region 工具参数
        [Serializable]
        public class ToolPar : ToolParBase
        {
            private P输入 _输入 = new P输入();
            public P输入 输入
            {
                get { return _输入; }
                set { _输入 = value; }
            }

            private P运行 _运行 = new P运行();
            public P运行 运行
            {
                get { return _运行; }
                set { _运行 = value; }
            }

            private P输出 _输出 = new P输出();
            public P输出 输出
            {
                get { return _输出; }
                set { _输出 = value; }
            }
        }
        [Serializable]
        public class P输入
        {
            private List<XY> _元件Mark1 = new List<XY>();
            public List<XY> 元件Mark1
            {
                get { return _元件Mark1; }
                set { _元件Mark1 = value; }
            }

            private List<XY> _元件Mark2 = new List<XY>();
            public List<XY> 元件Mark2
            {
                get { return _元件Mark2; }
                set { _元件Mark2 = value; }
            }

            private List<XY> _基板Mark1 = new List<XY>();
            public List<XY> 基板Mark1
            {
                get { return _基板Mark1; }
                set { _基板Mark1 = value; }
            }

            private List<XY> _基板Mark2 = new List<XY>();
            public List<XY> 基板Mark2
            {
                get { return _基板Mark2; }
                set { _基板Mark2 = value; }
            }
        }
        [Serializable]
        public class P运行 { }
        [Serializable]
        internal class P输出
        {
            private XYU _位置 = new XYU();
            public XYU 位置
            {
                get { return _位置; }
                set { _位置 = value; }
            }
        }
        #endregion

    }
}

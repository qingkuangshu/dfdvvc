using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ViewWindow.Model;

namespace VM_Pro
{
    internal static class HalconLib
    {

        /// <summary>
        /// 退出画操作时，调用此函数
        /// </summary>
        [DllImport("halcon.dll")]
        internal static extern void HIOCancelDraw();
        /// <summary>
        /// 设置字体
        /// </summary>
        internal static void SetFont(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font, HTuple hv_Bold, HTuple hv_Slant)
        {
            HTuple hv_OS = new HTuple(), hv_Fonts = new HTuple();
            HTuple hv_Style = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_AvailableFonts = new HTuple(), hv_Fdx = new HTuple();
            HTuple hv_Indices = new HTuple();
            HTuple hv_Font_COPY_INP_TMP = new HTuple(hv_Font);
            HTuple hv_Size_COPY_INP_TMP = new HTuple(hv_Size);

            // Initialize local and output iconic variables 
            try
            {
                //This procedure sets the text font of the current window with
                //the specified attributes.
                //
                //Input parameters:
                //WindowHandle: The graphics window for which the font will be set
                //Size: The font size. If Size=-1, the default of 16 is used.
                //Bold: If set to 'true', a bold font is used
                //Slant: If set to 'true', a slanted font is used
                //
                hv_OS.Dispose();
                HOperatorSet.GetSystem("operating_system", out hv_OS);
                if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                    new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
                {
                    hv_Size_COPY_INP_TMP.Dispose();
                    hv_Size_COPY_INP_TMP = 16;
                }
                if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
                {
                    //Restore previous behaviour
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = ((1.13677 * hv_Size_COPY_INP_TMP)).TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                else
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Size = hv_Size_COPY_INP_TMP.TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Courier";
                    hv_Fonts[1] = "Courier 10 Pitch";
                    hv_Fonts[2] = "Courier New";
                    hv_Fonts[3] = "CourierNew";
                    hv_Fonts[4] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Consolas";
                    hv_Fonts[1] = "Menlo";
                    hv_Fonts[2] = "Courier";
                    hv_Fonts[3] = "Courier 10 Pitch";
                    hv_Fonts[4] = "FreeMono";
                    hv_Fonts[5] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Luxi Sans";
                    hv_Fonts[1] = "DejaVu Sans";
                    hv_Fonts[2] = "FreeSans";
                    hv_Fonts[3] = "Arial";
                    hv_Fonts[4] = "Liberation Sans";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Times New Roman";
                    hv_Fonts[1] = "Luxi Serif";
                    hv_Fonts[2] = "DejaVu Serif";
                    hv_Fonts[3] = "FreeSerif";
                    hv_Fonts[4] = "Utopia";
                    hv_Fonts[5] = "Liberation Serif";
                }
                else
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple(hv_Font_COPY_INP_TMP);
                }
                hv_Style.Dispose();
                hv_Style = "";
                if ((int)(new HTuple(hv_Bold.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Bold";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Bold.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_Style = hv_Style + "Italic";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Slant.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Style.TupleEqual(""))) != 0)
                {
                    hv_Style.Dispose();
                    hv_Style = "Normal";
                }
                hv_AvailableFonts.Dispose();
                HOperatorSet.QueryFont(hv_WindowHandle, out hv_AvailableFonts);
                hv_Font_COPY_INP_TMP.Dispose();
                hv_Font_COPY_INP_TMP = "";
                for (hv_Fdx = 0; (int)hv_Fdx <= (int)((new HTuple(hv_Fonts.TupleLength())) - 1); hv_Fdx = (int)hv_Fdx + 1)
                {
                    hv_Indices.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_Indices = hv_AvailableFonts.TupleFind(
                            hv_Fonts.TupleSelect(hv_Fdx));
                    }
                    if ((int)(new HTuple((new HTuple(hv_Indices.TupleLength())).TupleGreater(
                        0))) != 0)
                    {
                        if ((int)(new HTuple(((hv_Indices.TupleSelect(0))).TupleGreaterEqual(0))) != 0)
                        {
                            hv_Font_COPY_INP_TMP.Dispose();
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(
                                    hv_Fdx);
                            }
                            break;
                        }
                    }
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(""))) != 0)
                {
                    throw new HalconException("Wrong value of control parameter Font");
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    {
                        HTuple
                          ExpTmpLocalVar_Font = (((hv_Font_COPY_INP_TMP + "-") + hv_Style) + "-") + hv_Size_COPY_INP_TMP;
                        hv_Font_COPY_INP_TMP.Dispose();
                        hv_Font_COPY_INP_TMP = ExpTmpLocalVar_Font;
                    }
                }
                HOperatorSet.SetFont(hv_WindowHandle, hv_Font_COPY_INP_TMP);

                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();

                throw HDevExpDefaultException;
            }


            //try
            //{
            //    HTuple hv_OS = null, hv_BufferWindowHandle = new HTuple();
            //    HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
            //    HTuple hv_Width = new HTuple(), hv_Height = new HTuple();
            //    HTuple hv_Scale = new HTuple(), hv_Exception = new HTuple();
            //    HTuple hv_SubFamily = new HTuple(), hv_Fonts = new HTuple();
            //    HTuple hv_SystemFonts = new HTuple(), hv_Guess = new HTuple();
            //    HTuple hv_I = new HTuple(), hv_Index = new HTuple(), hv_AllowedFontSizes = new HTuple();
            //    HTuple hv_Distances = new HTuple(), hv_Indices = new HTuple();
            //    HTuple hv_FontSelRegexp = new HTuple(), hv_FontsCourier = new HTuple();
            //    HTuple hv_Bold_COPY_INP_TMP = hv_Bold.Clone();
            //    HTuple hv_Font_COPY_INP_TMP = hv_Font.Clone();
            //    HTuple hv_Size_COPY_INP_TMP = hv_Size.Clone();
            //    HTuple hv_Slant_COPY_INP_TMP = hv_Slant.Clone();
            //    HOperatorSet.GetSystem("operating_system", out hv_OS);
            //    if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
            //        new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
            //    {
            //        hv_Size_COPY_INP_TMP = 16;
            //    }
            //    if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
            //    {
            //        try
            //        {
            //            HOperatorSet.OpenWindow(0, 0, 256, 256, 0, "buffer", "", out hv_BufferWindowHandle);
            //            HOperatorSet.SetFont(hv_BufferWindowHandle, "-Consolas-16-*-0-*-*-1-");
            //            HOperatorSet.GetStringExtents(hv_BufferWindowHandle, "test_string", out hv_Ascent,
            //                out hv_Descent, out hv_Width, out hv_Height);
            //            hv_Scale = 110.0 / hv_Width;
            //            hv_Size_COPY_INP_TMP = ((hv_Size_COPY_INP_TMP * hv_Scale)).TupleInt();
            //            HOperatorSet.CloseWindow(hv_BufferWindowHandle);
            //        }
            //        catch (HalconException HDevExpDefaultException1)
            //        {
            //            HDevExpDefaultException1.ToHTuple(out hv_Exception);
            //        }
            //        if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))).TupleOr(
            //            new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
            //        {
            //            hv_Font_COPY_INP_TMP = "Courier New";
            //        }
            //        else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
            //        {
            //            hv_Font_COPY_INP_TMP = "Consolas";
            //        }
            //        else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
            //        {
            //            hv_Font_COPY_INP_TMP = "Arial";
            //        }
            //        else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
            //        {
            //            hv_Font_COPY_INP_TMP = "Times New Roman";
            //        }
            //        if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
            //        {
            //            hv_Bold_COPY_INP_TMP = 1;
            //        }
            //        else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("false"))) != 0)
            //        {
            //            hv_Bold_COPY_INP_TMP = 0;
            //        }
            //        else
            //        {
            //            hv_Exception = "Wrong value of control parameter Bold";
            //            throw new HalconException(hv_Exception);
            //        }
            //        if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
            //        {
            //            hv_Slant_COPY_INP_TMP = 1;
            //        }
            //        else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("false"))) != 0)
            //        {
            //            hv_Slant_COPY_INP_TMP = 0;
            //        }
            //        else
            //        {
            //            hv_Exception = "Wrong value of control parameter Slant";
            //            throw new HalconException(hv_Exception);
            //        }
            //        try
            //        {
            //            HOperatorSet.SetFont(hv_WindowHandle, ((((((("-" + hv_Font_COPY_INP_TMP) + "-") + hv_Size_COPY_INP_TMP) + "-*-") + hv_Slant_COPY_INP_TMP) + "-*-*-") + hv_Bold_COPY_INP_TMP) + "-");
            //        }
            //        catch (HalconException HDevExpDefaultException1)
            //        {
            //            HDevExpDefaultException1.ToHTuple(out hv_Exception);
            //        }
            //    }
            //    else if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Dar"))) != 0)
            //    {
            //        hv_SubFamily = 0;
            //        if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
            //        {
            //            hv_SubFamily = hv_SubFamily.TupleBor(1);
            //        }
            //        else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleNotEqual("false"))) != 0)
            //        {
            //            hv_Exception = "Wrong value of control parameter Slant";
            //            throw new HalconException(hv_Exception);
            //        }
            //        if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
            //        {
            //            hv_SubFamily = hv_SubFamily.TupleBor(2);
            //        }
            //        else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleNotEqual("false"))) != 0)
            //        {
            //            hv_Exception = "Wrong value of control parameter Bold";
            //            throw new HalconException(hv_Exception);
            //        }
            //        if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
            //        {
            //            hv_Fonts = new HTuple();
            //            hv_Fonts[0] = "Menlo-Regular";
            //            hv_Fonts[1] = "Menlo-Italic";
            //            hv_Fonts[2] = "Menlo-Bold";
            //            hv_Fonts[3] = "Menlo-BoldItalic";
            //        }
            //        else if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))).TupleOr(
            //            new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
            //        {
            //            hv_Fonts = new HTuple();
            //            hv_Fonts[0] = "CourierNewPSMT";
            //            hv_Fonts[1] = "CourierNewPS-ItalicMT";
            //            hv_Fonts[2] = "CourierNewPS-BoldMT";
            //            hv_Fonts[3] = "CourierNewPS-BoldItalicMT";
            //        }
            //        else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
            //        {
            //            hv_Fonts = new HTuple();
            //            hv_Fonts[0] = "ArialMT";
            //            hv_Fonts[1] = "Arial-ItalicMT";
            //            hv_Fonts[2] = "Arial-BoldMT";
            //            hv_Fonts[3] = "Arial-BoldItalicMT";
            //        }
            //        else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
            //        {
            //            hv_Fonts = new HTuple();
            //            hv_Fonts[0] = "TimesNewRomanPSMT";
            //            hv_Fonts[1] = "TimesNewRomanPS-ItalicMT";
            //            hv_Fonts[2] = "TimesNewRomanPS-BoldMT";
            //            hv_Fonts[3] = "TimesNewRomanPS-BoldItalicMT";
            //        }
            //        else
            //        {
            //            HOperatorSet.QueryFont(hv_WindowHandle, out hv_SystemFonts);
            //            hv_Fonts = new HTuple();
            //            hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
            //            hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
            //            hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
            //            hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
            //            hv_Guess = new HTuple();
            //            hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP);
            //            hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Regular");
            //            hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "MT");
            //            for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
            //            {
            //                HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
            //                if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
            //                {
            //                    if (hv_Fonts == null)
            //                        hv_Fonts = new HTuple();
            //                    hv_Fonts[0] = hv_Guess.TupleSelect(hv_I);
            //                    break;
            //                }
            //            }
            //            hv_Guess = new HTuple();
            //            hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Italic");
            //            hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-ItalicMT");
            //            hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Oblique");
            //            for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
            //            {
            //                HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
            //                if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
            //                {
            //                    if (hv_Fonts == null)
            //                        hv_Fonts = new HTuple();
            //                    hv_Fonts[1] = hv_Guess.TupleSelect(hv_I);
            //                    break;
            //                }
            //            }
            //            hv_Guess = new HTuple();
            //            hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Bold");
            //            hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldMT");
            //            for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
            //            {
            //                HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
            //                if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
            //                {
            //                    if (hv_Fonts == null)
            //                        hv_Fonts = new HTuple();
            //                    hv_Fonts[2] = hv_Guess.TupleSelect(hv_I);
            //                    break;
            //                }
            //            }
            //            hv_Guess = new HTuple();
            //            hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldItalic");
            //            hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldItalicMT");
            //            hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldOblique");
            //            for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
            //            {
            //                HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
            //                if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
            //                {
            //                    if (hv_Fonts == null)
            //                        hv_Fonts = new HTuple();
            //                    hv_Fonts[3] = hv_Guess.TupleSelect(hv_I);
            //                    break;
            //                }
            //            }
            //        }
            //        hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(hv_SubFamily);
            //        try
            //        {
            //            HOperatorSet.SetFont(hv_WindowHandle, (hv_Font_COPY_INP_TMP + "-") + hv_Size_COPY_INP_TMP);
            //        }
            //        catch (HalconException HDevExpDefaultException1)
            //        {
            //            HDevExpDefaultException1.ToHTuple(out hv_Exception);
            //        }
            //    }
            //    else
            //    {
            //        hv_Size_COPY_INP_TMP = hv_Size_COPY_INP_TMP * 1.25;
            //        hv_AllowedFontSizes = new HTuple();
            //        hv_AllowedFontSizes[0] = 11;
            //        hv_AllowedFontSizes[1] = 14;
            //        hv_AllowedFontSizes[2] = 17;
            //        hv_AllowedFontSizes[3] = 20;
            //        hv_AllowedFontSizes[4] = 25;
            //        hv_AllowedFontSizes[5] = 34;
            //        if ((int)(new HTuple(((hv_AllowedFontSizes.TupleFind(hv_Size_COPY_INP_TMP))).TupleEqual(
            //            -1))) != 0)
            //        {
            //            hv_Distances = ((hv_AllowedFontSizes - hv_Size_COPY_INP_TMP)).TupleAbs();
            //            HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
            //            hv_Size_COPY_INP_TMP = hv_AllowedFontSizes.TupleSelect(hv_Indices.TupleSelect(
            //                0));
            //        }
            //        if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))).TupleOr(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(
            //            "Courier")))) != 0)
            //        {
            //            hv_Font_COPY_INP_TMP = "courier";
            //        }
            //        else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
            //        {
            //            hv_Font_COPY_INP_TMP = "helvetica";
            //        }
            //        else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
            //        {
            //            hv_Font_COPY_INP_TMP = "times";
            //        }
            //        if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
            //        {
            //            hv_Bold_COPY_INP_TMP = "bold";
            //        }
            //        else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("false"))) != 0)
            //        {
            //            hv_Bold_COPY_INP_TMP = "medium";
            //        }
            //        else
            //        {
            //            hv_Exception = "Wrong value of control parameter Bold";
            //            throw new HalconException(hv_Exception);
            //        }
            //        if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
            //        {
            //            if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("times"))) != 0)
            //            {
            //                hv_Slant_COPY_INP_TMP = "i";
            //            }
            //            else
            //            {
            //                hv_Slant_COPY_INP_TMP = "o";
            //            }
            //        }
            //        else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("false"))) != 0)
            //        {
            //            hv_Slant_COPY_INP_TMP = "r";
            //        }
            //        else
            //        {
            //            hv_Exception = "Wrong value of control parameter Slant";
            //            throw new HalconException(hv_Exception);
            //        }
            //        try
            //        {
            //            HOperatorSet.SetFont(hv_WindowHandle, ((((((("-adobe-" + hv_Font_COPY_INP_TMP) + "-") + hv_Bold_COPY_INP_TMP) + "-") + hv_Slant_COPY_INP_TMP) + "-normal-*-") + hv_Size_COPY_INP_TMP) + "-*-*-*-*-*-*-*");
            //        }
            //        catch (HalconException HDevExpDefaultException1)
            //        {
            //            HDevExpDefaultException1.ToHTuple(out hv_Exception);
            //            if ((int)((new HTuple(((hv_OS.TupleSubstr(0, 4))).TupleEqual("Linux"))).TupleAnd(
            //                new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
            //            {
            //                HOperatorSet.QueryFont(hv_WindowHandle, out hv_Fonts);
            //                hv_FontSelRegexp = (("^-[^-]*-[^-]*[Cc]ourier[^-]*-" + hv_Bold_COPY_INP_TMP) + "-") + hv_Slant_COPY_INP_TMP;
            //                hv_FontsCourier = ((hv_Fonts.TupleRegexpSelect(hv_FontSelRegexp))).TupleRegexpMatch(
            //                    hv_FontSelRegexp);
            //                if ((int)(new HTuple((new HTuple(hv_FontsCourier.TupleLength())).TupleEqual(
            //                    0))) != 0)
            //                {
            //                    hv_Exception = "Wrong font name";
            //                }
            //                else
            //                {
            //                    try
            //                    {
            //                        HOperatorSet.SetFont(hv_WindowHandle, (((hv_FontsCourier.TupleSelect(
            //                            0)) + "-normal-*-") + hv_Size_COPY_INP_TMP) + "-*-*-*-*-*-*-*");
            //                    }
            //                    catch (HalconException HDevExpDefaultException2)
            //                    {
            //                        HDevExpDefaultException2.ToHTuple(out hv_Exception);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch { }
        }
        /// <summary>
        /// 显示文本
        /// </summary>
        /// <param name="windowHandle"></param>
        /// <param name="hv_String"></param>
        /// <param name="size"></param>
        /// <param name="hv_Row"></param>
        /// <param name="hv_Column"></param>
        /// <param name="hv_Color"></param>
        /// <param name="hv_Box"></param>
        /// <param name="coordSystem"></param>
        internal static void DispText(HTuple windowHandle, HTuple hv_String, int size, HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box, string coordSystem = "image")
        {
            try
            {
                HalconLib.SetFont(windowHandle, (HTuple)size, "sans", "true", "false");
                //HalconLib.SetFont(windowHandle, (HTuple)size, "mono", "true", "false");

                HTuple hv_CoordSystem = coordSystem;
                HTuple hv_M = null, hv_N = null, hv_Red = null;
                HTuple hv_Green = null, hv_Blue = null, hv_RowI1Part = null;
                HTuple hv_ColumnI1Part = null, hv_RowI2Part = null, hv_ColumnI2Part = null;
                HTuple hv_RowIWin = null, hv_ColumnIWin = null, hv_WidthWin = null;
                HTuple hv_HeightWin = null, hv_I = null, hv_RowI = new HTuple();
                HTuple hv_ColumnI = new HTuple(), hv_StringI = new HTuple();
                HTuple hv_MaxAscent = new HTuple(), hv_MaxDescent = new HTuple();
                HTuple hv_MaxWidth = new HTuple(), hv_MaxHeight = new HTuple();
                HTuple hv_R1 = new HTuple(), hv_C1 = new HTuple(), hv_FactorRowI = new HTuple();
                HTuple hv_FactorColumnI = new HTuple(), hv_UseShadow = new HTuple();
                HTuple hv_ShadowColor = new HTuple(), hv_Exception = new HTuple();
                HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
                HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
                HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
                HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
                HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
                HTuple hv_CurrentColor = new HTuple();
                HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
                HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
                HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
                HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
                HTuple hv_String_COPY_INP_TMP = hv_String.Clone();
                // return;
                if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
                {
                    hv_Color_COPY_INP_TMP = "";
                }
                if ((int)(new HTuple(hv_Box_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
                {
                    hv_Box_COPY_INP_TMP = "false";
                }
                hv_M = (new HTuple(hv_Row_COPY_INP_TMP.TupleLength())) * (new HTuple(hv_Column_COPY_INP_TMP.TupleLength()
                    ));
                hv_N = new HTuple(hv_Row_COPY_INP_TMP.TupleLength());
                if ((int)((new HTuple(hv_M.TupleEqual(0))).TupleOr(new HTuple(hv_String_COPY_INP_TMP.TupleEqual(
                    new HTuple())))) != 0)
                {
                    return;
                }
                if ((int)(new HTuple(hv_M.TupleNotEqual(1))) != 0)
                {
                    if ((int)(new HTuple((new HTuple(hv_Row_COPY_INP_TMP.TupleLength())).TupleEqual(
                        1))) != 0)
                    {
                        hv_N = new HTuple(hv_Column_COPY_INP_TMP.TupleLength());
                        HOperatorSet.TupleGenConst(hv_N, hv_Row_COPY_INP_TMP, out hv_Row_COPY_INP_TMP);
                    }
                    else if ((int)(new HTuple((new HTuple(hv_Column_COPY_INP_TMP.TupleLength()
                        )).TupleEqual(1))) != 0)
                    {
                        HOperatorSet.TupleGenConst(hv_N, hv_Column_COPY_INP_TMP, out hv_Column_COPY_INP_TMP);
                    }
                    else if ((int)(new HTuple((new HTuple(hv_Column_COPY_INP_TMP.TupleLength()
                        )).TupleNotEqual(new HTuple(hv_Row_COPY_INP_TMP.TupleLength())))) != 0)
                    {
                        throw new HalconException("Number of elements in Row and Column does not match.");
                    }
                    if ((int)(new HTuple((new HTuple(hv_String_COPY_INP_TMP.TupleLength())).TupleEqual(
                        1))) != 0)
                    {
                        HOperatorSet.TupleGenConst(hv_N, hv_String_COPY_INP_TMP, out hv_String_COPY_INP_TMP);
                    }
                    else if ((int)(new HTuple((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                        )).TupleNotEqual(hv_N))) != 0)
                    {
                        throw new HalconException("Number of elements in Strings does not match number of positions.");
                    }
                }
                // return;
                HOperatorSet.GetRgb(windowHandle, out hv_Red, out hv_Green, out hv_Blue);
                HOperatorSet.GetPart(windowHandle, out hv_RowI1Part, out hv_ColumnI1Part,
                    out hv_RowI2Part, out hv_ColumnI2Part);
                HOperatorSet.GetWindowExtents(windowHandle, out hv_RowIWin, out hv_ColumnIWin,
                    out hv_WidthWin, out hv_HeightWin);
                HOperatorSet.SetPart(windowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
                HTuple end_val89 = hv_N - 1;
                HTuple step_val89 = 1;
                for (hv_I = 0; hv_I.Continue(end_val89, step_val89); hv_I = hv_I.TupleAdd(step_val89))
                {
                    hv_RowI = hv_Row_COPY_INP_TMP.TupleSelect(hv_I);
                    hv_ColumnI = hv_Column_COPY_INP_TMP.TupleSelect(hv_I);
                    if ((int)(new HTuple(hv_N.TupleEqual(1))) != 0)
                    {
                        hv_StringI = hv_String_COPY_INP_TMP.Clone();
                    }
                    else
                    {
                        hv_StringI = hv_String_COPY_INP_TMP.TupleSelect(hv_I);
                    }
                    if ((int)(new HTuple(hv_RowI.TupleEqual(-1))) != 0)
                    {
                        hv_RowI = 12;
                    }
                    if ((int)(new HTuple(hv_ColumnI.TupleEqual(-1))) != 0)
                    {
                        hv_ColumnI = 12;
                    }
                    hv_StringI = ((("" + hv_StringI) + "")).TupleSplit("\n");
                    HOperatorSet.GetFontExtents(windowHandle, out hv_MaxAscent, out hv_MaxDescent,
                        out hv_MaxWidth, out hv_MaxHeight);
                    if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
                    {
                        hv_R1 = hv_RowI.Clone();
                        hv_C1 = hv_ColumnI.Clone();
                    }
                    else
                    {
                        hv_FactorRowI = (1.0 * hv_HeightWin) / ((hv_RowI2Part - hv_RowI1Part) + 1);
                        hv_FactorColumnI = (1.0 * hv_WidthWin) / ((hv_ColumnI2Part - hv_ColumnI1Part) + 1);
                        hv_R1 = (((hv_RowI - hv_RowI1Part) + 0.5) * hv_FactorRowI) - 0.5;
                        hv_C1 = (((hv_ColumnI - hv_ColumnI1Part) + 0.5) * hv_FactorColumnI) - 0.5;
                    }
                    hv_UseShadow = 1;
                    hv_ShadowColor = "gray";
                    if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
                    {
                        if (hv_Box_COPY_INP_TMP == null)
                            hv_Box_COPY_INP_TMP = new HTuple();
                        hv_Box_COPY_INP_TMP[0] = "#fce9d4";
                        hv_ShadowColor = "#f28d26";
                    }
                    if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
                        1))) != 0)
                    {
                        if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
                        {
                        }
                        else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
                            "false"))) != 0)
                        {
                            hv_UseShadow = 0;
                        }
                        else
                        {
                            hv_ShadowColor = hv_Box_COPY_INP_TMP.TupleSelect(1);
                            try
                            {
                                HOperatorSet.SetColor(windowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                                    1));
                            }
                            catch (HalconException HDevExpDefaultException1)
                            {
                                HDevExpDefaultException1.ToHTuple(out hv_Exception);
                                hv_Exception = new HTuple("Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)");
                                throw new HalconException(hv_Exception);
                            }
                        }
                    }
                    if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
                    {
                        try
                        {
                            HOperatorSet.SetColor(windowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                                0));
                        }
                        catch (HalconException HDevExpDefaultException1)
                        {
                            HDevExpDefaultException1.ToHTuple(out hv_Exception);
                            hv_Exception = new HTuple("Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)");
                            throw new HalconException(hv_Exception);
                        }
                        hv_StringI = (" " + hv_StringI) + " ";
                        hv_Width = new HTuple();
                        for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_StringI.TupleLength()
                            )) - 1); hv_Index = (int)hv_Index + 1)
                        {
                            HOperatorSet.GetStringExtents(windowHandle, hv_StringI.TupleSelect(hv_Index),
                                out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                            hv_Width = hv_Width.TupleConcat(hv_W);
                        }
                        hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_StringI.TupleLength()));
                        hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                        hv_R2 = hv_R1 + hv_FrameHeight;
                        hv_C2 = hv_C1 + hv_FrameWidth;
                        HOperatorSet.GetDraw(windowHandle, out hv_DrawMode);
                        HOperatorSet.SetDraw(windowHandle, "fill");
                        HOperatorSet.SetColor(windowHandle, hv_ShadowColor);
                        if ((int)(hv_UseShadow) != 0)
                        {
                            HOperatorSet.DispRectangle1(windowHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1,
                                hv_C2 + 1);
                        }
                        HOperatorSet.SetColor(windowHandle, hv_Box_COPY_INP_TMP.TupleSelect(0));
                        HOperatorSet.DispRectangle1(windowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
                        HOperatorSet.SetDraw(windowHandle, hv_DrawMode);
                    }
                    //   return;
                    for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_StringI.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                    {
                        if ((int)(new HTuple(hv_N.TupleEqual(1))) != 0)
                        {
                            hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                                )));
                        }
                        else
                        {
                            hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_I % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                                )));
                        }
                        if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                            "auto")))) != 0)
                        {
                            try
                            {
                                HOperatorSet.SetColor(windowHandle, hv_CurrentColor);
                            }
                            catch (HalconException HDevExpDefaultException1)
                            {
                                HDevExpDefaultException1.ToHTuple(out hv_Exception);
                                hv_Exception = ((("Wrong value of control parameter Color[" + (hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                                    )))) + "] == '") + hv_CurrentColor) + "' (must be a valid color string)";
                                throw new HalconException(hv_Exception);
                            }
                        }
                        else
                        {
                            HOperatorSet.SetRgb(windowHandle, hv_Red, hv_Green, hv_Blue);
                        }
                        hv_RowI = hv_R1 + (hv_MaxHeight * hv_Index);
                        HOperatorSet.SetTposition(windowHandle, hv_RowI, hv_C1);
                        HOperatorSet.WriteString(windowHandle, hv_StringI.TupleSelect(hv_Index));
                    }
                }
                HOperatorSet.SetRgb(windowHandle, hv_Red, hv_Green, hv_Blue);
                HOperatorSet.SetPart(windowHandle, hv_RowI1Part, hv_ColumnI1Part, hv_RowI2Part,
                    hv_ColumnI2Part);
            }
            catch (Exception ex) { }
        }


        internal static void ShowRegion(ChoiceTech.Halcon.Control.HWindow_Final2 hWindow_Final1, RegionType regionType, HTuple height, HTuple width, ref List<ROI> rOIs)
        {
            switch (regionType)
            {
                case RegionType.整幅图像:
                    break;
                case RegionType.矩形:
                    hWindow_Final1.viewWindow.genRect1(height * 0.375, width * 0.375, height * 0.625, width * 0.625, ref rOIs);
                    break;
                case RegionType.仿射矩形:
                    hWindow_Final1.viewWindow.genRect2(height / 2, width / 2, 0, width * 0.125, height * 0.125, ref rOIs);
                    break;
                case RegionType.圆:
                    hWindow_Final1.viewWindow.genCircle(height / 2, width / 2, height / 8, ref rOIs);
                    break;
                //case RegionType.多点:
                //    HTuple row, col, row1, col1;
                //    HOperatorSet.GetPart(hWindow_Final1.HWindowHalconID, out row, out col, out row1, out col1);
                //    HalconLib.DispText(hWindow_Final1.HWindowHalconID, "请在图像窗口中连续左击绘制多点区域，右击绘制结束", 12, row + (row1 - row) / 30, col + (col1 - col) / 30, "blue", "false");
                //    rOIs.Clear();
                //    HObject ho_ContOut1;
                //    HTuple rows, cols, weights;
                //    HOperatorSet.DrawNurbs(out ho_ContOut1, hWindow_Final1.HWindowHalconID, "true", "true", "true", "true", 3, out rows, out cols, out weights);
                //    hWindow_Final1.viewWindow.genNurbs(rows, cols, ref rOIs);

                //    break;
                default:

                    break;
            }

        }

    }
}

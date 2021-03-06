﻿using Spire.License;
using Spire.Pdf;
using Spire.Pdf.Exporting.XPS.Schema;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aehyok.Spire.Pdf
{
    //文档
    //https://www.e-iceblue.cn/spirepdf/create-a-new-pdf-document.html
    class Program
    {
        static void Main(string[] args)
        {
            #region 设置Key
            var key = "JcDzkPGvDstH51n5AQCVLchN6Syd / f / T2NIQMipJsF6sB1LLhPz64WKU0qn0uCjkUr8qMEbUOHHPAK0UzNlLC2Ri + UQt1 + 4kEbc5Mrelr6 / d2X6af91nFCC9IP9P5a0kmFMMfFMw5dE9luSw5YRTt7EgQvrAGOQ0cIsCO5VGyPqH / VV5X7DPrqda2iAKLRBnPOGRuq2Lvs9TgRJ + ZROFwkckqX8NXhPDXaFST01Cpy6azavDyiASnkiGCsYy6poTnkRK / AlOHkZMOG0EDUQkAmxa00f + F03qzRPLWS7djki4gL8 / JmMBGALc + v6NlSuobR8XXj + OpJRkQiteP8XxsVe / 9sdpqmXnJUmv1XKNVggLyeIKOt4temmZc5yWIjkwTZp6Z66p8 / WE8ahkRA2HdGOAitOzOhCvBch + X + gEXlmnCcteryqe / tYa + QNoVFMvSuW6h + 2 + a4owhuSj0x3vO + BgY3YpoelZkc3mJl6DnGNdd6 / r4HE9N1fTGPT2gXY3Li1 / G / NwB +/ EUDCb8DUrTgysCVs3FM + Gnufbql0o3cswikfjF26Rdp3QtosHosmCAEUxiqBv8N8AwyCKTVT4rYUn3oRQZTBAaXtr / uZd2mNC5fZqslWqJFml5V1cNSf6K8x8F3wcO2lfytsWKzB4BkUPRbJZG / dAyUccrFKlLceVktmF0bajPIp5aN02NZfuXD9wfyf9g2ic / 0l3VACaWS7QFVNf7ZDxmmfssagM0fjpk0eBY3eFt8 / I8DhIo3739JkxDcgfNQ0nd7jrvX1iGCQUwaCyUfZllphsmZN4SkbWIoQX / UXW3swyXnVDKhp / Cl27RvXVHP5n3iQgya8Tun0dvnadCAn / awKvyOu5OyJ / j77hCFWFHpWPpGsZxQMYtODrTnHkz2 / 6rQNc9lBEnBkipieEMvEiSyk + jENeLI0IlmZpCyCrjTpJPHfRZJkZbIAaYRhhYoyl5o / xmldJaTe1UdBCz3N0Z0dpzY2amdcA + sOUjkogdD2zbwUiLwkzf7rQDQSYEUI / 0uVgz7PIQGuCOlqAtdUwCpRs + ktwkHWr0SoAgZAlu3N9YVIB + rQlPfudP2wGUYpUfT3ZwRezrBSjLUCs3ou2mFrhKkfwaATf90gAnQLhJQ6InPREzqjGj1ZB + 3q5ymjA0svrjM2Fw3EFALufHGBEChdHxL / ztiy7NcVX5f5V4XAoUybbhWMVcKUuZJgRIFK8JfawPPI + Z7jz94pPxDAeCBVg + 7oBKWGjkLB0 + RIYPIOKAMiuo7pCMNASd5etkSPmo7L / J1pxnCxado6emKBgcDqqAN + PpnTwu9pmATjrPGL3plP4BnNLmT36jlNPWVMd4NvvksGM4N49EwCzlbGx57FObBDSH5VJYszapDc217jpuGHKz4XUP6m5jfxL2IZfdrRrQJxepg ==";
            LicenseProvider.SetLicenseKey(key);
            #endregion
            //Create_01();
            Create_02();
        }

        public static void Create_01()
        {
            //1、创建一个PDF 的Document
            PdfDocument doc = new PdfDocument();
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            //2、创建一个margin为上面定义的PDF的Page页
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

            //3、插入一个背景图片
            //System.Drawing.Image img = System.Drawing.Image.FromFile(@"1.png");
            //page.BackgroundImage = img;

            //4、添加水印
            PdfTilingBrush brush
                = new PdfTilingBrush(new SizeF(page.Canvas.ClientSize.Width / 2, page.Canvas.ClientSize.Height / 3));
            brush.Graphics.SetTransparency(0.3f);
            brush.Graphics.Save();
            brush.Graphics.TranslateTransform(brush.Size.Width / 2, brush.Size.Height / 2);
            brush.Graphics.RotateTransform(-45);
            brush.Graphics.DrawString("www.cnblogs.com/aehyok",
                new PdfFont(PdfFontFamily.Helvetica, 24), PdfBrushes.Violet, 0, 0,
                new PdfStringFormat(PdfTextAlignment.Center));
            brush.Graphics.Restore();
            brush.Graphics.SetTransparency(1);
            page.Canvas.DrawRectangle(brush, new RectangleF(new PointF(0, 0), page.Canvas.ClientSize));

            float y = 10;
            //5、设置标题
            PdfBrush brush1 = PdfBrushes.Black;
            //PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f, FontStyle.Bold));

            var fontUrl = "C:/WINDOWS/Fonts/AdobeSongStd-Light.otf";
            PdfTrueTypeFont font1 = new PdfTrueTypeFont(new Font("Arial", 16f), true);
            PdfStringFormat format1 = new PdfStringFormat(PdfTextAlignment.Center);
            
            page.Canvas.DrawString("Country dsfa列表", font1, brush1, page.Canvas.ClientSize.Width / 2, y, format1);
            y = y + font1.MeasureString("Country列表", format1).Height;
            y = y + 5;

            ////6、定义Table元数据
            String[] data = {
                "Name;Capital;Continent;Area;Population",
                "Argentina;Buenos Aires;South America;2777815;32300003",
                "Bolivia;La Paz;South America;1098575;7300000",
                "Brazil;Brasilia;South America;8511196;150400000",
                "Canada;Ottawa;North America;9976147;26500000",
                };
            String[][] dataSource
                = new String[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                dataSource[i] = data[i].Split(';');
            }
            ///7、画Table绑定数据
            PdfTable table = new PdfTable();
            table.Style.CellPadding = 2;
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.ShowHeader = true;
            table.DataSource = dataSource;   ///直接绑定数据源
            PdfLayoutResult result = table.Draw(page, new PointF(0, y));
            y = y + result.Bounds.Height + 5;
            PdfBrush brush2 = PdfBrushes.Gray;
            PdfTrueTypeFont font2 = new PdfTrueTypeFont(new Font("Arial", 9f));
            page.Canvas.DrawString(String.Format("* {0} countries in the list.", data.Length - 1), font2, brush2, 5, y);

            //8、保存文件
            doc.SaveToFile("SimpleTable.pdf");
            doc.Close();
            ///9、打开刚刚制作的文件
            System.Diagnostics.Process.Start("SimpleTable.pdf");
        }


        public static void Create_02()
        {
            //创建一个PDF文档
            PdfDocument doc = new PdfDocument();

            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            //margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            //margin.Bottom = margin.Top;
            //margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            //margin.Right = margin.Left;

            //添加新页
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);


            var fontUrl = @"C:/WINDOWS/Fonts/AdobeSongStd-Light.otf";
            //实例化一个TrueType font对象
            PdfTrueTypeFont font = new PdfTrueTypeFont(fontUrl, 12, PdfFontStyle.Regular);
            PdfTrueTypeFont fontUnderline = new PdfTrueTypeFont(fontUrl, 12, PdfFontStyle.Underline);

            PdfStringFormat pdfStringFormat = new PdfStringFormat();
            pdfStringFormat.ParagraphIndent = 25;

            var SubText = @"中国根据《中华人民共和国海关法》第九十三条、《中华人民共和国海关行政处罚,施条例》第六十条的规定，"
                                        + "当事人逾期不履行处罚决定又不申请复议或者向人民法院提起诉讼的，海关可以将扣留的货物、物品、"
                                        +"运输工具依法变价抵缴，"
                                        + "或者以当事人提供的担保抵缴；也可以申请人民法院强制执行。";

            float y = 10;
            var index = 0;
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Justify);
            for (var i = 0; i < 4; i++)
            {
                if (index == 0)
                {
                    page.Canvas.DrawString(SubText.Substring(0, 36), font, PdfBrushes.Black, 36, y, format);
                }
                else
                {
                    if(i<3)
                    {
                        page.Canvas.DrawString(SubText.Substring(index, 38), font, PdfBrushes.Black, 10, y, format);
                        var size11 = font.MeasureString(SubText.Substring(index, 38), format);
                    }
                    else
                    {
                        page.Canvas.DrawString(SubText.Substring(index, SubText.Length-index), font, PdfBrushes.Black, 10, y, format);
                    }
                    
                }

                y = y + font.Height + 1 + i;

                index = index + 38;
            }
            //456 = 38*12；
            var currentWidth = 0.0;
            var key1 = "英雄名称雄名称英雄名称英雄名称英雄名称，";
            var size = font.MeasureString(key1, format);
            page.Canvas.DrawString(key1, font, PdfBrushes.Black, 36, y);
            currentWidth = size.Width;
            var value1 = "宫本武藏宫本武藏宫本武藏宫本武藏宫本武藏宫本武藏宫本武藏宫本武藏宫本武藏";
            var x = 36+size.Width;

            var width = size.Width;
            size = fontUnderline.MeasureString(value1, format);
            width = width + size.Width;
            int temp = 0;
            if(width > 456)
            {
                var tempWidth = 456 - currentWidth;
                temp=(int)tempWidth / 12;
                page.Canvas.DrawString(value1.Substring(0, temp-1), fontUnderline, PdfBrushes.Black, x, y);
            }
            page.Canvas.DrawString(value1.Substring(temp, value1.Length-temp), fontUnderline, PdfBrushes.Black, 36, y + fontUnderline.Height + 1 + 1);

            //保存文档
            doc.SaveToFile("SimpleTable.pdf");
            System.Diagnostics.Process.Start("SimpleTable.pdf");
        }

        public static void Create_03()
        {
                        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="currentWidth"></param>
        /// <param name="TotalWidth"></param>
        /// <param name="coordinateX"></param>
        /// <param name="coordinateY"></param>
        public void DrawContent(string content,float currentWidth,float TotalWidth,float coordinateX,float coordinateY)
        {

        }
    }
}

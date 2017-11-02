using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aehyok.SpirePdf
{
    public class SpireDoc
    {
        public static void Create_03()
        {
            //create a new word document and add a section and paragraph to it.
            Document doc = new Document();
            Section sec = doc.AddSection();
            Paragraph para = sec.AddParagraph();

            var SubText = @"中国根据《中华人民共和国海关法》第九十三条、《中华人民共和国海关行政处罚,施条例》第六十条的规定，"
                            + "当事人逾期不履行处罚决定又不申请复议或者向人民法院提起诉讼的，海关可以将扣留的货物、物品、"
                            + "运输工具依法变价抵缴，"
                            + "或者以当事人提供的担保抵缴；也可以申请人民法院强制执行。";

            //Add the text strings to the paragraph and set the style
            para.AppendHTML("Add a new paragraph to the word and set the spacing" + SubText);
            //para.ApplyStyle(BuiltinStyle.Heading1);

            //set the spacing before and after
            // para.Format.BeforeAutoSpacing = false;
            para.Format.BeforeSpacing = 20;
            //para.Format.AfterAutoSpacing = false;
            para.Format.AfterSpacing = 20;

            //save the document to file
            doc.SaveToFile("Result1.pdf", Spire.Doc.FileFormat.PDF);
        }
    }
}

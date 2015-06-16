using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using Novacode;

namespace _05.WordDocumentGenerator
{
    class WordDocumentGenerator
    {
        static void Main(string[] args)
        {
            DocX doc = DocX.Create(@"../../Result.docx");

            var boldFormat = new Formatting { FontFamily = new FontFamily("Calibri"), Size = 12D, Bold = true };
            var boldUFormat = new Formatting { FontFamily = new FontFamily("Calibri"), Size = 12D, Bold = true, UnderlineColor = Color.Black };
            var boldFFormat = new Formatting { FontFamily = new FontFamily("Calibri"), Size = 20D, Bold = true };

            string temp = "role playing game";

            using (StreamReader streamReader = new StreamReader(@"../../text.txt"))
            {
                Paragraph title = doc.InsertParagraph().Append(streamReader.ReadLine().Trim()).FontSize(35).Font(new FontFamily("Calibri"));
                title.Alignment = Alignment.center;
                title.Bold();

                Novacode.Image image = doc.AddImage(@"../../rpg-game.png");
                Picture picture = image.CreatePicture();
                picture.Height = 231;
                picture.Width = 600;

                Paragraph p1 = doc.InsertParagraph();

                p1.AppendPicture(picture);
                p1.AppendLine(streamReader.ReadLine()).FontSize(12).Font(new FontFamily("Calibri"));
                p1.AppendLine(streamReader.ReadLine()).FontSize(12).Font(new FontFamily("Calibri"));
                p1.AppendLine(streamReader.ReadLine()).FontSize(12).Font(new FontFamily("Calibri"));
                p1.ReplaceText(temp, temp, false, RegexOptions.None, boldFormat);
                temp = "grand prize";
                p1.ReplaceText(temp, temp, false, RegexOptions.None, boldUFormat);
                var list = doc.AddList(listType: ListItemType.Bulleted);

                doc.AddListItem(list, streamReader.ReadLine());
                doc.AddListItem(list, streamReader.ReadLine());
                doc.AddListItem(list, streamReader.ReadLine());
                doc.InsertList(list);

                Paragraph p2 = doc.InsertParagraph();
                p2.AppendLine(streamReader.ReadLine()).FontSize(12).Font(new FontFamily("Calibri"));

                Table table = doc.AddTable(4, 3);
                table.Design = TableDesign.LightListAccent1;
                table.Alignment = Alignment.center;
                string[] arr = Regex.Split(streamReader.ReadLine(), @"\s+");
                table.Rows[0].Cells[0].Paragraphs[0].Append(arr[0]).FontSize(12).Font(new FontFamily("Calibri"));
                table.Rows[0].Cells[1].Paragraphs[0].Append(arr[1]).FontSize(12).Font(new FontFamily("Calibri"));
                table.Rows[0].Cells[2].Paragraphs[0].Append(arr[2]).FontSize(12).Font(new FontFamily("Calibri"));
                for (int i = 1; i < 4; i++)
                {
                    arr = Regex.Split(streamReader.ReadLine(), @"\s+");
                    for (int j = 0; j < 3; j++)
                    {
                        table.Rows[i].Cells[j].Paragraphs[0].Append(arr[j]).FontSize(12).Font(new FontFamily("Calibri"));
                    }
                }

                doc.InsertTable(table);

                Paragraph p3 = doc.InsertParagraph();
                p3.AppendLine(streamReader.ReadLine()).FontSize(12).Font(new FontFamily("Calibri"));

                Paragraph footer1 = doc.InsertParagraph().Append(streamReader.ReadLine().Trim()).FontSize(20).Font(new FontFamily("Calibri"));
                footer1.Alignment = Alignment.center;
                temp = "SPECTACULAR";
                footer1.ReplaceText(temp, temp, false, RegexOptions.None, boldFFormat);

                Paragraph footer2 = doc.InsertParagraph().Append(streamReader.ReadLine().Trim()).FontSize(35).Font(new FontFamily("Calibri"));
                footer2.Alignment = Alignment.center;
                footer2.Bold();
                footer2.Color(Color.CornflowerBlue);
                footer2.UnderlineColor(Color.CornflowerBlue);
            }

            doc.SaveAs(@"..\..\Result.docx");
        }
    }
}

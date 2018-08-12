using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateEngine.Docx.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Delete("OutputDocument.docx");
            File.Copy("InputTemplate.docx", "OutputDocument.docx");

            var valuesToFill = new Content(
                new TableContent("Team Members Table")
                    .AddRow(
                        new FieldContent("Name", "Eric"),
                        new FieldContent("Role", "Program Manager"))
                    .AddRow(
                        new FieldContent("Name", "Bob"),
                        new FieldContent("Role", "Developer")),

                new FieldContent("Count", "2"),

                new TableContent("Reborn Characters Info")
                    .AddRow(
                        new FieldContent("Name", "Tsunayoshi Sawada"),
                        new FieldContent("Title", "Vongola Decimo"),
                        new FieldContent("Attribute", "Sky"),
                        new FieldContent("Main Weapon", "Gloves + HDWM"))
                    .AddRow(
                        new FieldContent("Name", "Hayato Gokudera"),
                        new FieldContent("Title", "10th Vongola Storm Guardian"),
                        new FieldContent("Attribute", "Storm"),
                        new FieldContent("Main Weapon", "Dynamite"))
                    .AddRow(
                        new FieldContent("Name", "Reborn"),
                        new FieldContent("Title", "Sun Arcobaleno"),
                        new FieldContent("Attribute", "Sun"),
                        new FieldContent("Main Weapon", "Leon"))
                    .AddRow(
                        new FieldContent("Name", "Superbi Squalo"),
                        new FieldContent("Title", "Varia Rain Guardian"),
                        new FieldContent("Attribute", "Rain"),
                        new FieldContent("Main Weapon", "Sword"))
                    .AddRow(
                        new FieldContent("Name", "Giotto"),
                        new FieldContent("Title", "Vongola Primo"),
                        new FieldContent("Attribute", "Sky"),
                        new FieldContent("Main Weapon", "Gloves + HDWM"))
                    .AddRow(
                        new FieldContent("Name", "G."),
                        new FieldContent("Title", "1st Generation Vongola Storm Guardian"),
                        new FieldContent("Attribute", "Storm"),
                        new FieldContent("Main Weapon", "Archery")));

            using (var outputDocument = new TemplateProcessor("OutputDocument.docx")
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }
        }
    }
}

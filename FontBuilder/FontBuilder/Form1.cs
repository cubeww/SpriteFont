using StbTrueTypeSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace FontBuilder
{
    public partial class Form1 : Form
    {
        string ttfFile;
        Bitmap atlasBitmap;
        string glyphs;
        public Form1()
        {
            InitializeComponent();
        }

        private void selectTTFButton_Click(object sender, EventArgs e)
        {
            if (openTTFDialog.ShowDialog() == DialogResult.OK)
            {
                ttfFile = openTTFDialog.FileName;
                fileNameLabel.Text = ttfFile;

                buildButton.Enabled = true;
            }
        }

        private unsafe void buildButton_Click(object sender, EventArgs e)
        {
            var ttf = File.ReadAllBytes(ttfFile);

            // Get font info
            StbTrueType.stbtt_fontinfo fontInfo = new StbTrueType.stbtt_fontinfo();
            fixed (byte* ttfPtr = ttf)
            {
                if (StbTrueType.stbtt_InitFont(fontInfo, ttfPtr, 0) == 0)
                {
                    throw new Exception("Failed to init font.");
                }
            }

            // Scale font size
            var size = int.Parse(SizeBox.Text);
            float scaleFactor = StbTrueType.stbtt_ScaleForPixelHeight(fontInfo, size);

            int ascent, descent, lineGap;
            StbTrueType.stbtt_GetFontVMetrics(fontInfo, &ascent, &descent, &lineGap);

            // Create font range
            var range = new FontRange();
            if (chkLatinBasic.Checked) range.AddLatinBasic();
            if (chkLatinExtended.Checked) range.AddLatinExtended();

            if (chkChineseCommon.Checked) range.AddChineseCommon();
            if (chkChineseFull.Checked) range.AddChineseFull();

            if (chkJapaneseCommon.Checked) range.AddJapaneseCommon();
            if (chkJapaneseFull.Checked) range.AddJapaneseFull();

            range.AddString(txtCustomRange.Text);

            // Get width
            float maxXadvance = 0;
            foreach (var i in range.Range)
            {
                int xadvance, left;
                StbTrueType.stbtt_GetCodepointHMetrics(fontInfo, i, &xadvance, &left);
                maxXadvance = Math.Max(maxXadvance, xadvance);
            }
            maxXadvance *= scaleFactor;

            int bitmapWidth = (int)Math.Ceiling(Math.Sqrt(Math.Ceiling(maxXadvance) * size * range.Range.Count));
            int bitmapHeight = bitmapWidth;

            var pixels = new byte[bitmapWidth * bitmapHeight];

            StbTrueType.stbtt_pack_context pc = new StbTrueType.stbtt_pack_context();

            StringWriter sw = new StringWriter();
            sw.WriteLine(size);

            // Get glyphs
            fixed (byte* ttfPtr = ttf)
            fixed (byte* pixelsPtr = pixels)
            {
                // Begin pack
                StbTrueType.stbtt_PackBegin(pc, pixelsPtr, bitmapWidth,
                    bitmapHeight, bitmapWidth, 1, null);

                sw.WriteLine(range.Range.Count);

                foreach (var i in range.Range)
                {
                    var packedChar = new StbTrueType.stbtt_packedchar();
                    StbTrueType.stbtt_PackFontRange(pc, ttfPtr, 0, size, i, 1, &packedChar);
                    
                    var yOff = packedChar.yoff;
                    yOff += ascent * scaleFactor;

                    sw.WriteLine(((char)i).ToString());
                    sw.WriteLine(packedChar.x0);
                    sw.WriteLine(packedChar.y0);
                    sw.WriteLine(packedChar.x1 - packedChar.x0);
                    sw.WriteLine(packedChar.y1 - packedChar.y0);
                    sw.WriteLine((int)packedChar.xoff);
                    sw.WriteLine((int)Math.Round(yOff));
                    sw.WriteLine((int)Math.Round(packedChar.xadvance));
                }

                //// Create packed char array
                //var packedChars = new StbTrueType.stbtt_packedchar[end - start + 1];
                //for (var i = 0; i < packedChars.Length; ++i)
                //{
                //    packedChars[i] = new StbTrueType.stbtt_packedchar();
                //}

                //// Pack range to array
                //fixed (StbTrueType.stbtt_packedchar* cdPtr = packedChars)
                //{
                //    StbTrueType.stbtt_PackFontRange(pc, ttfPtr, 0, size, start, end - start + 1, cdPtr);
                //}
                

                // Create glyphs from packed chars
                //for (var i = 0; i < packedChars.Length; ++i)
                //{
                //    var yOff = packedChars[i].yoff;
                //    yOff += ascent * scaleFactor;

                //    sw.WriteLine(((char)(i + start)).ToString());
                //    sw.WriteLine(packedChars[i].x0);
                //    sw.WriteLine(packedChars[i].y0);
                //    sw.WriteLine(packedChars[i].x1 - packedChars[i].x0);
                //    sw.WriteLine(packedChars[i].y1 - packedChars[i].y0);
                //    sw.WriteLine((int)packedChars[i].xoff);
                //    sw.WriteLine((int)Math.Round(yOff));
                //    sw.WriteLine((int)Math.Round(packedChars[i].xadvance));
                //}
            }

            // Create font texture atlas
            var rgbaData = new byte[bitmapWidth * bitmapHeight * 4];
            for (int i = 0; i < pixels.Length; i++)
            {
                rgbaData[i * 4 + 0] = 255;
                rgbaData[i * 4 + 1] = 255;
                rgbaData[i * 4 + 2] = 255;
                rgbaData[i * 4 + 3] = pixels[i];
            }

            var bitmap = new Bitmap(bitmapWidth, bitmapHeight, PixelFormat.Format32bppArgb);
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            Marshal.Copy(rgbaData, 0, bitmapData.Scan0, rgbaData.Length);
            bitmap.UnlockBits(bitmapData);

            atlasBitmap = bitmap;
            atlasPicBox.Image = atlasBitmap;

            glyphs = sw.ToString();
            glyphsTextBox.Text = glyphs;

            outputPanel.Enabled = true;
        }

        private void saveTextureButton_Click(object sender, EventArgs e)
        {
            if (saveTextureDialog.ShowDialog() == DialogResult.OK)
            {
                atlasBitmap.Save(saveTextureDialog.FileName);
            }
        }

        private void saveGlyphsButton_Click(object sender, EventArgs e)
        {
            if (saveGlyphsDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveGlyphsDialog.FileName, glyphs);
            }
        }
    }

}

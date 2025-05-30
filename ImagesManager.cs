using DSharpPlus.CommandsNext;
using RunewayBot.other;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunewayBot
{
    public class ImagesManager
    {
        int crop = 3;

        public void ImageStuff(ulong id, string path, string[] imagePaths, int nImages, string what = "")
        {
            var userRune = new RuneSystem(0, id, 69);



            if (nImages == 0)
            {
                nImages = 1;
                imagePaths[0] = "01";
            
            }



            string outputPath = path + id + ".png";

            if (System.IO.File.Exists(outputPath))
            {
                System.IO.File.Delete(outputPath);
            }
            Bitmap[] images = new Bitmap[nImages];

            int totalWidth = 0;
            int maxHeight = 0;

          

            switch (what)
            {
                case "sigillo":

                    int maxRiga = 0;
                    nImages = userRune.data[64];
                    Bitmap[] images2 = new Bitmap[nImages];


                    switch (userRune.data[64])
                    {

                        case 2:
                            maxRiga = 2;
                            break;
                        case 3:
                        case 4:
                            maxRiga = 2;
                            break;
                        case 5:
                        case 6:
                            maxRiga = 3;
                            break;
                        case 7:
                        case 8:
                            maxRiga = 4;
                            break;
                    }




                    for (int i = 0; i < nImages; i++)
                    {


                        images2[i] = new Bitmap(path + imagePaths[i] + ".png");


                        if (i < maxRiga)
                            totalWidth += images2[i].Width / crop;


                    }


                    if (maxRiga < nImages)
                    {
                        maxHeight += images2[0].Height / crop * 2;


                    }
                    else
                    {
                        maxHeight += images2[0].Height / crop;

                    }

                    using (var mergedImage = new Bitmap(totalWidth, maxHeight))
                    {
                        using (var g = Graphics.FromImage(mergedImage))
                        {
                            int offsetX = 0;
                            int offsetY = 0;
                            int n = 0;
                            foreach (var img in images2)
                            {
                                g.DrawImage(img, offsetX, offsetY);
                                offsetX += img.Width / crop;
                                n++;
                                if (n == maxRiga)
                                {
                                    offsetY += img.Height / crop;
                                    offsetX = 0;
                                    n = 0;
                                }
                            }
                        }
                        mergedImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                    }




                    break;
                case "parallelo":

                    int maxRigap = 0;
                    nImages = userRune.data[71];
                    Bitmap[] images2p = new Bitmap[nImages];


                    switch (userRune.data[71])
                    {

                        case 2:
                            maxRigap = 2;
                            break;
                        case 3:
                        case 4:
                            maxRigap = 2;
                            break;
                        case 5:
                        case 6:
                            maxRigap = 3;
                            break;
                        case 7:
                        case 8:
                            maxRigap = 4;
                            break;
                    }




                    for (int i = 0; i < nImages; i++)
                    {


                        images2p[i] = new Bitmap(path + imagePaths[i] + ".png");


                        if (i < maxRigap)
                            totalWidth += images2p[i].Width / crop;


                    }

                    if (maxRigap < nImages)
                    {
                        maxHeight += images2p[0].Height / crop * 2;


                    }
                    else
                    {
                        maxHeight += images2p[0].Height / crop;

                    }

                    using (var mergedImage = new Bitmap(totalWidth, maxHeight))
                    {
                        using (var g = Graphics.FromImage(mergedImage))
                        {
                            int offsetX = 0;
                            int offsetY = 0;
                            int n = 0;
                            foreach (var img in images2p)
                            {
                                g.DrawImage(img, offsetX, offsetY);
                                offsetX += img.Width / crop;
                                n++;
                                if (n == maxRigap)
                                {
                                    offsetY += img.Height / crop;
                                    offsetX = 0;
                                    n = 0;
                                }
                            }
                        }
                        mergedImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                    }




                    break;

                case "parallelo2":

                    int maxRigap2 = 0;
                    nImages = userRune.data[81];
                    Bitmap[] images2p2 = new Bitmap[nImages];


                    switch (userRune.data[81])
                    {

                        case 2:
                            maxRigap2 = 2;
                            break;
                        case 3:
                        case 4:
                            maxRigap2 = 2;
                            break;
                        case 5:
                        case 6:
                            maxRigap2 = 3;
                            break;
                        case 7:
                        case 8:
                            maxRigap2 = 4;
                            break;
                    }




                    for (int i = 0; i < nImages; i++)
                    {


                        images2p2[i] = new Bitmap(path + imagePaths[i] + ".png");


                        if (i < maxRigap2)
                            totalWidth += images2p2[i].Width / crop;


                    }

                    if (maxRigap2 < nImages)
                    {
                        maxHeight += images2p2[0].Height / crop * 2;


                    }
                    else
                    {
                        maxHeight += images2p2[0].Height / crop;

                    }

                    using (var mergedImage = new Bitmap(totalWidth, maxHeight))
                    {
                        using (var g = Graphics.FromImage(mergedImage))
                        {
                            int offsetX = 0;
                            int offsetY = 0;
                            int n = 0;
                            foreach (var img in images2p2)
                            {
                                g.DrawImage(img, offsetX, offsetY);
                                offsetX += img.Width / crop;
                                n++;
                                if (n == maxRigap2)
                                {
                                    offsetY += img.Height / crop;
                                    offsetX = 0;
                                    n = 0;
                                }
                            }
                        }
                        mergedImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                    }




                    break;

                case "sigilloFato":

                    int maxRiga2 = 0;
                    nImages = userRune.data[65];
                    Bitmap[] images3 = new Bitmap[nImages];


                    switch (userRune.data[65])
                    {
                        case 4:
                            maxRiga2 = 2;
                            break;
                        case 5:
                        case 6:
                            maxRiga2 = 3;
                            break;
                        case 7:
                        case 8:
                            maxRiga2 = 4;
                            break;
                    }




                    for (int i = 0; i < nImages; i++)
                    {


                        images3[i] = new Bitmap(path + imagePaths[i] + ".png");


                        if (i < maxRiga2)
                            totalWidth += images3[i].Width / crop;


                    }


                    if (maxRiga2 < nImages)
                    {
                        maxHeight += images3[0].Height / crop * 2;


                    }
                    else
                    {
                        maxHeight += images3[0].Height / crop;

                    }

                    using (var mergedImage = new Bitmap(totalWidth, maxHeight))
                    {
                        using (var g = Graphics.FromImage(mergedImage))
                        {
                            int offsetX = 0;
                            int offsetY = 0;
                            int n = 0;
                            foreach (var img in images3)
                            {
                                g.DrawImage(img, offsetX, offsetY);
                                offsetX += img.Width / crop;
                                n++;
                                if (n == maxRiga2)
                                {
                                    offsetY += img.Height / crop;
                                    offsetX = 0;
                                    n = 0;
                                }
                            }
                        }
                        mergedImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                    }




                    break;

                default:

                    for (int i = 0; i < nImages; i++)
                    {
                        images[i] = new Bitmap(path + imagePaths[i] + ".png");
                        if (i < 5)
                            totalWidth += images[i].Width / crop;

                    }
                    for (int q = nImages; q != 0;)
                    {
                        maxHeight += images[0].Height / crop;
                        if (q < 5)
                            q = 0;
                        else
                            q -= 5;
                    }

                    using (var mergedImage = new Bitmap(totalWidth, maxHeight))
                    {
                        using (var g = Graphics.FromImage(mergedImage))
                        {
                            int offsetX = 0;
                            int offsetY = 0;
                            int n = 0;

                            foreach (var img in images)
                            {
                                g.DrawImage(img, offsetX, offsetY);
                                offsetX += img.Width / crop;
                                n++;
                                if (n == 5)
                                {
                                    offsetY += img.Height / crop;
                                    offsetX = 0;
                                    n = 0;
                                }
                            }
                        }
                        mergedImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
                    }

                    break;
            }
        }
    }
}
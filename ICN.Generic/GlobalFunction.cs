using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace ICN.Generic
{
    public class GlobalFunction
    {
        public static string Terbilang(int pTotal)
        {
            String sTotal, sAngka, sSatuan = "", sPos = "", sRes = "", sAngkaB;
            int iLen, iI, iPos, iSat = 0;
            double dRes;
            sTotal = Convert.ToString(pTotal);
            iLen = sTotal.Length;
            iI = iLen - 1;
            while (iI >= 0)
            {
                sAngka = sTotal.Substring(iI, 1);
                if (iI == 0) sAngkaB = "";
                else sAngkaB = sTotal.Substring(iI - 1, 1);

                iPos = (iLen - iI - 1) % 3;
                dRes = (iLen - iI) / 3;
                iSat = Convert.ToInt32(Math.Floor(dRes));
                if (iSat == 0) sSatuan = "";
                else if (iSat == 1) sSatuan = "Ribu ";
                else if (iSat == 2) sSatuan = "Juta ";
                else if (iSat == 3) sSatuan = "Milyar ";
                else if (iSat == 4) sSatuan = "Trilyun ";
                if ((sAngkaB == "1") && (iPos == 0) && (Convert.ToInt32(sAngka) > 0)) sPos = "Belas ";
                else
                {
                    if (iPos == 0) sPos = "";
                    else if (iPos == 1) sPos = "Puluh ";
                    else if (iPos == 2) sPos = "Ratus ";
                }
                if ((iPos == 0) && (iSat == 1) && (sAngka == "1") && (iLen == 4)) sSatuan = sSatuan.ToLower();
                if (iPos == 0)
                {
                    if (sAngka == "0")
                    {
                        if ((iI - 2) >= 0)
                        {
                            if (Convert.ToInt32(sTotal.Substring(iI - 2, 3)) > 0) sRes = sSatuan + sRes;
                        }
                        else if ((iI - 1) >= 0)
                        {
                            if (Convert.ToInt32(sTotal.Substring(iI - 1, 2)) > 0) sRes = sSatuan + sRes;
                        }
                        else
                        {
                            sRes = sSatuan + sRes;
                        }
                        //if (iSat == 2) sRes = sSatuan + sRes;
                    }
                    else sRes = sSatuan + sRes;
                }
                if (Convert.ToInt32(sAngka) == 1)
                {
                    if ((iPos > 0) || ((iSat == 1) && (iPos == 0) && (iLen == 4)) || ((iPos != 2) && (sAngkaB == "1"))) sRes = " Se" + sPos.ToLower() + sRes;
                    else sRes = " Satu " + sPos + sRes;
                }
                else if (Convert.ToInt32(sAngka) == 2) sRes = " Dua " + sPos + sRes;
                else if (Convert.ToInt32(sAngka) == 3) sRes = " Tiga " + sPos + sRes;
                else if (Convert.ToInt32(sAngka) == 4) sRes = " Empat " + sPos + sRes;
                else if (Convert.ToInt32(sAngka) == 5) sRes = " Lima " + sPos + sRes;
                else if (Convert.ToInt32(sAngka) == 6) sRes = " Enam " + sPos + sRes;
                else if (Convert.ToInt32(sAngka) == 7) sRes = " Tujuh " + sPos + sRes;
                else if (Convert.ToInt32(sAngka) == 8) sRes = " Delapan " + sPos + sRes;
                else if (Convert.ToInt32(sAngka) == 9) sRes = " Sembilan " + sPos + sRes;
                if ((sAngkaB == "1") && (iPos == 0) && (Convert.ToInt32(sAngka) > 0))
                    iI = iI - 1;

                iI = iI - 1;
            }
            sRes = sRes + " Rupiah ";
            return sRes;
        }


        //public Base64ToImage(string base64String)
        //{
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
        //    return image;
        //}
    }
}

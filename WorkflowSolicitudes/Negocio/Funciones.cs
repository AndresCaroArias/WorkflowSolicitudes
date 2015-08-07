using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Negocio;
using WorkflowSolicitudes.Entidades;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using iTextSharp.text;
using System.IO;

namespace WorkflowSolicitudes.Negocio
{
    public class Funciones
    {

        public bool TieneAcceso(int intCodRol, string StrPrivilegio)
        {
            Boolean ExisteAcceso = false;

            NegPrivilegios NegTieneAcceso = new NegPrivilegios();
            List<Privilegios> LstAccesos = NegTieneAcceso.ObtenerPrivbyRol(intCodRol);

            foreach (Privilegios Accesos in LstAccesos)
            {
                if (Accesos.strNomPrivilegios.Equals(StrPrivilegio))
                {
                    ExisteAcceso = true;
                }
            }

            return ExisteAcceso;
        }

        public bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        public string EncriptarMD5(string strPassword)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(strPassword));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public string GetIpAddress()  // Get IP Address
        {
            string ip = "";
            IPHostEntry ipEntry = Dns.GetHostEntry(GetCompCode());
            IPAddress[] addr = ipEntry.AddressList;
            ip = addr[1].ToString();
            return ip;
        }

        public string GetCompCode()  // Get Computer Name
        {
            string strHostName = "";
            strHostName = Dns.GetHostName();
            return strHostName;
        }

        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }

        public string GetGeneradordePassword()
        {

            Random obj = new Random();
            string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = posibles.Length;
            char letra;
            int longitudnuevacadena = 10;

            string nuevacadena = "";

            for (int i = 0; i < longitudnuevacadena; i++)
            {
                letra = posibles[obj.Next(longitud)];
                nuevacadena += letra.ToString();
            }

            return nuevacadena;

        }

        private static void WriteTextToDocument(BaseFont bf, Rectangle tamPagina, PdfContentByte over, PdfGState gs, string texto)
        {
            over.SetGState(gs);
            over.SetRGBColorFill(220, 220, 220);
            over.SetTextRenderingMode(PdfContentByte.TEXT_RENDER_MODE_STROKE);
            over.SetFontAndSize(bf, 46);
            Single anchoDiag = (Single)Math.Sqrt(Math.Pow((tamPagina.Height - 120), 2) + Math.Pow((tamPagina.Width - 60), 2));
            Single porc = (Single)100 * (anchoDiag / bf.GetWidthPoint(texto, 46));
            over.SetHorizontalScaling(porc);

            double angPage = (-1) * Math.Atan((tamPagina.Height - 60) / (tamPagina.Width - 60));
            over.SetTextMatrix((float)Math.Cos(angPage), (float)Math.Sin(angPage), (float)((-1F) * Math.Sin(angPage)), (float)Math.Cos(angPage), 30F, (float)tamPagina.Height - 60);
            over.ShowText(texto);
        }

        public string ReadPdfFile(object Filename)
        {
            PdfReader reader2 = new PdfReader((string)Filename);
            string strText = string.Empty;

            for (int page = 1; page <= reader2.NumberOfPages; page++)
            {
                ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                PdfReader reader = new PdfReader((string)Filename);
                String s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                strText = strText + s;
                reader.Close();
            }
            return strText;
        }

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string Decrypt(string cipherText)
        {
            try
            {
                string EncryptionKey = "MAKV2SPBNI99212";
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;

            }
            catch (Exception ex)
            {
                return cipherText = "Error_Autorizacion";
                throw;
            }




        }

    }
}
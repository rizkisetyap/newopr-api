using System;
using System.IO;
using System.Web;
namespace My_OPR.Lib

{
    public class UploadLib
    {

        public static string UploadContent(Byte[] bytes, string fileName, string path, string ext)
        {

            try
            {

                var pht = Path.Combine(path, fileName + "." + ext);

                File.WriteAllBytes(pht, bytes);
                return pht;
            }
            catch (System.Exception)
            {

                throw;
            }

        }
        public static string SliderUpload(Byte[] bytes, string fileName, string path, string ext)
        {
            try
            {
                var filePath = path + "/" + fileName + "." + ext;
                File.WriteAllBytes(filePath, bytes);

                return filePath;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
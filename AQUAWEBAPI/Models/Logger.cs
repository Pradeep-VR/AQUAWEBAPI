using System;
using System.IO;
using System.Threading.Tasks;

namespace AQUAWEBAPI.Models
{
    public class Logger
    {
        //public async void writeLog(string strValue)
        //{

        //    //Logfile
        //    string path = System.Configuration.ConfigurationManager.AppSettings["logfilepath"];
        //    StreamWriter sw;
        //    if (!File.Exists(path))
        //    { sw = File.CreateText(path); }
        //    else
        //    { sw = File.AppendText(path); }

        //    await LogWrite(strValue, sw);

        //    sw.Flush();
        //    sw.Close();

        //}



        //private static async void LogWrite(string logMessage, StreamWriter w)
        //{
        //    w.WriteLine("{0}", logMessage);
        //    w.WriteLine("----------------------------------------");
        //}

        public async Task writeLog(string strValue)
        {
            // Logfile
            string path = System.Configuration.ConfigurationManager.AppSettings["logfilepath"];
            StreamWriter sw;
            if (!File.Exists(path))
            {
                using (sw = new StreamWriter(File.Create(path)))
                {
                    await LogWrite(strValue, sw);
                }
            }
            else
            {
                using (sw = new StreamWriter(path, true))
                {
                    await LogWrite(strValue, sw);
                }
            }
        }

        private static async Task LogWrite(string logMessage, StreamWriter w)
        {
            await w.WriteLineAsync(logMessage);
            await w.WriteLineAsync("----------------------------------------");
        }


        public void writeDataLog(string strValue)
        {
            try
            {
                //Logfile
                string path = System.Configuration.ConfigurationManager.AppSettings["datalogpath"];
                StreamWriter sw;
                if (!File.Exists(path))
                { sw = File.CreateText(path); }
                else
                { sw = File.AppendText(path); }

                DataLogWrite(strValue, sw);

                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {

            }
        }

        private static void DataLogWrite(string logMessage, StreamWriter w)
        {
            w.WriteLine("{0}", logMessage);
            w.WriteLine("----------------------------------------");
        }


        public async Task TempwriteLog(string strValue)
        {
            // Logfile
            string path = System.Configuration.ConfigurationManager.AppSettings["Templogpath"];
            StreamWriter sw;
            if (!File.Exists(path))
            {
                using (sw = new StreamWriter(File.Create(path)))
                {
                    await TempLogWrite(strValue, sw);
                }
            }
            else
            {
                using (sw = new StreamWriter(path, true))
                {
                    await TempLogWrite(strValue, sw);
                }
            }
        }

        private static async Task TempLogWrite(string logMessage, StreamWriter w)
        {
            await w.WriteLineAsync(logMessage);
            await w.WriteLineAsync("----------------------------------------");
        }
    }

}
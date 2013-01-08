using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WoWRegeneration.Data
{
    [Serializable()]
    public class Session
    {
        private const string SESSION_FILENAME = "session.xml";

        public bool SessionCompleted { get; set; }
        public string MFil { get; set; }
        public string WoWRepositoryName { get; set; }
        public string Locale { get; set; }
        public string OS { get; set; }
        public List<string> CompletedFiles { get; set; }

        public Session()
        {
            CompletedFiles = new List<string>();
            SessionCompleted = false;
        }

        public Session(string mfil, string locale, string os)
            : this()
        {
            this.MFil = mfil;
            this.Locale = locale;
            this.OS = os;
            Repositories.IWoWRepository rep = Repositories.RepositoriesManager.getRepositoryByMfil(mfil);
            if (rep == null)
                throw new Exception("Unknow mfil file");
            this.WoWRepositoryName = rep.getVersionName();
        }

        public static Session LoadSession()
        {
            string sessionPath = Program.ExecutionPath + SESSION_FILENAME;
            if (System.IO.File.Exists(sessionPath))
            {
                Session tmp = new Session();
                XmlSerializer xml = new XmlSerializer(typeof(Session));
                FileStream fs = new FileStream(sessionPath, FileMode.Open, FileAccess.Read);
                tmp = (Session)xml.Deserialize(fs);
                fs.Close();
                return tmp;
            }
            return null;
        }

        public void Destroy()
        {
            string sessionPath = Program.ExecutionPath + SESSION_FILENAME;
            if (System.IO.File.Exists(sessionPath))
                System.IO.File.Delete(sessionPath);
        }

        public bool SaveSession()
        {
            try
            {
                string sessionPath = Program.ExecutionPath + SESSION_FILENAME;
                XmlSerializer xml = new XmlSerializer(typeof(Session));
                FileStream fs = new FileStream(sessionPath, FileMode.Create, FileAccess.Write);
                xml.Serialize(fs, this);
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

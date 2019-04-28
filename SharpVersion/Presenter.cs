using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SharpVersion
{
    class Presenter
    {
        public Presenter(IView view)
        {
            _view = view;
            _view.SubmitForm += SubForm;
            _view.SubSoft += AddSoft;
            _view.test += tests;
            _view.Restore += Restore;
        }

        IView _view;
        bool result2 = false;

        public void tests(object sender, EventArgs e)
        {
            Azure a = new Azure("https://pp.userapi.com/c856136/v856136735/2fc05/eGPqLoK76m0.jpg", "https://pp.userapi.com/c855328/v855328735/30391/bn20Eb-MT0w.jpg");
            a.f();
        }

        public void Restore(object sender, object args)
        {
            Dictionary<string, string> dict = (Dictionary<string, string>)args;
            Dictionary<string, byte[]> full_hash = new Dictionary<string, byte[]>();
            foreach (KeyValuePair<string, string> i in dict)
            {
                full_hash.Add(i.Key, Crypt.Get_Hash(i.Value));
            }
            bool result1 = HardWebValid.Check_Hash(full_hash);
            if (result1)
                _view.Check(0);

            FFFf(dict);
        }

        public async Task<bool> FFFf(Dictionary<string, string> dict)
        {
            bool e = await SoftWebValid.Check_Face(dict["Image1"], dict["Image2"]);
            result2 = e;
            if (result2)
                _view.Check(1);
            return e;
        }

        public void SubForm(object sender, object arg)
        {
            Dictionary<string, string> dict = (Dictionary<string, string>)arg;
            Dictionary<string, byte[]> full_hash = new Dictionary<string, byte[]>();
            foreach (KeyValuePair<string, string> i in dict)
            {
                full_hash.Add(i.Key, Crypt.Get_Hash(i.Value));
            }
            HardWebValid.Put_Hash(full_hash);
        }

        public void AddSoft(object sender, object arg)
        {
            Dictionary<string, string> args = (Dictionary<string, string>)arg;
            byte[] full_hash = Crypt.Get_Hash(String.Format("{0}{1}{2}{3}{4}",
                                                       args["Surname"],
                                                       args["Name"],
                                                       args["Name_2"],
                                                       args["Birthday"],
                                                       args["Passport"],
                                                       args["Color"],
                                                       args["MumSurname"],
                                                       args["Image1"]));
            byte[] hash = Crypt.Get_Hash(String.Format("{0}{1}{2}{3}{4}",
                                                       args["Surname"],
                                                       args["Name"],
                                                       args["Name_2"],
                                                       args["Birthday"],
                                                       args["Passport"]));
            SoftWebValid.Put_Bio(hash, full_hash, File.ReadAllBytes(args["Image1"]));
            SoftWebValid.Get_Image(hash, full_hash);//Проверка на дешифровку
        }
    }
}

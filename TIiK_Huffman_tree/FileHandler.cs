using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIiK_Huffman_tree
{
    class FileHandler
    {
        public static void saveToFile(String jsonTable, String filename, String text, Dictionary<string, string> charactersCode)
        {
            FileStream fsTarget = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fsTarget.Write(Encoding.UTF8.GetBytes(jsonTable), 0, jsonTable.Length);
            fsTarget.Write(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 4);

            String buf = "";
            foreach(char c in text)
            {
                buf += charactersCode[c.ToString()];
                if(buf.Length<8)
                    continue;
                else
                {
                    String oneB = buf.Substring(0, 8);
                    buf = buf.Substring(8);
                    byte[] b = new byte[1] { 0x00 };
                    b[0] = Encoding.ASCII.GetBytes(oneB)[0];
                    fsTarget.Write(b, 0, 1);
                }
            }
            if(buf.Length>0)
            {
                int pad = 8 - buf.Length;
                for(int i=0; i<pad; i++)
                    buf += "0";
                byte[] b = new byte[1] { 0x00 };
                b[0] = Encoding.ASCII.GetBytes(buf)[0];
                fsTarget.Write(b, 0, 1);
            }
            fsTarget.Close();
        }

        public static void testFunc()
        {
            String jsonTable = "{\"a\":\"01\",\"b\":\"111\",\"c\":\"10\",\"d\":\"110\"}";
            string text = "abcdbdcbd";
            String filename = "C:\\Users\\modef\\Desktop\\output.bin";
            Dictionary<string, string> charactersCode = new Dictionary<string, string>();
            charactersCode.Add("a", "01");
            charactersCode.Add("b", "111");
            charactersCode.Add("c", "10");
            charactersCode.Add("d", "110");

            saveToFile(jsonTable, filename, text, charactersCode);
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIiK_Huffman_tree
{
    public static class FileHandler
    {
        public static void saveToFile(String jsonTable, String filename, String text, Dictionary<string, string> charactersCode)
        {
            FileStream fsTarget = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fsTarget.Write(Encoding.UTF8.GetBytes(jsonTable), 0, Encoding.UTF8.GetBytes(jsonTable).Length);
            fsTarget.Write(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 4);

            String buf = "";
            int abc = 0;
            foreach(char c in text)
            {
                buf += charactersCode[c.ToString()];
                do
                {
                    if (buf.Length < 8)
                        continue;
                    else
                    {
                        String oneB = buf.Substring(0, 8);
                        buf = buf.Substring(8);

                        var num = Convert.ToUInt32(oneB, 2);
                        var bytes = BitConverter.GetBytes(num);

                        int bLen = 1;
                        if (bytes[1] != 0x00)
                            bLen = 2;
                        if (bytes[2] != 0x00)
                            bLen = 3;
                        if (bytes[3] != 0x00)
                            bLen = 4;

                        fsTarget.Write(bytes, 0, bLen);
                    }
                } while (buf.Length >= 8);
            }
            if(buf.Length>0)
            {
                int pad = 8 - buf.Length;
                for(int i=0; i<pad; i++)
                    buf += "0";

                var num = Convert.ToUInt32(buf, 2);
                var bytes = BitConverter.GetBytes(num);

                int bLen = 1;
                if (bytes[1] != 0x00)
                    bLen = 2;
                if (bytes[2] != 0x00)
                    bLen = 3;
                if (bytes[3] != 0x00)
                    bLen = 4;

                fsTarget.Write(bytes, 0, bLen);
            }
            fsTarget.Close();
        }
        public static Dictionary<TValue,TKey> Reverse<TKey,TValue>(this IDictionary<TKey,TValue> src)
        {
            var dict = new Dictionary<TValue,TKey>();
            foreach (var ent in src)
            {
                if (!dict.ContainsKey(ent.Value))
                {
                    dict.Add(ent.Value, ent.Key);
                }
            }
            return dict;
        }

        public static void openFromFile(String inputFile)
        {
            if (!File.Exists(inputFile))
                return;
            FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read);

            String directoryName = Path.GetDirectoryName(inputFile);
            String filenameNew = Path.GetFileNameWithoutExtension(Path.GetFileName(inputFile)) + "_decoded.txt";

            FileStream fsOutput = new FileStream(directoryName + "\\" + filenameNew, FileMode.OpenOrCreate, FileAccess.ReadWrite);


            bool foundMagic = false;
            long magicPosition = 0;
            int b;
            do
            {
                b = fsInput.ReadByte();
                if (b == -1)
                    break;
                if (b == 0xFF)
                {
                    b = fsInput.ReadByte();
                    if (b == 0xFF)
                    {
                        b = fsInput.ReadByte();
                        if (b == 0xFF)
                        {
                            b = fsInput.ReadByte();
                            if (b == 0xFF)
                            {
                                foundMagic = true;
                                magicPosition = fsInput.Position;
                                magicPosition -= 4;
                                break;
                            }
                        }
                    }
                }
            } while ((int)b != -1);

            if (!foundMagic)
                return;

            fsInput.Seek(0, SeekOrigin.Begin);
            byte[] tempBuf = new byte[magicPosition];
            fsInput.Read(tempBuf, 0, (int)magicPosition);

            String jsonText = Encoding.UTF8.GetString(tempBuf);
            Dictionary<string, string> charactersCode = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText);

            var charactersCodeRev = charactersCode.ToDictionary(x => x.Value, x => x.Key);

            int shortestCode = 100;
            int longestCode = 0;
            foreach(var s in charactersCode)
            {
                if (shortestCode > s.Value.Length)
                    shortestCode = s.Value.Length;

                if (longestCode < s.Value.Length)
                    longestCode = s.Value.Length;
            }

            fsInput.Seek(magicPosition+4, SeekOrigin.Begin);

            String cBef = "";
            String cBefBef = "";

            String buffer = "";
            int c = 0;
            do
            {
                
                c = fsInput.ReadByte();

                if (c == -1)
                    break;

                String temp = Convert.ToString(c, 2);
                if(temp.Length<8)
                    while(temp.Length<8)
                        temp = temp.Insert(0, "0");

                buffer += temp;
                bool doAgain = false;
                do
                {
                    if((fsInput.Position>=fsInput.Length)&&(buffer.IndexOfAny(new char[] { '1' }) == -1))
                    {
                        break;
                    }
                    doAgain = false;
                    for (int i = shortestCode; i <= longestCode; i++)
                    {
                        if (buffer.Length < i)
                            break;
                        String act = buffer.Substring(0, i);
                        if (charactersCodeRev.ContainsKey(act))
                        {
                            buffer = buffer.Substring(i);
                            cBefBef = cBef;
                            cBef = charactersCodeRev[act];

                            if (cBefBef.Equals("9") && cBef.Equals("9"))
                            {
                                Int32 asdkjadkj = 0;
                            }
                                
                            fsOutput.Write(Encoding.UTF8.GetBytes(charactersCodeRev[act]), 0, Encoding.UTF8.GetBytes(charactersCodeRev[act]).Length);//ad break
                            doAgain = true;
                            break;
                        }
                    }
                } while (doAgain == true);

            } while ((int)c != -1);

            fsInput.Close();
            fsOutput.Close();
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

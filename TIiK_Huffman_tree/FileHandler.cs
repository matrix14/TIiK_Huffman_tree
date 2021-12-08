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

        public static string codeNotWorking(Dictionary<string, string> charactersCode)
        {
            foreach (var c in charactersCode)
            {
                if(c.Value.Length>=8)
                {
                    return c.Value.Substring(0, 7);
                }
            }
            return "";
        }
        public static void saveToFile(String jsonTable, String filename, String text, Dictionary<string, string> charactersCode)
        {
            FileStream fsTarget = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fsTarget.Write(Encoding.UTF8.GetBytes(jsonTable), 0, Encoding.UTF8.GetBytes(jsonTable).Length);
            fsTarget.Write(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 4);

            String buf = "";
            int abc = 0;
            foreach (char c in text)
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
            string padding = codeNotWorking(charactersCode);
            if (buf.Length > 0)
            {
                int pad = 8 - buf.Length;
                buf += padding.Substring(0, pad);
                //for (int i = 0; i < pad; i++)
                //    buf += "0";
                if (buf.Length < 8)
                    buf.PadRight(0, '0');


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

        private static void writeNoJSONTableToFile(FileStream fs, Dictionary<string, string> charactersCode)
        {
            //2 bits -> how many bytes is for CHARCTER (1,2,3,4)
            //8-32 -> character code
            //6 bits -> how many bytes is HUFFMAN CODE
            //1-64 -> huffman code
            // 00 padding to finish it -> while decoding check if there is enough bytes

            String buf = "";
            foreach (var c in charactersCode)
            {
                
                switch(Encoding.UTF8.GetBytes(c.Key).Length - 1)
                {
                    case 3:
                        buf += "11"; 
                        break;
                    case 2:
                        buf += "10";
                        break;
                    case 1:
                        buf += "01";
                        break;
                    case 0:
                        buf += "00";
                        break;
                }
                foreach(var b in Encoding.UTF8.GetBytes(c.Key))
                    buf += Convert.ToString(b, 2).PadLeft(8, '0');

                int codeLeng = c.Value.Length;
                buf += Convert.ToString((codeLeng - 1), 2).PadLeft(6, '0');

                buf += c.Value;

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

                        fs.Write(bytes, 0, bLen);
                    }
                } while (buf.Length >= 8);
            }
            if (buf.Length > 0)
            {
                int pad = 8 - buf.Length;
                for (int i = 0; i < pad; i++)
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

                fs.Write(bytes, 0, bLen);
            }
        }

        public static void saveToFileNoJSON(String filename, String text, Dictionary<string, string> charactersCode)
        {
            FileStream fsTarget = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            writeNoJSONTableToFile(fsTarget, charactersCode);
            fsTarget.Write(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 4);

            String buf = "";
            int abc = 0;
            foreach (char c in text)
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
            string padding = codeNotWorking(charactersCode);
            if (buf.Length > 0)
            {
                int pad = 8 - buf.Length;
                buf += padding.Substring(0, pad);
                //for (int i = 0; i < pad; i++)
                //    buf += "0";
                if (buf.Length < 8)
                    buf.PadRight(0, '0');

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

        public static void openFromFile(String inputFile, Boolean jsonTableAvailable)
        {
            if (!File.Exists(inputFile))
                return;
            FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read);

            String directoryName = Path.GetDirectoryName(inputFile);
            String filenameNew = Path.GetFileNameWithoutExtension(Path.GetFileName(inputFile)) + "_decoded.txt";

            bool foundMagic = false;
            long magicPosition = 0;
            int b;
            do
            {
                b = fsInput.ReadByte();
                if (b == -1)
                    break;
                if (jsonTableAvailable == true && b != 123 && fsInput.Position == 1)
                    return;
                if (jsonTableAvailable == false && b == 123 && fsInput.Position == 1)
                    return;
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

            FileStream fsOutput = new FileStream(directoryName + "\\" + filenameNew, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            fsInput.Seek(0, SeekOrigin.Begin);
            byte[] tempBuf = new byte[magicPosition];
            

            Dictionary<string, string> charactersCode;
            if (jsonTableAvailable)
            {
                fsInput.Read(tempBuf, 0, (int)magicPosition);
                String tableText = Encoding.UTF8.GetString(tempBuf);
                charactersCode = JsonConvert.DeserializeObject<Dictionary<string, string>>(tableText);
            }
            else
            {
                charactersCode = readNoJSONTableFromFile(fsInput, magicPosition);
            }


            var charactersCodeRev = charactersCode.ToDictionary(x => x.Value, x => x.Key);

            int shortestCode = 100;
            int longestCode = 0;
            foreach (var s in charactersCode)
            {
                if (shortestCode > s.Value.Length)
                    shortestCode = s.Value.Length;

                if (longestCode < s.Value.Length)
                    longestCode = s.Value.Length;
            }

            fsInput.Seek(magicPosition + 4, SeekOrigin.Begin);

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
                if (temp.Length < 8)
                    while (temp.Length < 8)
                        temp = temp.Insert(0, "0");

                buffer += temp;
                bool doAgain = false;
                do
                {
                    if ((fsInput.Position >= fsInput.Length) && (buffer.IndexOfAny(new char[] { '1' }) == -1))
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

        private static Dictionary<string, string> readNoJSONTableFromFile(FileStream fsInput, long magicPos) {
            //8-32 -> character code
            //6 bits -> how many bytes is HUFFMAN CODE
            //1-64 -> huffman code
            // 00 padding to finish it -> while decoding check if there is enough bytes

            Dictionary<string, string> codeDictionary = new Dictionary<string, string>();

            fsInput.Seek(0, SeekOrigin.Begin);
            String buf = "";
            int c = 0;
            do
            {
                c = fsInput.ReadByte();
                buf += Convert.ToString(c, 2).PadLeft(8, '0');

                if (fsInput.Position > magicPos)
                    return codeDictionary;

                byte charLength = Convert.ToByte(buf.Substring(0, 2).PadLeft(8, '0'), 2);
                buf = buf.Substring(2);
                charLength++;
                
                while(charLength*8>buf.Length)
                {
                    c = fsInput.ReadByte();
                    buf += Convert.ToString(c, 2).PadLeft(8, '0');
                }

                if (fsInput.Position > magicPos && buf.Length < 17)
                    return codeDictionary;

                byte[] oneCharBytes = new byte[charLength];
                for (int i = 0; i < charLength; ++i)
                {
                    oneCharBytes[i] = Convert.ToByte(buf.Substring(i*8, 8), 2);
                }
                //byte[] a = Convert.ToByte(buf.Substring(0, charLength * 8),2);
                string oneChar = Encoding.UTF8.GetString(oneCharBytes);
                buf = buf.Substring(charLength * 8);

                if (buf.Length < 6)
                {
                    c = fsInput.ReadByte();
                    buf += Convert.ToString(c, 2).PadLeft(8, '0');
                }
                if (fsInput.Position > magicPos && buf.Length < 17)
                    return codeDictionary;

                byte codeLength = Convert.ToByte(buf.Substring(0, 6).PadLeft(8, '0'), 2);
                codeLength++;
                buf = buf.Substring(6);

                while (buf.Length < codeLength)
                {
                    c = fsInput.ReadByte();
                    buf += Convert.ToString(c, 2).PadLeft(8, '0');
                }
                if (fsInput.Position > magicPos && buf.Length<17)
                    return codeDictionary;

                string codeForChar = buf.Substring(0, codeLength);
                buf = buf.Substring(codeLength);

                codeDictionary.Add(oneChar, codeForChar);
            } while (c != -1 && fsInput.Position<=magicPos);
            while (buf.Length > 0)
            {
                if (buf.Length < 17)
                    break;

                byte charLength = Convert.ToByte(buf.Substring(0, 2).PadLeft(8, '0'), 2);
                buf = buf.Substring(2);
                charLength++;

                if (charLength * 8 > buf.Length)
                {
                    break;
                }

                string oneChar = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(buf.Substring(0, charLength * 8)));
                buf = buf.Substring(charLength * 8);

                if (buf.Length < 6)
                {
                    break;
                }

                byte codeLength = Convert.ToByte(buf.Substring(0, 6).PadLeft(8, '0'), 2);
                codeLength++;
                buf = buf.Substring(6);

                if (buf.Length < codeLength)
                {
                    break;
                }

                string codeForChar = buf.Substring(0, codeLength);
                buf = buf.Substring(codeLength);

                codeDictionary.Add(oneChar, codeForChar);
            }
            
            return codeDictionary;

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

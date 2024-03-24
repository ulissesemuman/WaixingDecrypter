using System;
using System.Windows.Forms;
using System.IO;

namespace WaixingDecrypter
{
    class romprocess
    {

        public static void decryptwxn(string filename, bool compare, bool makenes, bool decrypthead, bool mapsave)
        {
            decryptwxn(filename, compare, makenes, decrypthead, mapsave, 0, true);
        }

        public static void decryptwxn(string filename, bool compare, bool makenes, bool decrypthead, bool mapsave, byte newmapper)
        {
            decryptwxn(filename, compare, makenes, decrypthead, mapsave, newmapper, false);
        }

        private static void decryptwxn(string filename, bool compare, bool makenes, bool decrypthead, bool mapsave, byte mapper, bool usedefaultmapper)
        {
            FileStream romin = File.Open(filename, FileMode.Open);

            FileStream proper; StreamWriter log;
            if (compare)
            {
                OpenFileDialog comparef = new OpenFileDialog();
                comparef.Filter = "Non encrypted NES games (iNES format)|*.nes";
                comparef.ShowDialog();

                proper = File.Open(comparef.FileName, FileMode.Open);
                log = new StreamWriter(filename + ".txt", false);
            }
            else { proper = null; log = null; }

            FileStream romout;
            if (makenes) { romout = File.Open(filename + ".nes", FileMode.Create); }
            else { romout = File.Open(filename + ".dec", FileMode.Create); }

            int filelength = (int)romin.Length;

            byte[] bencrypt = new byte[filelength];
            byte[] bproper = new byte[filelength];
            byte[] changed = new byte[filelength];

            byte[] wxbytes = new byte[512] { 0xD1, 0xD2, 0x90, 0xFC, 0x6D, 0xB3, 0x9E, 0x09, 0x8E, 0x33, 0x1F, 0x64, 0x88, 0xB9, 0x25, 0xB3, 0xD9, 0xA4, 0xCD, 0x11, 0x32, 0xE3, 0x99, 0x1D, 0x84, 0xD3, 0x9D, 0xDA, 0x7E, 0x12, 0x96, 0xA3, 0x7E, 0xC6, 0x3F, 0x55, 0xCB, 0xCF, 0x76, 0xA4, 0xCA, 0xBE, 0x53, 0xFE, 0x0E, 0x06, 0x14, 0x35, 0x79, 0x13, 0xBC, 0xEA, 0x01, 0x58, 0x1E, 0x3D, 0xBF, 0xCD, 0x93, 0xE7, 0x9B, 0x8B, 0x6C, 0x34, 0x7F, 0x8C, 0xB0, 0x20, 0x29, 0x1C, 0x72, 0x26, 0x5B, 0xA7, 0x9B, 0x09, 0x51, 0x5A, 0xC0, 0x63, 0xFE, 0xD1, 0x2D, 0x2C, 0x6A, 0xA9, 0xB6, 0xBB, 0xFB, 0x38, 0xC1, 0x3D, 0x22, 0x0C, 0xDB, 0x01, 0x6F, 0xDE, 0x33, 0xA5, 0x81, 0x4C, 0x92, 0x8E, 0x1C, 0x12, 0x51, 0x0B, 0xA7, 0x8C, 0xC3, 0xC7, 0xCE, 0x94, 0x3B, 0xF3, 0xD5, 0xD6, 0xC2, 0x9F, 0x2F, 0xB2, 0xEC, 0xAE, 0x46, 0x29, 0x42, 0x1A, 0x1F, 0x07, 0x8C, 0xFB, 0x2A, 0xFF, 0xCF, 0xCE, 0x09, 0x35, 0x44, 0x6E, 0x99, 0x99, 0xA3, 0x57, 0x02, 0x87, 0x39, 0x98, 0x8C, 0x2E, 0x58, 0x6C, 0xD7, 0x5B, 0xB7, 0x80, 0xC6, 0x0F, 0x86, 0x27, 0xAF, 0x00, 0x2A, 0x9B, 0xE5, 0xFA, 0x51, 0xA7, 0xA0, 0x4C, 0x47, 0xD8, 0xAF, 0xDD, 0x00, 0x86, 0xD2, 0x77, 0x7F, 0x88, 0xC8, 0xAE, 0x52, 0x56, 0xC7, 0x9E, 0x96, 0x9A, 0x04, 0x17, 0x84, 0x18, 0x74, 0x75, 0xB9, 0xD0, 0x77, 0x5F, 0xA5, 0x0C, 0x97, 0xA9, 0x1E, 0x60, 0xFC, 0x61, 0x45, 0x8C, 0xCB, 0x10, 0xAF, 0xB6, 0xE2, 0xC5, 0x5C, 0x74, 0x85, 0xB1, 0xAE, 0x87, 0x28, 0x5C, 0x89, 0x65, 0xCD, 0x09, 0x4E, 0x82, 0xC4, 0xBD, 0xED, 0x7C, 0xF5, 0x28, 0xE3, 0xBC, 0x1C, 0x51, 0x78, 0xD0, 0x41, 0x56, 0x0A, 0xAD, 0xFE, 0x89, 0xAD, 0xF1, 0x55, 0xF8, 0xCE, 0xCA, 0x69, 0x1E, 0xA6, 0x10, 0x34, 0x7A, 0x92, 0x41, 0x8D, 0x39, 0x65, 0xB8, 0x72, 0xED, 0x18, 0xBD, 0xA8, 0xC1, 0x43, 0x5D, 0xAE, 0x68, 0x0E, 0x51, 0xDE, 0x03, 0x6F, 0xE4, 0x5C, 0xAC, 0xC9, 0x1B, 0xA0, 0x52, 0xD3, 0x68, 0x08, 0xD4, 0xF0, 0xD2, 0x65, 0xD9, 0xC7, 0xAA, 0xF8, 0xB5, 0x4C, 0xFD, 0xD6, 0x41, 0xB2, 0x82, 0x68, 0x0F, 0x8A, 0x38, 0x5E, 0x7C, 0x41, 0xEB, 0x3E, 0xBD, 0xED, 0x89, 0x41, 0xC9, 0x48, 0x9B, 0xB2, 0x31, 0xE2, 0x50, 0xC3, 0xD5, 0x8D, 0x0B, 0x3A, 0x8B, 0x2E, 0xC5, 0x5B, 0xF5, 0x80, 0x97, 0x46, 0xA8, 0x0B, 0xF9, 0x30, 0xC3, 0x4D, 0x2F, 0x06, 0xB4, 0xFA, 0xEE, 0x68, 0x37, 0xAB, 0xE8, 0x0C, 0x90, 0xB8, 0x08, 0x4D, 0xD2, 0xF4, 0x8F, 0x2B, 0x4A, 0x75, 0x91, 0x44, 0xEF, 0xBB, 0xA5, 0x43, 0x00, 0xEE, 0x5F, 0x6C, 0xE8, 0x62, 0x41, 0xD3, 0x2A, 0xD7, 0xCB, 0xCD, 0x45, 0x00, 0x5F, 0x93, 0xD0, 0x78, 0x8D, 0x40, 0xF6, 0xDA, 0xAF, 0x36, 0x0B, 0x71, 0x19, 0x4C, 0x27, 0x3C, 0x04, 0xAB, 0x74, 0xCC, 0x33, 0x37, 0x88, 0xA9, 0x12, 0x67, 0xF9, 0xFF, 0x54, 0xFD, 0x91, 0x38, 0x3E, 0x0D, 0x48, 0x49, 0x8C, 0x57, 0x9D, 0x95, 0x5E, 0xCF, 0x58, 0xB6, 0xAB, 0xF9, 0x67, 0xA4, 0x9D, 0xE3, 0x78, 0x64, 0x4F, 0x85, 0x2A, 0x90, 0x38, 0x47, 0x52, 0x62, 0x03, 0xD2, 0x66, 0xF6, 0xDE, 0x80, 0x7B, 0x60, 0x44, 0x9E, 0x38, 0xC1, 0xF7, 0xDD, 0xD6, 0x4D, 0xD4, 0x16, 0xA5, 0x8E, 0xFD, 0xB1, 0x18, 0xD2, 0xA2, 0x84, 0x73, 0x3D, 0xB6, 0x13, 0x4E, 0xE0, 0x52, 0x10, 0x16, 0x64, 0xFE, 0x1A, 0x8D, 0x5C, 0x37, 0xF3, 0x72, 0x6E, 0x7F, 0x9E, 0xC3, 0xC2, 0x02, 0x75, 0x97, 0x98, 0xF2, 0x9A, 0x82, 0x30, 0x1C, 0x7F, 0x6A, 0xF5, 0x95, 0x52, 0xCE, 0x7E, 0x97, 0xAA, 0xE7, 0x36, 0xFC };

            romin.Read(bencrypt, 0, filelength);
            if (compare) { proper.Read(bproper, 0, filelength); }

            int bytecount = 0;
            int wxbytecount = 0;
            int byte8count = 0;

            int prgsize = -1; int chrsize = -1; bool vertmirror = false;

            foreach (byte bt in bencrypt)
            {

                if ((decrypthead == false || makenes == true) && bytecount <= 15)
                {

                    if (!makenes) changed[bytecount] = bt;
                    else
                    {
                        if (bytecount == 0)  changed[bytecount] = 0x4e;  //N
                        else if (bytecount == 1)  changed[bytecount] = 0x45;  //E
                        else if (bytecount == 2)  changed[bytecount] = 0x53;  //S
                        else if (bytecount == 3)  changed[bytecount] = 0x1A;  //separator
                        else if (bytecount == 4)  {changed[bytecount] = bt; prgsize = bt;}  //prg size
                        else if (bytecount == 5) { changed[bytecount] = bt; chrsize = bt;}  //chr size
                        else if (bytecount == 6)
                        {
                            if (usedefaultmapper)
                            { 
                                if (prgsize <= 2 && chrsize <= 1) { mapper = 0; vertmirror = true; }
                                else mapper = 4;
                            }
                            changed[bytecount] = 0x00;
                            if (vertmirror) changed[bytecount] += 0x01;
                            if (mapsave) changed[bytecount] += 0x02;
                            changed[bytecount] += (byte)((mapper - ((mapper / 16) * 16)) * 16);
                        }
                        else if (bytecount == 7) changed[bytecount] += (byte)((mapper / 16) * 16);
                        else changed[bytecount] = 0;
                    }
                }
                else
                {
                    byte finalbyte;
                    int newbyte = shitleft(bt, byte8count);
                    newbyte -= shitleft(wxbytes[wxbytecount], byte8count);
                    if (newbyte < 0) newbyte += 256;
                    finalbyte = (byte)newbyte;

                    changed[bytecount] = finalbyte;
                    if (compare)
                    {
                        string logline = bytecount.ToString().PadLeft(6, '0') + ": real " + bproper[bytecount].ToString().PadLeft(3, '0') + " enc " + bt.ToString().PadLeft(3, '0');
                        int diff = (bproper[bytecount] - finalbyte);
                        logline += " dec " + finalbyte.ToString().PadLeft(3, '0') + " diff " + diff;
                        if (diff != 0) log.WriteLine(logline);
                    }
                }
                byte8count++; if (byte8count == 8) byte8count = 0;
                wxbytecount++; if (wxbytecount == 512) wxbytecount = 0;
                bytecount++;
            }

            romout.Write(changed, 0, filelength);

            romin.Close();
            romout.Close();
            if (compare) { proper.Close(); log.Close(); }
        }


        private static byte shitright(byte shiftbyte, int shiftno)
        {
            string newbyte2 = Convert.ToString(shiftbyte, 2);
            newbyte2 = newbyte2.PadLeft(8, '0');

            string newbyte = "";
            if (shiftno == 0) return shiftbyte;
            else if (shiftno > 7) return 0;

            for (int bytecount = 0 - shiftno; bytecount < (0 - shiftno) + 8; bytecount++)
            {
                if (bytecount < 0) newbyte += newbyte2[bytecount + 8].ToString();
                else newbyte += newbyte2[bytecount].ToString();
            }
            return Convert.ToByte(newbyte, 2);
        }

        private static byte shitleft(byte shiftbyte, int shiftno)
        {
            string newbyte2 = Convert.ToString(shiftbyte, 2);
            newbyte2 = newbyte2.PadLeft(8, '0');

            string newbyte = "";
            if (shiftno == 0) return shiftbyte;
            else if (shiftno > 7) return 0;

            for (int bytecount = 0 + shiftno; bytecount < shiftno + 8; bytecount++)
            {
                if (bytecount > 7) newbyte += newbyte2[bytecount - 8].ToString();
                else newbyte += newbyte2[bytecount].ToString();
            }
            return Convert.ToByte(newbyte, 2);
        }

        public static void convertbin(string filename, bool meth2)
        {
            FileStream romin = File.Open(filename, FileMode.Open);
            FileStream romout = File.Open(filename + ".bin", FileMode.Create);

            int oldfilelength = (int)romin.Length;
            int newfilelength;

            byte[] orig = new byte[oldfilelength];
            byte[] noheader = new byte[oldfilelength - 16];

            romin.Read(orig, 0, oldfilelength);
            int prgsize = 0, chrsize = 0;
            int bytecount = 0;
            foreach (byte bt in orig)
            {
                if (bytecount <= 15)
                {
                    if (bytecount == 4) prgsize = bt * (16 * 1024);
                    else if (bytecount == 5) chrsize = bt * (8 * 1024);
                    // ignore otherwise, dont need header
                }
                else
                {
                    byte finalbyte = bt;
                    noheader[bytecount - 16] = finalbyte;
                }
                bytecount++;
            }

            string expmsg = "";

            if (chrsize >= prgsize) { newfilelength = chrsize * 2; }
            else { expmsg += "PRG is bigger than CHR. "; newfilelength = prgsize * 2; }


            int sizediff = 0;

            if (newfilelength / 1024 > 4096) expmsg = "WARNING -- File too big. may not work. ";
            else
            {
                for (int x = 8; x <= 4096; x *= 2)
                {
                    if (newfilelength / 1024 == x) break;
                    else if (newfilelength / 1024 < x) { sizediff = (x * 1024) - newfilelength; break; }
                }
            }

            sizediff /= 2; 

            if (sizediff != 0) { expmsg += "Increasing size of PRG + CHR by " + sizediff / 1024 + "KB. "; }

            if (expmsg != "") MessageBox.Show(expmsg + "\n(it probably won't work now)");


            newfilelength += sizediff * 2;

            byte[] changed = new byte[newfilelength];

            if (chrsize >= prgsize)
            {
                if (meth2)
                {
                    for (int x = prgsize; x < chrsize + prgsize; x++)
                        changed[(x - prgsize) + sizediff] = noheader[x];
                    for (int x = 0; x < prgsize; x++)
                        changed[x + chrsize + (chrsize - prgsize) + sizediff * 2] = noheader[x];
                }

                else
                {
                    for (int i = prgsize; i < chrsize + prgsize; i++)
                        changed[(i - prgsize)] = noheader[i];
                    for (int x = 0; x < prgsize; x++)
                        changed[x + chrsize + (chrsize - prgsize) + sizediff * 2] = noheader[x];
                }
            }

            else {
                if (!meth2)
                {
                    for (int x = prgsize; x < chrsize + prgsize; x++)
                        changed[x - prgsize] = noheader[x];
                    for (int x = 0; x < prgsize; x++)
                        changed[x + prgsize + sizediff * 2] = noheader[x];
                }

                else
                {
                    for (int x = prgsize; x < chrsize + prgsize; x++)
                        changed[(x - prgsize) + (prgsize - chrsize) + sizediff] = noheader[x];

                    for (int x = 0; x < prgsize; x++)
                        changed[x + prgsize + sizediff * 2] = noheader[x];
                }
            }

            romout.Write(changed, 0, newfilelength);
            romin.Close();
            romout.Close();

        }

    }
}

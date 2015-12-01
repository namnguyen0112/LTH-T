using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Baitaplon
{
    class LayDuLieu
    {

        private string sobaodanh, hoten, ngaysinh, dantoc, khuvuc, uutien;
        private string[] nguyenvong = new string[5];
        private string[] monthi = new string[5];
        private string[] diemthi = new string[13];
        public string SBD
        {
            get { return sobaodanh; }
        }
        public string TEN
        {
            get { return hoten; }

        }
        public string DT
        {
            get { return dantoc; }

        }
        public string KV
        {
            get { return khuvuc; }
        }
        public string UT
        {
            get { return uutien; }
        }
        public string[] NV
        {
            get { return nguyenvong; }
        }
        public string[] MONTHI
        {
            get { return monthi; }
        }
        public string[] DIEM
        {
            get { return diemthi; }
        }
        public void Laydulieu(int stt)
        {
            //lay du lieu tu bang dang ki nguyen vong
            //string a = @"C:\Users\TheNN\Desktop\BaiTapLonHDT\BaiTapLonHDT\dulieu\dangkynv-bk.txt";
            string a = @"dulieu/dangkynv-bk.txt";
            string[] line = File.ReadAllLines(a);
            string[] s = line[stt + 1].Split('	');
            int n = s.Length;
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine(s[i]);
            //}


            //cac nv
            NV[1] = s[1]; NV[2] = s[3]; NV[3] = s[5]; NV[4] = s[7];
            //for (int i = 1; i <= 4; i++)
            //{
            //    Console.WriteLine(NV[i]);
            //}
            //mon thi cac nv
            MONTHI[1] = s[2]; MONTHI[2] = s[4]; MONTHI[3] = s[6]; MONTHI[4] = s[8];
            //for (int i = 1; i <= 4; i++)
            //{
            //    Console.WriteLine(MONTHI[i]);
            //}
            //lay du lieu tu bang diem

            //string b = @"C:\Users\TheNN\Desktop\BaiTapLonHDT\BaiTapLonHDT\dulieu\csdl-bk.txt";
            string b = @"dulieu/csdl-bk.txt";
            string[] line2 = File.ReadAllLines(b);
            string[] s2 = line2[stt + 1].Split(',');
            int m = s2.Length;

            sobaodanh = s2[0];
            hoten = s2[1];
            khuvuc = s2[3];
            dantoc = s2[4];
            uutien = s2[5];
            for (int i = 6; i < m; i++)
            {
                diemthi[i - 6] = s2[i];
            }


        }


    }
}

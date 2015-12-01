
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SQLite;
namespace Baitaplon
{
    class ThiSinh
    {

        private string sobaodanh, hoten, ngaysinh, dantoc, khuvuc, uutien;
        private string[] nguyenvong = new string[5];
        private string[] monthi = new string[5];
        private double[] diemthi = new double[13];
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
        public double[] DIEM
        {
            get { return diemthi; }
        }

        public void GanGiaTri(int stt)
        {
            LayDuLieu TT = new LayDuLieu();
            TT.Laydulieu(stt);
            sobaodanh = TT.SBD;
            hoten = TT.TEN;
            khuvuc = TT.KV;
            dantoc = TT.DT;
            uutien = TT.UT;
            for (int i = 0; i < 13; i++)
            {

                if (TT.DIEM[i] == "NA")
                    diemthi[i] = 0;
                else

                    diemthi[i] = double.Parse(TT.DIEM[i]);
            }
            for (int i = 1; i <= 4; i++)
            {
                nguyenvong[i] = TT.NV[i];
                monthi[i] = TT.MONTHI[i];
            }

        }
        private double diem;

        public double diemmon(string tenmon)
        {
            switch (tenmon)
            {
                case "Toan": diem = diemthi[0]; break;
                case "Van": diem = diemthi[1]; break;
                case "Ly": diem = diemthi[2]; break;
                case "Hoa": diem = diemthi[3]; break;
                case "Sinh": diem = diemthi[4]; break;
                case "Su": diem = diemthi[5]; break;
                case "Dia": diem = diemthi[6]; break;
                case "Anh": diem = diemthi[7]; break;
                case "Nga": diem = diemthi[8]; break;
                case "Phap": diem = diemthi[9]; break;
                case "Trung": diem = diemthi[10]; break;
                case "Duc": diem = diemthi[11]; break;
                case "Nhat": diem = diemthi[12]; break;
            }
            return diem;
        }
        private double diemkv;
        public double DiemKV(string tenkhuvuc)
        {
            switch (tenkhuvuc)
            {
                case "\"KV1\"": diemkv = 1.5; break;
                case "\"KV2-NT\"": diemkv = 1; break;
                case "\"KV2\"": diemkv = 0.5; break;
                case "\"KV3\"": diemkv = 0; break;
            }
            return diemkv;
        }
        private double diemDT;
        public double Diemdantoc(string nhomdt)
        {
            switch (nhomdt)
            {
                case "\"NDT1\"": diemDT = 2; break;
                case "\"NDT2\"": diemDT = 1; break;
                case "\"Khong\"": diemDT = 0; break;
            }
            return diemDT;
        }
        private double diemUT;

        private double diemuutien(string s)
        {
            if (s == "UT") diemUT = 1;
            else diemUT = 0;
            return diemUT;
        }


        private double[] Ketqua = new double[5];
        public double[] KQ
        {
            get { return (Ketqua); }
        }
        public void Tinhkq()
        {

            for (int i = 1; i <= 4; i++)
            {
                if (monthi[i] == "NA") { Ketqua[i] = -1; }
                else
                {
                    string[] s = monthi[i].Split(',');

                    if (s[3] == "1")
                    {
                        Ketqua[i] = (diemmon(s[0]) * 2 + diemmon(s[1]) + diemmon(s[2]) + DiemKV(khuvuc)) / 4 + diemuutien(uutien) + Diemdantoc(dantoc);

                    }
                    else
                    {
                        Ketqua[i] = (diemmon(s[0]) + diemmon(s[1]) + diemmon(s[2]) + DiemKV(khuvuc)) / 3 + diemuutien(uutien) + Diemdantoc(dantoc);
                    }
                }
            }

        }
        public void Getdata(string sql)
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source =Nam.db");
            conn.Open();


            SQLiteCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SQLiteCommand();
            cmd.Connection = conn; //Gán kết nối
            //string sql = "INSERT INTO ketqua VALUES('test2',1)";


            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                Console.Write("Loi");
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }
        

    }
}

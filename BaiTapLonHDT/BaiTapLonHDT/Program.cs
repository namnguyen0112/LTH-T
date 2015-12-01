
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace Baitaplon
{
    class Program
    {
        static void Main(string[] args)
        {

            ThiSinh[] TT = new ThiSinh[100];
            for (int i = 0; i < 100; i++)
            {
                TT[i] = new ThiSinh();

                TT[i].GanGiaTri(2400 + i);
                TT[i].Tinhkq();
                for (int j = 1; j <= 4; j++)
                {
                    if (TT[i].KQ[j] > 0)
                    {
                        string sql = "INSERT INTO nvxt VALUES('" + TT[i].SBD + "','" + j + "','" + TT[i].NV[j] + "','" + TT[i].KQ[j] + "')";
                        TT[i].Getdata(sql);
                        Console.WriteLine(sql);
                    }
                }
            }


                     
                Console.ReadKey();
            
            }
    }
}

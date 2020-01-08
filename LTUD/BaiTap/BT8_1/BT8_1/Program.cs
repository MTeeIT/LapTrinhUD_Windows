using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT01
{
    class Program
    {
        static void Main(string[] args)
        {
            Double DiemToan, DiemLy, DiemHoa, DTB;

            Console.WriteLine("Nhap Diem toan: ");
            DiemToan = Double.Parse(Console.ReadLine());

            Console.WriteLine("\nnhap diem ly: ");
            DiemLy = Double.Parse(Console.ReadLine());

            Console.WriteLine("\nNhap diem hoa: ");
            DiemHoa = Double.Parse(Console.ReadLine());

            DTB = (DiemToan + DiemLy + DiemHoa) / 3;

            Console.WriteLine("Diem vua nhap:");
            Console.WriteLine("Toan: {0}", DiemToan);
            Console.WriteLine("Ly: {0}", DiemLy);
            Console.WriteLine("Hoa: {0}", DiemHoa);
            Console.WriteLine("DTB: {0}", DTB);


            if (DTB <= 5)
                {
                Console.WriteLine("Trung Binh");
                }

            else if (DTB > 5 && DTB < 8.5)
                {
                    Console.WriteLine("Kha");
                }
            else
                {
                    Console.WriteLine("Gioi");
                }

           
            Console.ReadLine();


        }
    }
}

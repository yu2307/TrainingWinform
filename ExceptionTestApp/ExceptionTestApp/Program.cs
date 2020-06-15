using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 100, y = 5, value = 0;



            try
            {
                value = x / y;
                //Console.Write("{0}/{1} = {2}", x, y, value);
                Console.WriteLine($"{x}/{y} = {value}");
                throw new Exception("1.사용자 에러");
            }

            catch (DivideByZeroException ex)
            {
                Console.WriteLine("2. y값을 0보다 크게 입력하세요");
            }

            catch (Exception ex)
            {
                Console.WriteLine("3." + ex.Message);
               
             }
            finally
            {
                Console.WriteLine("4. 프로그램이 종료했습니다.");
            }
        }
    }
}

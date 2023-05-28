using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Winda winda1 =new Winda(8);
            Console.WriteLine(winda1);
            winda1.press_button(3);
            winda1.press_button(2);
            winda1.allarm();
            Console.ReadKey();
            
        }
        class Winda
        {
            private int level;//current level
            private int top_level;
            private status winda_status = status.Stopped;
            private bool[] floor_ready;
            public Winda()//pusty konstruktor
            {
                level = 15;
                top_level = 10;
                floor_ready = new bool[10];
            }
            public Winda(int lvl,int top)//konstruktor z dwoma parametrami
            {
                level = lvl;
                top_level = top;
                floor_ready = new bool[top];
            }
            public Winda( int top)//konstruktor z jednym parametrem
            {
                level = 0;
                top_level = top;
                floor_ready = new bool[top];
            }

            public  void call(int actual)//call an elevator to actuall level
            {
                if (actual <= top_level)
                { moving_down(actual); }
                else return;
            }
           private void moving_up(int chosen)
            {
                 for(int i=level;i<chosen;i++)
                {
                    winda_status = status.Goingup;
                   
                    level++;
                    Console.WriteLine("{0}, jedziemy  na {1}", winda_status, level);
                }
                 winda_status=status.Stopped;

            }
            private void moving_down(int chosen)
            {
                for (int i=level;i>chosen;i-- )
                {
                    winda_status = status.Goingdown;
                    level--;
                    Console.WriteLine("{0}, jedziemy  na {1}", winda_status, level);
                }
                winda_status = status.Stopped;

            }
       
            public void press_button(int a)
            {
                if (a < level)
                    moving_down(a);
                else if (a > level)
                    moving_up(a);
                else if (a == level)
                    Console.WriteLine("jesteś na {0}",level);
                else
                    Console.WriteLine("bład");
            }
            public void allarm()//you can press button allarm and go to 0 level
            {
                level = 0;
                Console.WriteLine("We have some problem");
            }
            public override string ToString()//it shows current level
            {
                return level.ToString();
            }
            private enum status //this is lift status 
            {
                Goingdown,
                Stopped,
                Goingup
            }
        }
        
        
    }
}

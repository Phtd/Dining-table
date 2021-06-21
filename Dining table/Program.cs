using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dining_table
{
    class Program
    {
        //Declare fork and philosophers
        static bool[] fork = new bool[5];
        static object corg = new object();
        static Philosophers philOne = new Philosophers(0, false, false);
        static Philosophers philTwo = new Philosophers(1, false, false);
        static Philosophers philThree = new Philosophers(2, false, false);
        static Philosophers philFour = new Philosophers(3, false, false);
        static Philosophers philFive = new Philosophers(4, false, false);

        //Declare amount of Philosophers
        static void Main(string[] args)
        {
            Program pg = new Program();

            fork[0] = true;
            fork[1] = true;
            fork[2] = true;
            fork[3] = true;
            fork[4] = true;


            Thread _philOne = new Thread(new ThreadStart(pg.ThreadOne));
            Thread _philTwo = new Thread(new ThreadStart(pg.ThreadTwo));
            Thread _philThree = new Thread(new ThreadStart(pg.ThreadThree));
            Thread _philFour = new Thread(new ThreadStart(pg.ThreadFour));
            Thread _philFive = new Thread(new ThreadStart(pg.ThreadFive));

            _philOne.Start();
            _philTwo.Start();
            _philThree.Start();
            _philFour.Start();
            _philFive.Start();

        }
        public void ThreadOne()
        {
            while (true)
            {
                lock (corg)
                {
                    fork[0] = philOne.GetRFork(fork[0]);
                    fork[1] = philOne.GetLFork(fork[1]);
                    philOne.Eat();
                    fork[0] = philOne.putRFork(fork[0]);
                    fork[1] = philOne.putLFork(fork[1]);
                }
            }
        }
        public void ThreadTwo()
        {
            while (true)
            {
                lock (corg)
                {
                    fork[1] = philTwo.GetRFork(fork[1]);
                    fork[2] = philTwo.GetLFork(fork[2]);
                    philTwo.Eat();
                    fork[1] = philTwo.putRFork(fork[1]);
                    fork[2] = philTwo.putLFork(fork[2]);

                }
            }
        }
        public void ThreadThree()
        {
            while (true)
            {
                lock (corg)
                {
                    fork[2] = philThree.GetRFork(fork[2]);
                    fork[3] = philThree.GetLFork(fork[3]);
                    philThree.Eat();
                    fork[2] = philThree.putRFork(fork[2]);
                    fork[3] = philThree.putLFork(fork[3]);
                }
            }
        }
        public void ThreadFour()
        {
            while (true)
            {
                lock (corg)
                {
                    fork[3] = philFour.GetRFork(fork[3]);
                    fork[4] = philFour.GetLFork(fork[4]);
                    philFour.Eat();
                    fork[3] = philFour.putRFork(fork[3]);
                    fork[4] = philFour.putLFork(fork[4]);
                }
            }
        }
        public void ThreadFive()
        {
            while (true)
            {
                lock (corg)
                {
                    fork[4] = philFive.GetRFork(fork[4]);
                    fork[0] = philFive.GetLFork(fork[0]);
                    philFive.Eat();
                    fork[4] = philFive.putRFork(fork[4]);
                    fork[0] = philFive.putLFork(fork[0]);
                }
            }
        }

    }
}

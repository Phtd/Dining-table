using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dining_table
{
    public class Philosophers
    {
        private int id;
        private bool lFork;
        private bool rFork;

        public int Id
        {
            get 
            {
                return this.id;
            }
            set 
            { 
                this.id = value; 
            }
        }

        public bool LFork
        {
            get 
            { 
                return lFork; 
            }
            set 
            { 
                lFork = value; 
            }
        }
        public bool RFork
        {
            get 
            { 
                return rFork; 
            }
            set 
            { 
                rFork = value; 
            }
        }
        public Philosophers(int ID, bool LHFork, bool RHFork)
        {
            Id = ID;
            LFork = LHFork;
            RFork = RHFork;
        }
         
        public bool GetLFork(bool tempLFork)
        {
            if (tempLFork == true)
            {
                tempLFork = false;
                this.LFork = true;
                
            }
            else
            {
                tempLFork = true;
                this.LFork = false;
            }
            return tempLFork;
        }
        public bool GetRFork(bool tempRFork)
        {
            if (tempRFork == true)
            {
                tempRFork = false;
                this.RFork = true;
            }
            else
            {
                tempRFork = true;
                this.RFork = false;
            }
            return tempRFork;
        }
        
        public void Eat ()
        {
            Random eatTime = new Random();
            if (this.LFork == true && this.RFork == true)
            {
                Console.WriteLine($"Philosopher {this.Id} is eating");
                Thread.Sleep(eatTime.Next(100, 500));
            }
            /*else 
            { 
                Console.WriteLine($"Philosopher {this.Id} is waiting...........");
                Thread.Sleep(eatTime.Next(1000, 3000));
            }*/
        }
        public bool putRFork(bool tempRFork)
        {
            if (tempRFork == false)
            {
                tempRFork = true;
                this.RFork = false;
            }

            return tempRFork;
        }
        public bool putLFork(bool tempLFork)
        {
            if (tempLFork == false)
            {
                tempLFork = true;
                this.LFork = false;
            }
            return tempLFork;
        }
    }
}

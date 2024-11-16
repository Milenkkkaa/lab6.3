using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6._3
{
    public class House : Building
    {
        public override double GetCost
        {
            get
            {
                return GetCost;
            }
            set
            {

            }
        }
        public override double Heating
        {
            get
            {
                return Heating;
            }
            set
            {

            }
        }
        public House(double width, double length, double height, int room, int floor,
            double value, double price, bool hasForniture,
            double getCost, double heating) : base(width, length, height, room, floor, value, price, hasForniture, getCost, heating)
        {
        }
        public House() : base()
        {
        } 
    }
}

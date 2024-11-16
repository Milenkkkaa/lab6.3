using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6._3
{
    public abstract class Building
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public int Room { get; set; }
        public int Floor { get; set; }
        public double Value { get; set; }
        public double Price { get; set; }
        public bool HasForniture { get; set; }
        public Building(double width, double length, double height, int room, int floor,
            double value, double price, bool hasForniture,
            double getCost, double heating)
        {
            Width = width;
            Length = length;
            Height = height;
            Room = room;
            Floor = floor;
            Value = value;
            Price = price;
            HasForniture = hasForniture;
        }
        public Building()
        {
        }
        public abstract double GetCost { get; set; }
        public abstract double Heating { get; set; }
    }
}

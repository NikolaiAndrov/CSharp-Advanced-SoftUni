﻿namespace ClothesMagazine
{
    public class Cloth
    {
        public Cloth(string color, int size, string type)
        {
            Color = color;
            Size = size;
            Type = type;
        }

        public string Color { get; private set; }
        public int Size { get; private set; }
        public string Type { get; private set; }

        public override string ToString()
        {
            return $"Product: {Type} with size {Size}, color {Color}";
        }
    }
}

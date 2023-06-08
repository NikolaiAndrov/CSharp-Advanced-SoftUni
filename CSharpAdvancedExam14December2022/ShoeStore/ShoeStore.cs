namespace ShoeStore
{
    using System.Text;
    using System.Collections.Generic;
    public class ShoeStore
    {
        private List<Shoe> shoes;
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            this.shoes = new List<Shoe>();
        }

        public string Name { get; set; }

        public int StorageCapacity { get; set; }

        IReadOnlyCollection<Shoe> Shoes
            => this.shoes.AsReadOnly();
        
        public int Count
        {
            get
            {
                return this.shoes.Count;
            }
        }

        public string AddShoe(Shoe shoe)
        {
            if (this.shoes.Count < StorageCapacity)
            {
                this.shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }

            return "No more space in the storage room.";
        }

        public int RemoveShoes(string material)
        {
            int count = 0;

            for (int i = 0; i < this.shoes.Count; i++)
            {
                if (this.shoes[i].Material == material)
                {
                    this.shoes.RemoveAt(i);
                    i--;
                    count++;
                }
            }

            return count;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> currentShoes = new List<Shoe>();

            foreach (var shoe in this.shoes)
            {
                if (shoe.Type.ToLower() == type.ToLower())
                {
                    currentShoes.Add(shoe);
                }
            }

            return currentShoes;
        }

        public Shoe GetShoeBySize(double size)
        {
            Shoe currentShoes = null;

            foreach (var shoe in this.shoes)
            {
                if (shoe.Size == size)
                {
                    currentShoes = shoe;
                    break;
                }
            }
            return currentShoes;
        }

        public string StockList(double size, string type)
        {
            List<Shoe> stockList = this.shoes.Where(s => s.Size == size && s.Type == type).ToList();

            StringBuilder sb = new StringBuilder();
            if (stockList.Count == 0)
            {
                sb.AppendLine("No matches found!");
            }
            else
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (Shoe shoe1 in stockList)
                {
                    sb.AppendLine(shoe1.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

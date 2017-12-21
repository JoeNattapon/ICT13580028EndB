using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace ICT13580028EndB.Model
{
    public class Product
    {
        private Product product;

        public Product(Product product)
        {
            this.product = product;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Typecar { get; set; }

		[NotNull]
		public string Bran { get; set; }

        [NotNull]
        [MaxLength(100)]
		public string Classi { get; set; }

		
        public int Agecar { get; set; }

		
        public int Maicar { get; set; }

		[NotNull]
		public string Color { get; set; }

        public Boolean Card { get; set; }

		[NotNull]
		public string Parts { get; set; }

		
		public int Price { get; set; }

		[NotNull]
		public string Contr { get; set; }

		
		public int Phones { get; set; }

	}
}

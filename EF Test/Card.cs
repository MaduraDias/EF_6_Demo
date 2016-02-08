namespace EF_Test
{
    public class Card
    {
        public long CardId { get; set; }

        public string CardNumber { get; set; }

        public virtual Cardholder Cardholder { get; set; }

        public  int CardType { get; set; }

        public long CardAccountId { get; set; }

         public virtual CardDesign CardDesign { get; set; }
    }
}
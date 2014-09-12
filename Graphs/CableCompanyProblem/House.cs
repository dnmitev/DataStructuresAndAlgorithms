namespace CableCompanyProblem
{
    using System;

    internal class House
    {
        public House(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }

        public override string ToString()
        {
            return this.Id;
        }

        public override bool Equals(object obj)
        {
            var other = obj as House;
            if (other == null)
            {
                throw new ArgumentNullException("House instance .Equals method works with an instance of House");
            }

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
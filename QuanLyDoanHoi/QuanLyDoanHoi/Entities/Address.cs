using System;

namespace QuanLyDoanHoi.Entities
{
    [Serializable]
    public class Address
    {
        private string houseNumber;
        private string street;
        private string district;

        public string HouseNumber { get { return houseNumber; } set { houseNumber = value; } }
        public string Street { get { return street; } set { street = value; } }
        public string District { get { return district; } set { district = value; } }

        public Address() { }
        public Address(string houseNumber, string street, string district)
        {
            this.houseNumber = houseNumber;
            this.street = street;
            this.district = district;
        }
    }
}
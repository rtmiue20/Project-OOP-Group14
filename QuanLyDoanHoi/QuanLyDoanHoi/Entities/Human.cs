using System;
using System.Net;
using System.Text.Json.Serialization;

namespace QuanLyDoanHoi.Entities
{
    [JsonDerivedType(typeof(Student), typeDiscriminator: "Student")]
    [JsonDerivedType(typeof(Official), typeDiscriminator: "Official")]
    [JsonDerivedType(typeof(Lecturer), typeDiscriminator: "Lecturer")]
    [Serializable]
    public abstract class Human // Lớp cha trừu tượng 
    {
        private string fullName;
        private int birthYear;
        private Address residentAddress; // Composition 

        public string FullName { get { return fullName; } set { fullName = value; } }
        public int BirthYear { get { return birthYear; } set { birthYear = value; } }
        public Address ResidentAddress { get { return residentAddress; } set { residentAddress = value; } }

        public Human() { }
        public abstract void DisplayInfo();
    }
}
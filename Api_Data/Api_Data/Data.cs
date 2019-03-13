using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Api_Data
{
    class Data
    {
        public struct Name
        {
            public string title;
            public string first;
            public string last;
        }

        public struct Location
        {
            public string street;
            public string city;
            public string state;
            public string postcode;
            public string latitiude;
            public string longitude;
        }

        public struct Timezone
        {
            public string offset;
            public string description;
        }

        public struct Dob
        {
            public string date;
            public int age; 
        }

        public struct Registred
        {
            public string date { get; set; }
            public int age { get; set; }
        }

        public struct Id
        {
            public string Name { get; set; }
            public int value { get; set; }
        }

        public struct Picture
        {
            public string large;
            public string medium;
            public string thumbnail;
        }

        public struct Info
        {
            public string seed { get; set; }
            public int results { get; set; }
            public int page { get; set; }
            public int version { get; set; }
        }

        public Name name { get; set; }
        public Location location { get; set; }
        public Timezone timezone { get; set; }
        public Dob dob { get; set; }
        public Registred registred { get; set; }
        public Id id { get; set; }
        public Picture picture { get; set; }
        public Info info { get; set; }

        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public string Nat { get; set; }
    }
}

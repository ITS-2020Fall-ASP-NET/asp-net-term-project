using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NeighTrade.Models
{
    public enum State
    {
        NL, PE, NS, NB, QC, ON, MB, SK, AB, BC, YT, NT, NU
    }

    public class Address
    {
        public static readonly IList<string> Cities = new ReadOnlyCollection<string>(
        new List<string> {
            "Barrie",
            "Belleville",
            "Brampton",
            "Brant",
            "Brantford",
            "Brockville",
            "Burlington",
            "Cambridge",
            "Clarence-Rockland",
            "Cornwall",
            "Dryden",
            "Elliot Lake",
            "Greater Sudbury",
            "Guelph",
            "Haldimand County",
            "Hamilton",
            "Kawartha Lakes",
            "Kenora",
            "Kingston",
            "Kitchener",
            "London",
            "Markham",
            "Mississauga",
            "Niagara Falls",
            "Norfolk County",
            "North Bay",
            "Orillia",
            "Oshawa",
            "Ottawa",
            "Owen Sound",
            "Pembroke",
            "Peterborough",
            "Pickering",
            "Port Colborne",
            "Prince Edward County",
            "Quinte West",
            "Richmond Hill",
            "Sarnia",
            "Sault Ste. Marie",
            "St. Catharines",
            "St. Thomas",
            "Stratford",
            "Temiskaming Shores",
            "Thorold",
            "Thunder Bay",
            "Timmins",
            "Toronto",
            "Vaughan",
            "Waterloo",
            "Welland",
            "Windsor",
            "Woodstock",
            "Ajax",
            "Oakville",
            "Whitby"
        });

        public int AddressId { get; set; }

        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostalCode { get; set; }
    }
}
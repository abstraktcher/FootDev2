using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootDev2.AppData
{
    public partial class ViewAllInfo
    {

        public  string Age1 { get => $"Age: {Age}"; }

        public string Email1 { get => $"Email: {Email}"; }

        public string NameGender1 { get => $"Gender: {NameGender}"; }

        public string NationalityName1 { get => $"Nationality: {NationalityName}"; }

        public string PhoneNumber1 { get => $"Phone: {PhoneNumber}"; }

    }

    public partial class Injuries
    {

        public string Age1 { get => $"Age: {Age}"; }

        public string InjuryName1 { get => $"Type: {InjuryName}"; }

        public string Treatment1 { get => $"Treatment: {Treatment}"; }

        
    }

    public partial class ViewInfoTournament
    {
        public string Tournamentname1 { get => $"Name Of Tournament: {TournamentName}"; }

        public string PrizePool1 { get => $"Prize pool: {PrizePool} $"; }

        public string NumberOfParticipants1 { get => $"Number of participants:  {NumberOfParticipants}"; }

        public string City1 { get => $"City: {City}"; }

        public string Country1 { get => $"Country: {CountryName}"; }

        public string Sponsor1 { get => $"Sponsor Of Tournament: {SponsorName}"; }
    }
    //public string SponsorName { get; set; }

}



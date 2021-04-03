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

    public partial class ViewShowPositions
    {

        public string DominantLeg1 { get => $"Dominant Leg: {DominantLeg}"; }

        public string Positions1 { get => $"Positions: {Positions}" ; }
    }

    public partial class ViewPredispositions
    {
        public string Age1 { get => $"Age: {Age}"; }

        public string Gender1 { get => $"Gender: {NameGender}"; }

        public string Predispositions1 { get => $"Predisposition: {PredispositionName}"; }

        public string Description1 { get => $"Description: {Description}"; }

        public string Treatment1 { get => $"Treatment: {Treatment}"; }

    }

    public partial class ViewGkCharacteristics
    {

        public string Agility1 { get => $"Agility: {AgilityGK}"; }
        public string Jumping1 { get => $"Jumping: {JumpingGK}"; }
        public string Height1 { get => $"Height: {HeightGK} cm"; }
        public string Weight1 { get => $"Weight: {WeightGK} kg"; }
        public string Penalty1 { get => $"Penalty taking: {PenaltyTakingGK}"; }
        public string Vision1 { get => $"Vision: {VisionGK}"; }
        public string Anticipation1 { get => $"Anticipation: {AnticipationGK}"; }
        public string Decisions1 { get => $"Decisions: {DecisionsGK}"; }
        public string Leadership1 { get => $"Leadeship: {LeadershipGK}"; }
        public string Positioning1 { get => $"Positioning: {PositioningGK}"; }
        public string Throwing1 { get => $"Throwing: {ThrowingGK}"; }
        public string Kicking1 { get => $"kicking: {KickingGK}"; }
        public string Communication1 { get => $"Communication: {CommunicationGK}"; }
        public string OneOnOnes1 { get => $"One on ones: {OneOnOnesGK}"; }
    }
}



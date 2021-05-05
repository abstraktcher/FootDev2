using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootDev2.AppData
{
    public partial class ViewAllInfo
    {

        public string Age1 { get => $"Age: {Age}"; }

        public string Email1 { get => $"Email: {Email}"; }

        public string NameGender1 { get => $"Gender: {NameGender}"; }

        public string NationalityName1 { get => $"Nationality: {NationalityName}"; }

        public string PhoneNumber1 { get => $"Phone: {PhoneNumber}"; }

        public string Languages1 { get => $"Languages: {Languages}"; }

    }

    public partial class Injuries
    {

        public string Age1 { get => $"Age: {Age}"; }

        public string InjuryName1 { get => $"Type: {InjuryName}"; }

        public string Treatment1 { get => $"Treatment: {Treatment}"; }


    }

    public partial class Tournament
    {
        public string Tournamentname1 { get => $"Name Of Tournament: {TournamentName}"; }

        public string PrizePool1 { get => $"Prize pool: {PrizePool} $"; }

        public string NumberOfParticipants1 { get => $"Number of participants:  {NumberOfParticipants}"; }

        public string City1 { get => $"City: {City}"; }

        public string Country1 { get => $"Country: {Country}"; }

        public string Sponsor1 { get => $"Sponsor Of Tournament: {Sponsor}"; }
    }
    //public string SponsorName { get; set; }

    public partial class ViewShowPositions
    {

        public string DominantLeg1 { get => $"Dominant Leg: {DominantLeg}"; }

        public string Positions1 { get => $"Positions: {Positions}"; }
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
        public string Kicking1 { get => $"Kicking: {KickingGK}"; }
        public string Communication1 { get => $"Communication: {CommunicationGK}"; }
        public string OneOnOnes1 { get => $"One on ones: {OneOnOnesGK}"; }
    }

    public partial class ViewMFCharacteristics
    {

        public string Dribbling1 { get => $"Dribbling: {DribblingMF}"; }
        public string Pace1 { get => $"Pace: {PaceMF}"; }
        public string LongShots1 { get => $"Long Shots: {LongShotsMF} cm"; }
        public string Penalty1 { get => $"Penalty: {PenaltyMF} kg"; }
        public string Passing1 { get => $"Passing: {PassingMF}"; }
        public string Corners1 { get => $"Corners: {CornersMF}"; }
        public string Agility1 { get => $"Agility: {AgilityMF}"; }
        public string Marking1 { get => $"Marking: {MarkingMF}"; }
        public string Fitness1 { get => $"Fitness: {FitnessMF}"; }
        public string Concentration1 { get => $"Concentration: {ConcentrationMF}"; }
        public string Height1 { get => $"Height: {HeightMF} cm"; }
        public string Weight1 { get => $"Weight: {WeightMF} kg"; }
        public string Leadership1 { get => $"Leadership: {LeadershipMF}"; }
        public string Stamina1 { get => $"Stamina: {StaminaMF}"; }
        public string Strength1 { get => $"Strength: {StrengthMF}"; }
        public string FreeKick1 { get => $"Free Kick: {FreeKickMF}"; }
        public string Technique1 { get => $"Techinque: {TechniqueMF}"; }
        public string TeamWork1 { get => $"Team Work: {TeamWorkMF}"; }

    }


    public partial class ViewDFCharacteristics
    {

        public string Dribbling1 { get => $"Dribbling: {DribblingDF}"; }
        public string Heading1 { get => $"Pace: {HeadingDF}"; }
        public string LongShots1 { get => $"Long Shots: {LongShotsDF}"; }
        public string Marking1 { get => $"Marking: {MarkingDF}"; }
        public string Passing1 { get => $"Passing: {PassingDF}"; }
        public string Tackling1 { get => $"Tackling: {TacklingDF}"; }
        public string Crossing1 { get => $"Crossing: {CrossingDF}"; }
        public string WorkRate1 { get => $"Work Rate: {WorkRateDF}"; }
        public string Bravery1 { get => $"Bravery: {BraveryDF}"; }
        public string Concentration1 { get => $"Concentration: {ConcentrationDF}"; }
        public string Height1 { get => $"Height: {HeightDF} cm"; }
        public string Weight1 { get => $"Weight: {WeightDF} kg"; }
        public string Leadership1 { get => $"Leadership: {LeadershipDF}"; }
        public string Stamina1 { get => $"Stamina: {StaminaDF}"; }
        public string Jumping1 { get => $"Jumping: {JumpingDF}"; }
        public string Strength1 { get => $"Strength: {StrengthDF}"; }
        public string Positioning1 { get => $"Positioning: {PositioningDF}"; }

    }


    public partial class ViewStrikerCharacteristics
    {

        public string Dribbling1 { get => $"Dribbling: {DribblingFW}"; }
        public string Pace1 { get => $"Pace: {PaceFW}"; }
        public string LongShots1 { get => $"Long Shots: {LongShotsFW}"; }
        public string Penalty1 { get => $"Penalty: {PenaltyFW}"; }
        public string Passing1 { get => $"Passing: {PassingFW}"; }
        public string Heading1 { get => $"Heading: {HeadingFW}"; }
        public string Agility1 { get => $"Agility: {AgilityFW}"; }
        public string Finishing1 { get => $"Finishing: {FinishingFW}"; }
        public string Fitness1 { get => $"Fitness: {FitnessFW}"; }
        public string Jumping1 { get => $"Jumping: {JumpingFW}"; }
        public string Height1 { get => $"Height: {HeightFW} cm"; }
        public string Weight1 { get => $"Weight: {WeightFW} kg"; }
        public string Leadership1 { get => $"Leadership: {LeadershipFW}"; }
        public string Stamina1 { get => $"Stamina: {StaminaFW}"; }
        public string Acceleration1 { get => $"Acceleration: {AccelerationFW}"; }
        public string Strength1 { get => $"Strength: {StrengthFW}"; }
        public string Technique1 { get => $"Techinque: {TechniqueFW}"; }
        public string TeamWork1 { get => $"Team Work: {TeamWorkFW}"; }


    }


    public partial class ViewTeamTrainings
    {
        public string ClubName1 { get => $"Club: {ClubName}"; }

        public string Training1 { get => $"Training: {TrainingName}"; }

        public string Date1 { get => $"Date of Training: {Date}"; }

        public string ManagersName { get => $"Manager's Name: {Manager_s_Name}"; }

    }

    public partial class ViewIndTrainings
    {
        public string FullName1 { get => $"Name: {FullName}"; }

        public string Training1 { get => $"Training: {TrainingName}"; }

        public string Date1 { get => $"Date of Training: {DateStart}"; }

    }

    public partial class ViewExcForTest
    {
        public string FullName1 { get => $"Name: {FullName}"; }

        public string Exercise1 { get => $"Exercise: {ExerciseName}"; }

        public string Time1 { get => $"Time: {Time}"; }
        public string Number1 { get => $"Number: {Number}"; }
        public string Date1 { get => $"Date of Testing: {DateTesting}"; }


    }

    public partial class ViewChanges
    {
        public string FullName1 { get => $"Name: {Fullname}"; }

        public string Age1 { get => $"Age: {Age}"; }

        public string Action1 { get => $"Action: {Action}"; }
        public string Time1 { get => $"Time Of Change: {TimeOfChange}"; }
        public string PreviousValue1 { get => $"Previous Value: {PreviousValue}"; }
        public string NewValue1 { get => $"New Value: {NewValue}"; }
        public string Difference1 { get => $"Difference: {PreviousValue}"; }

    }

    public partial class ViewReprimands
    {
        public string FullName1 { get => $"Name: {FullName}"; }

        public string Age1 { get => $"Age: {Age}"; }

        public string Phone1 { get => $"Phone Number: {PhoneNumber}"; }
        public string Email1 { get => $"Email: {Email}"; }
        public string Reprimand { get => $"Reprimand: {ReprimandName}"; }
        public string Punishment1 { get => $"Punishment: {PunishmentName}"; }

    }

    public partial class ViewResponsiblePerson
    {
       
        public string PlayersPhone1 { get => $"Player's Phone number: {Player_s_Phone}"; }

        public string Email1 { get => $"Player's email: {Player_s_Email}"; }
        public string ResponsiblePersonPhone1 { get => $"Phone of the person in charge: {Resp_Person_s_phone}"; }
        public string ResponsiblePersonName1 { get => $"Name of the person in charge: {Pesponsible_Person}"; }

    }
}



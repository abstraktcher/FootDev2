﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootDev2.AppData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FootDevEntities : DbContext
    {
        public FootDevEntities()
            : base("name=FootDevEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<DefenderCharacteristics> DefenderCharacteristics { get; set; }
        public virtual DbSet<DominantLeg> DominantLeg { get; set; }
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<ExerciseForTest> ExerciseForTest { get; set; }
        public virtual DbSet<ExerciseToTraining> ExerciseToTraining { get; set; }
        public virtual DbSet<ForwardCharacteristics> ForwardCharacteristics { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<GoalKeeperCharacteristics> GoalKeeperCharacteristics { get; set; }
        public virtual DbSet<HistoryOfChangingSkills> HistoryOfChangingSkills { get; set; }
        public virtual DbSet<IndividualTraining> IndividualTraining { get; set; }
        public virtual DbSet<Injury> Injury { get; set; }
        public virtual DbSet<InjuryToPlayer> InjuryToPlayer { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<LanguageToPlayer> LanguageToPlayer { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<MidFielderCharacteristics> MidFielderCharacteristics { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<NationalityToPlayer> NationalityToPlayer { get; set; }
        public virtual DbSet<Personnel> Personnel { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerToDFCharacteristics> PlayerToDFCharacteristics { get; set; }
        public virtual DbSet<PlayerToFWCharacteristics> PlayerToFWCharacteristics { get; set; }
        public virtual DbSet<PlayerToGKCharacteristics> PlayerToGKCharacteristics { get; set; }
        public virtual DbSet<PlayerToMFCharacteristics> PlayerToMFCharacteristics { get; set; }
        public virtual DbSet<PlayerToPosition> PlayerToPosition { get; set; }
        public virtual DbSet<PlayerToRespReson> PlayerToRespReson { get; set; }
        public virtual DbSet<PlayerToTraits> PlayerToTraits { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Predisposition> Predisposition { get; set; }
        public virtual DbSet<PredispositionToPlayer> PredispositionToPlayer { get; set; }
        public virtual DbSet<Punishment> Punishment { get; set; }
        public virtual DbSet<Reprimand> Reprimand { get; set; }
        public virtual DbSet<ResponsiblePerson> ResponsiblePerson { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sponsor> Sponsor { get; set; }
        public virtual DbSet<StatusOfLanguage> StatusOfLanguage { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<TrainToTeam> TrainToTeam { get; set; }
        public virtual DbSet<Traits> Traits { get; set; }
        public virtual DbSet<Injuries> Injuries { get; set; }
        public virtual DbSet<ViewChanges> ViewChanges { get; set; }
        public virtual DbSet<ViewDFCharacteristics> ViewDFCharacteristics { get; set; }
        public virtual DbSet<ViewExcForTest> ViewExcForTest { get; set; }
        public virtual DbSet<ViewGkCharacteristics> ViewGkCharacteristics { get; set; }
        public virtual DbSet<ViewIndTrainings> ViewIndTrainings { get; set; }
        public virtual DbSet<ViewInfoTournament> ViewInfoTournament { get; set; }
        public virtual DbSet<ViewMFCharacteristics> ViewMFCharacteristics { get; set; }
        public virtual DbSet<ViewPlayerTraits> ViewPlayerTraits { get; set; }
        public virtual DbSet<ViewPredispositions> ViewPredispositions { get; set; }
        public virtual DbSet<ViewResponsiblePerson> ViewResponsiblePerson { get; set; }
        public virtual DbSet<ViewShowPositions> ViewShowPositions { get; set; }
        public virtual DbSet<ViewStrikerCharacteristics> ViewStrikerCharacteristics { get; set; }
        public virtual DbSet<ViewTeamTrainings> ViewTeamTrainings { get; set; }
        public virtual DbSet<ViewReprimands> ViewReprimands { get; set; }
        public virtual DbSet<ViewAllInfo> ViewAllInfo { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}

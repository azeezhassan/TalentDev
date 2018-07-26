﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TalentAcquisition.Core.Domain;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using TalentAcquisition.BusinessLogic.Domain;
using TalentAcquisition.BusinessLogic.UpdatedDomain;

namespace TalentAcquisition.DataLayer
{
    public class ApplicationUserLogin : IdentityUserLogin<int> { }
    public class ApplicationUserClaim : IdentityUserClaim<int> { }
    public class ApplicationUserRole : IdentityUserRole<int> { }

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class BaseContext<TContext> : IdentityDbContext<ApplicationUser> where TContext : IdentityDbContext<ApplicationUser>
    {
        static BaseContext()
        {

        }
        public BaseContext() : base("name=TalentConnection")
        {

        }
    }
    public class TalentContext : DbContext
    {
        public TalentContext() : base("name=TalentConnection")
        {

        }
        public static TalentContext Create()
        {
            return new TalentContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<JobRequisition>()
            //    .Property(s => s.Employee1)
            //    .HasColumnName("HeadOfDepartmentID");
            //modelBuilder.Entity<JobRequisition>().
            //    Property(s => s.Employee.ID).
            //    HasColumnName("HumanResourcePersonnelID");
           // modelBuilder.Entity<JobSeeker>().Property(e => e.RegistrationDate).HasColumnType("datetime2");
        }
        public DbSet<JobSeeker> Applicants { get; set; }
        public DbSet<JobRequisition> JobRequisitions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<InterviewDetail> InterviewDetails { get; set; }
        public DbSet<OfficePosition> OfficePositions { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        //public DbSet<Job> Jobs { get; set; }
        public DbSet<JobQualification> JobQualifications { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<MatchedApplicant> MatchedApplicants { get; set; }
        public DbSet<InterviewEvaluation> InterviewEvaluations { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<OnboardingTemplate> OnboardingTemplates { get; set; }
        public DbSet<WelcomeGuide> WelcomeGuides { get; set; }
        public DbSet<OnboardActivity> OnboardActivities { get; set; }
        public DbSet<CompletedActivity> CompletedActivities { get; set; }
        public DbSet<ManageEmployeeLeave> ManageEmployeeLeaves { get; set; }
        public DbSet<LeaveType_Limit> LeaveType_Limits { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
        // public System.Data.Entity.DbSet<TalentAcquisition.Models.RegisterViewModel> RegisterViewModels { get; set; }

        // public System.Data.Entity.DbSet<TalentAcquisition.Models.LoginViewModel> LoginViewModels { get; set; }
    }
}
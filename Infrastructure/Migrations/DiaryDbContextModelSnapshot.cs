﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DiaryDbContext))]
    partial class DiaryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.Property<Guid>("ChatMembersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatMembersId", "ChatsId");

                    b.HasIndex("ChatsId");

                    b.ToTable("ChatUser");
                });

            modelBuilder.Entity("Domain.Models.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Domain.Models.Diary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Diaries");
                });

            modelBuilder.Entity("Domain.Models.DiaryNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DiaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PressureDia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PressureSys")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pulse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiaryId");

                    b.ToTable("DiaryNotes");
                });

            modelBuilder.Entity("Domain.Models.Family", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Domain.Models.FamilyRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FamilyRoles");
                });

            modelBuilder.Entity("Domain.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Domain.Models.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FamilyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FamilyRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("FamilyRoleId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Domain.Models.Admin", b =>
                {
                    b.HasBaseType("Domain.Models.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Domain.Models.Doctor", b =>
                {
                    b.HasBaseType("Domain.Models.User");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Users", t =>
                        {
                            t.Property("FirstName")
                                .HasColumnName("Doctor_FirstName");

                            t.Property("SecondName")
                                .HasColumnName("Doctor_SecondName");
                        });

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.HasBaseType("Domain.Models.User");

                    b.Property<Guid>("DiaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PersonalDoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DiaryId");

                    b.HasIndex("PersonalDoctorId");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ChatMembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.DiaryNote", b =>
                {
                    b.HasOne("Domain.Models.Diary", null)
                        .WithMany("DiaryNotes")
                        .HasForeignKey("DiaryId");
                });

            modelBuilder.Entity("Domain.Models.Message", b =>
                {
                    b.HasOne("Domain.Models.Chat", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatId");

                    b.HasOne("Domain.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Domain.Models.Recipe", b =>
                {
                    b.HasOne("Domain.Models.Doctor", "Doctor")
                        .WithMany("Recipes")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.Patient", "Patient")
                        .WithMany("Recipes")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.HasOne("Domain.Models.Family", "Family")
                        .WithMany("FamilyMembers")
                        .HasForeignKey("FamilyId");

                    b.HasOne("Domain.Models.FamilyRole", "FamilyRole")
                        .WithMany()
                        .HasForeignKey("FamilyRoleId");

                    b.HasOne("Domain.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("FamilyRole");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.HasOne("Domain.Models.Diary", "Diary")
                        .WithMany()
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Doctor", "PersonalDoctor")
                        .WithMany("Patients")
                        .HasForeignKey("PersonalDoctorId");

                    b.Navigation("Diary");

                    b.Navigation("PersonalDoctor");
                });

            modelBuilder.Entity("Domain.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Domain.Models.Diary", b =>
                {
                    b.Navigation("DiaryNotes");
                });

            modelBuilder.Entity("Domain.Models.Family", b =>
                {
                    b.Navigation("FamilyMembers");
                });

            modelBuilder.Entity("Domain.Models.Doctor", b =>
                {
                    b.Navigation("Patients");

                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}

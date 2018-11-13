﻿// <auto-generated />
using System;
using Kanban.Infra.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kanban.Infra.Database.Migrations
{
    [DbContext(typeof(KanbanContext))]
    [Migration("20181112225253_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kanban.Shared.Domain.Artifact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AssignedUserId");

                    b.Property<long?>("IterationId");

                    b.Property<string>("Name");

                    b.Property<long?>("ProjectId");

                    b.Property<long?>("StatusId");

                    b.Property<long?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId");

                    b.HasIndex("IterationId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeId");

                    b.ToTable("Artifacts");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.ArtifactAttachment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ArtifactId");

                    b.Property<byte[]>("Content");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ArtifactId");

                    b.ToTable("ArtifactAttachments");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.ArtifactStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Name");

                    b.Property<long?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("ArtifactStatuses");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.ArtifactType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ArtifactTypes");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.Iteration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.Property<long?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Iterations");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Name");

                    b.Property<long?>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<long?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.Artifact", b =>
                {
                    b.HasOne("Kanban.Shared.Domain.User", "AssignedUser")
                        .WithMany()
                        .HasForeignKey("AssignedUserId");

                    b.HasOne("Kanban.Shared.Domain.Iteration", "Iteration")
                        .WithMany("Artifacts")
                        .HasForeignKey("IterationId");

                    b.HasOne("Kanban.Shared.Domain.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("Kanban.Shared.Domain.ArtifactStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("Kanban.Shared.Domain.ArtifactType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.ArtifactAttachment", b =>
                {
                    b.HasOne("Kanban.Shared.Domain.Artifact", "Artifact")
                        .WithMany("Attachments")
                        .HasForeignKey("ArtifactId");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.ArtifactStatus", b =>
                {
                    b.HasOne("Kanban.Shared.Domain.ArtifactType", "Type")
                        .WithMany("Statuses")
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.Iteration", b =>
                {
                    b.HasOne("Kanban.Shared.Domain.Team", "Team")
                        .WithMany("Iterations")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.Project", b =>
                {
                    b.HasOne("Kanban.Shared.Domain.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Kanban.Shared.Domain.User", b =>
                {
                    b.HasOne("Kanban.Shared.Domain.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}

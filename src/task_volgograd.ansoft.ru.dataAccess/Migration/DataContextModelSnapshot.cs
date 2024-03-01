﻿// <auto-generated />
using System;
using FirebirdSql.EntityFrameworkCore.Firebird.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using task_volgograd.ansoft.ru.dataAccess;

#nullable disable

namespace task_volgograd.ansoft.ru.dataAccess.Migration
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Fb:ValueGenerationStrategy", FbValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 31);

            modelBuilder.Entity("task_volgograd.ansoft.ru.domain.Domain.Message.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(16) CHARACTER SET OCTETS");

                    b.Property<byte[]>("AttachmentFile")
                        .HasColumnType("BLOB SUB_TYPE BINARY");

                    b.Property<Guid?>("MessageId")
                        .IsRequired()
                        .HasColumnType("CHAR(16) CHARACTER SET OCTETS");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("task_volgograd.ansoft.ru.domain.Domain.Message.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(16) CHARACTER SET OCTETS");

                    b.Property<string>("Content")
                        .HasColumnType("BLOB SUB_TYPE TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("BLOB SUB_TYPE TEXT");

                    b.Property<string>("MessageType")
                        .HasColumnType("BLOB SUB_TYPE TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("BLOB SUB_TYPE TEXT");

                    b.Property<string>("SendResult")
                        .HasColumnType("BLOB SUB_TYPE TEXT");

                    b.Property<string>("Subject")
                        .HasColumnType("BLOB SUB_TYPE TEXT");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("task_volgograd.ansoft.ru.domain.Domain.Message.Attachment", b =>
                {
                    b.HasOne("task_volgograd.ansoft.ru.domain.Domain.Message.Message", "Message")
                        .WithMany("Attachments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("task_volgograd.ansoft.ru.domain.Domain.Message.Message", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
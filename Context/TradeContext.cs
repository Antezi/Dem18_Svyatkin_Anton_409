using System;
using System.Collections.Generic;
using Dem18_Svyatkin_Anton_409.Models;
using Microsoft.EntityFrameworkCore;

namespace Dem18_Svyatkin_Anton_409.Context;

public partial class TradeContext : DbContext
{
    public TradeContext()
    {
    }

    public TradeContext(DbContextOptions<TradeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Divisionrequest> Divisionrequests { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Groupuser> Groupusers { get; set; }

    public virtual DbSet<Pass> Passes { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Requesttype> Requesttypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=37.128.207.61; Username=postgres; Database=trade; Password=Djccnfybt_Vfiby_121!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("department_pk");

            entity.ToTable("department");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("division_pk");

            entity.ToTable("division");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Divisionrequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("divisionrequest_pk");

            entity.ToTable("divisionrequest");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Divisionid).HasColumnName("divisionid");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");

            entity.HasOne(d => d.Division).WithMany(p => p.Divisionrequests)
                .HasForeignKey(d => d.Divisionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("divisionrequest_division_fk");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pk");

            entity.ToTable("employees");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnType("character varying")
                .HasColumnName("code");
            entity.Property(e => e.Departmentid).HasColumnName("departmentid");
            entity.Property(e => e.Divisionid).HasColumnName("divisionid");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Departmentid)
                .HasConstraintName("employees_fk");

            entity.HasOne(d => d.Division).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Divisionid)
                .HasConstraintName("employees_fk_1");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("goal_pk");

            entity.ToTable("goal");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Groupuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("groupusers_pk");

            entity.ToTable("groupusers");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasColumnType("character varying[]")
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasColumnType("character varying[]")
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying[]")
                .HasColumnName("lastname");
            entity.Property(e => e.Passport)
                .HasColumnType("character varying[]")
                .HasColumnName("passport");
            entity.Property(e => e.Passportscan)
                .HasColumnType("character varying[]")
                .HasColumnName("passportscan");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying[]")
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying[]")
                .HasColumnName("phone");
            entity.Property(e => e.Photo)
                .HasColumnType("character varying[]")
                .HasColumnName("photo");
        });

        modelBuilder.Entity<Pass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pass_pk");

            entity.ToTable("pass");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.Goalid).HasColumnName("goalid");
            entity.Property(e => e.Startdate).HasColumnName("startdate");

            entity.HasOne(d => d.Goal).WithMany(p => p.Passes)
                .HasForeignKey(d => d.Goalid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pass_fk");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("request_pk");

            entity.ToTable("request");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Divisionrequestid).HasColumnName("divisionrequestid");
            entity.Property(e => e.Groupusers).HasColumnName("groupusers");
            entity.Property(e => e.Note)
                .HasColumnType("character varying")
                .HasColumnName("note");
            entity.Property(e => e.Organisation)
                .HasColumnType("character varying")
                .HasColumnName("organisation");
            entity.Property(e => e.Passid).HasColumnName("passid");
            entity.Property(e => e.Typeid).HasColumnName("typeid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Divisionrequest).WithMany(p => p.Requests)
                .HasForeignKey(d => d.Divisionrequestid)
                .HasConstraintName("request_divisionrequest_fk");

            entity.HasOne(d => d.GroupusersNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.Groupusers)
                .HasConstraintName("request_fk_3");

            entity.HasOne(d => d.Pass).WithMany(p => p.Requests)
                .HasForeignKey(d => d.Passid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("request_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Requests)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("request_fk_2");
        });

        modelBuilder.Entity<Requesttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("requesttype_pk");

            entity.ToTable("requesttype");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Appointment)
                .HasColumnType("character varying")
                .HasColumnName("appointment");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasColumnType("character varying")
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Passport)
                .HasColumnType("character varying")
                .HasColumnName("passport");
            entity.Property(e => e.Passportscan)
                .HasColumnType("character varying")
                .HasColumnName("passportscan");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Photo)
                .HasColumnType("character varying")
                .HasColumnName("photo");
            entity.Property(e => e.RoleCode).HasColumnName("role_code");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userrole_pk");

            entity.ToTable("userrole");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

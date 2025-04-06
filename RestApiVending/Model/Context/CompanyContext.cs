using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestApiVending.Model;

namespace RestApiVending.Model.Context;

public partial class CompanyContext : DbContext
{
    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DostawaTowary> DostawaTowaries { get; set; }

    public virtual DbSet<Dostawcy> Dostawcies { get; set; }

    public virtual DbSet<Faktury> Fakturies { get; set; }

    public virtual DbSet<LokalizacjaMaszyny> LokalizacjaMaszynies { get; set; }

    public virtual DbSet<Lokalizacje> Lokalizacjes { get; set; }

    public virtual DbSet<MagazynTowary> MagazynTowaries { get; set; }

    public virtual DbSet<Magazyny> Magazynies { get; set; }

    public virtual DbSet<MaszynaTowary> MaszynaTowaries { get; set; }

    public virtual DbSet<Maszyny> Maszynies { get; set; }

    public virtual DbSet<Pojazdy> Pojazdies { get; set; }

    public virtual DbSet<Pracownicy> Pracownicies { get; set; }

    public virtual DbSet<PracownikTowary> PracownikTowaries { get; set; }

    public virtual DbSet<StanowiskaPracy> StanowiskaPracies { get; set; }

    public virtual DbSet<Towary> Towaries { get; set; }

    public virtual DbSet<Transakcje> Transakcjes { get; set; }

    public virtual DbSet<Trasy> Trasies { get; set; }

    public virtual DbSet<TypyMaszyn> TypyMaszyns { get; set; }

    public virtual DbSet<Warsztaty> Warsztaties { get; set; }

    public virtual DbSet<Wizyty> Wizyties { get; set; }

    public virtual DbSet<ZamowieniaZewnetrzne> ZamowieniaZewnetrznes { get; set; }

    public virtual DbSet<Zamowienia> Zamowienia { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DostawaTowary>(entity =>
        {
            entity.HasOne(d => d.IdtowaruNavigation).WithMany(p => p.DostawaTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DostawaTowary_Towary");

            entity.HasOne(d => d.IdzamowienieZewnetrzneNavigation).WithMany(p => p.DostawaTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DostawaTowary_ZamowieniaZewnetrzne");
        });

        modelBuilder.Entity<Dostawcy>(entity =>
        {
            entity.Property(e => e.KodPocztowy).IsFixedLength();
        });

        modelBuilder.Entity<Faktury>(entity =>
        {
            entity.Property(e => e.KodPocztowy).IsFixedLength();
            entity.Property(e => e.Nip).IsFixedLength();
        });

        modelBuilder.Entity<LokalizacjaMaszyny>(entity =>
        {
            entity.HasKey(e => new { e.IdLokalizacji, e.NumerMaszyny }).HasName("PK__Lokaliza__1BD89944B8F83B92");

            entity.Property(e => e.NumerMaszyny).IsFixedLength();

            entity.HasOne(d => d.IdLokalizacjiNavigation).WithMany(p => p.LokalizacjaMaszynies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lokalizac__IdLok__278EDA44");

            entity.HasOne(d => d.NumerMaszynyNavigation).WithOne(p => p.LokalizacjaMaszyny)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lokalizac__Numer__2882FE7D");
        });

        modelBuilder.Entity<Lokalizacje>(entity =>
        {
            entity.Property(e => e.KodPocztowy).IsFixedLength();
        });

        modelBuilder.Entity<MagazynTowary>(entity =>
        {
            entity.HasOne(d => d.IdmagazynuNavigation).WithMany(p => p.MagazynTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MagazynTowary_Magazyny");

            entity.HasOne(d => d.IdtowaruNavigation).WithMany(p => p.MagazynTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MagazynTowary_Towary");
        });

        modelBuilder.Entity<Magazyny>(entity =>
        {
            entity.Property(e => e.KodPocztowy).IsFixedLength();
        });

        modelBuilder.Entity<MaszynaTowary>(entity =>
        {
            entity.Property(e => e.NumerMaszyny).IsFixedLength();

            entity.HasOne(d => d.IdtowaruNavigation).WithMany(p => p.MaszynaTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaszynaTowary_Towary");

            entity.HasOne(d => d.NumerMaszynyNavigation).WithMany(p => p.MaszynaTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaszynaTowary_Maszyny");
        });

        modelBuilder.Entity<Maszyny>(entity =>
        {
            entity.HasKey(e => e.NumerMaszyny).HasName("PK_Maszyny_1");

            entity.Property(e => e.NumerMaszyny).IsFixedLength();

            entity.HasOne(d => d.IdtypMaszynyNavigation).WithMany(p => p.Maszynies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Maszyny_TypyMaszyn");

            entity.HasMany(d => d.Idtrasies).WithMany(p => p.NumerMaszynies)
                .UsingEntity<Dictionary<string, object>>(
                    "MaszynaTrasa",
                    r => r.HasOne<Trasy>().WithMany()
                        .HasForeignKey("Idtrasy")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MaszynaTr__IDTra__324172E1"),
                    l => l.HasOne<Maszyny>().WithMany()
                        .HasForeignKey("NumerMaszyny")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MaszynaTr__Numer__314D4EA8"),
                    j =>
                    {
                        j.HasKey("NumerMaszyny", "Idtrasy").HasName("PK__MaszynaT__3643C2A764850984");
                        j.ToTable("MaszynaTrasa");
                        j.IndexerProperty<string>("NumerMaszyny")
                            .HasMaxLength(10)
                            .IsFixedLength();
                        j.IndexerProperty<int>("Idtrasy").HasColumnName("IDTrasy");
                    });
        });

        modelBuilder.Entity<Pojazdy>(entity =>
        {
            entity.Property(e => e.NumerRejestracyjny).IsFixedLength();

            entity.HasOne(d => d.IdwarsztatuNavigation).WithMany(p => p.Pojazdies).HasConstraintName("FK_Pojazdy_Warsztaty");
        });

        modelBuilder.Entity<Pracownicy>(entity =>
        {
            entity.HasOne(d => d.IdpojazduNavigation).WithMany(p => p.Pracownicies).HasConstraintName("FK_Pracownicy_Pojazdy");

            entity.HasOne(d => d.IdstanowiskaPracyNavigation).WithMany(p => p.Pracownicies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pracownicy_StanowiskaPracy");

            entity.HasOne(d => d.IdtrasyNavigation).WithMany(p => p.Pracownicies).HasConstraintName("FK_Pracownicy_Trasy");
        });

        modelBuilder.Entity<PracownikTowary>(entity =>
        {
            entity.HasOne(d => d.IdpracownikaNavigation).WithMany(p => p.PracownikTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PracownikTowary_Pracownicy");

            entity.HasOne(d => d.IdtowaruNavigation).WithMany(p => p.PracownikTowaries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PracownikTowary_Towary");
        });

        modelBuilder.Entity<Transakcje>(entity =>
        {
            entity.Property(e => e.NumerMaszyny).IsFixedLength();
            entity.Property(e => e.TypPlatnosci).IsFixedLength();

            entity.HasOne(d => d.IdtowaruNavigation).WithMany(p => p.Transakcjes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transakcje_Towary");

            entity.HasOne(d => d.NumerMaszynyNavigation).WithMany(p => p.Transakcjes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transakcje_Maszyny");
        });

        modelBuilder.Entity<Warsztaty>(entity =>
        {
            entity.Property(e => e.KodPocztowy).IsFixedLength();
        });

        modelBuilder.Entity<Wizyty>(entity =>
        {
            entity.Property(e => e.NumerMaszyny).IsFixedLength();

            entity.HasOne(d => d.IdpracownikaNavigation).WithMany(p => p.Wizyties)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wizyty_Pracownicy");

            entity.HasOne(d => d.NumerMaszynyNavigation).WithMany(p => p.Wizyties)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wizyty_Maszyny");
        });

        modelBuilder.Entity<ZamowieniaZewnetrzne>(entity =>
        {
            entity.HasKey(e => e.IdzamowienieZewnetrzne).HasName("PK_ZamowieniaZewnetrzne_1");

            entity.HasOne(d => d.IddostawcyNavigation).WithMany(p => p.ZamowieniaZewnetrznes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZamowieniaZewnetrzne_Dostawcy");

            entity.HasOne(d => d.IdfakturyNavigation).WithOne(p => p.ZamowieniaZewnetrzne)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZamowieniaZewnetrzne_Faktury");

            entity.HasOne(d => d.IdmagazynuNavigation).WithMany(p => p.ZamowieniaZewnetrznes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZamowieniaZewnetrzne_Magazyny");
        });

        modelBuilder.Entity<Zamowienia>(entity =>
        {
            entity.HasKey(e => e.Idzamowienia).HasName("PK_Zamowienia_1");

            entity.HasOne(d => d.IdmagazynuNavigation).WithMany(p => p.Zamowienia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zamowienia_Magazyny");

            entity.HasOne(d => d.IdpracownikaNavigation).WithMany(p => p.Zamowienia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zamowienia_Pracownicy");

            entity.HasMany(d => d.Idtowarus).WithMany(p => p.Idzamowienia)
                .UsingEntity<Dictionary<string, object>>(
                    "ZamowienieTowary",
                    r => r.HasOne<Towary>().WithMany()
                        .HasForeignKey("Idtowaru")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ZamowienieTowary_Towary"),
                    l => l.HasOne<Zamowienia>().WithMany()
                        .HasForeignKey("Idzamowienia")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ZamowienieTowary_Zamowienia"),
                    j =>
                    {
                        j.HasKey("Idzamowienia", "Idtowaru");
                        j.ToTable("ZamowienieTowary");
                        j.IndexerProperty<int>("Idzamowienia").HasColumnName("IDZamowienia");
                        j.IndexerProperty<int>("Idtowaru").HasColumnName("IDTowaru");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

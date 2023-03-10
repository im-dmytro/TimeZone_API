// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeZoneAPI.Models;

#nullable disable

namespace TimeZoneAPI.Migrations
{
    [DbContext(typeof(CountryTimeApiContext))]
    partial class CountryTimeApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TimeZoneAPI.Models.CountryCapital", b =>
                {
                    b.Property<int>("CapitalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CapitalID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CapitalId"));

                    b.Property<string>("Capital")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("capital");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("country");

                    b.HasKey("CapitalId")
                        .HasName("PK__CountryC__D3DFD193FC2D8284");

                    b.ToTable("CountryCapital", (string)null);
                });

            modelBuilder.Entity("TimeZoneAPI.Models.CountryFlag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(58)
                        .IsUnicode(false)
                        .HasColumnType("varchar(58)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(68)
                        .IsUnicode(false)
                        .HasColumnType("varchar(68)")
                        .HasColumnName("URL");

                    b.HasKey("Id")
                        .HasName("PK__CountryF__3214EC2719C3C517");

                    b.ToTable("CountryFlag", (string)null);
                });

            modelBuilder.Entity("TimeZoneAPI.Models.CountryTimeZone", b =>
                {
                    b.Property<int>("TimeZoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TimeZoneID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeZoneId"));

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CountryCode")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("Country_Code");

                    b.Property<string>("GmtOffset")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("GMT_Offset");

                    b.Property<string>("TimeZoneName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Time_Zone_Name");

                    b.HasKey("TimeZoneId")
                        .HasName("PK__CountryT__78D387CF5E57B2FB");

                    b.ToTable("CountryTimeZones");
                });
#pragma warning restore 612, 618
        }
    }
}

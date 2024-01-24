using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace APINorthwind.Models;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext()
    {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategorySalesFor1997> CategorySalesFor1997s { get; set; }

    public virtual DbSet<CurrentProductList> CurrentProductLists { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCities { get; set; }

    public virtual DbSet<Customerdemographic> Customerdemographics { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderDetailsExtended> OrderDetailsExtendeds { get; set; }

    public virtual DbSet<OrderSubtotal> OrderSubtotals { get; set; }

    public virtual DbSet<OrdersQry> OrdersQries { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductSalesFor1997> ProductSalesFor1997s { get; set; }

    public virtual DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrices { get; set; }

    public virtual DbSet<ProductsByCategory> ProductsByCategories { get; set; }

    public virtual DbSet<QuarterlyOrder> QuarterlyOrders { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<SalesByCategory> SalesByCategories { get; set; }

    public virtual DbSet<SalesTotalsByAmount> SalesTotalsByAmounts { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarters { get; set; }

    public virtual DbSet<SummaryOfSalesByYear> SummaryOfSalesByYears { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Territory> Territories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=northwind;uid=root;password=1234abcd", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.44-mysql"));
            }
        }
    }
    /*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=northwind;uid=root;password=1234abcd", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.44-mysql")); */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<AlphabeticalListOfProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("alphabetical list of products");

            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.Discontinued)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.ReorderLevel)
                .HasDefaultValueSql("'0'")
                .HasColumnType("smallint(2)");
            entity.Property(e => e.SupplierId)
                .HasColumnType("int(11)")
                .HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10, 4)
                .HasDefaultValueSql("'0.0000'");
            entity.Property(e => e.UnitsInStock)
                .HasDefaultValueSql("'0'")
                .HasColumnType("smallint(2)");
            entity.Property(e => e.UnitsOnOrder)
                .HasDefaultValueSql("'0'")
                .HasColumnType("smallint(2)");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.HasIndex(e => e.CategoryName, "CategoryName");

            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.Description).HasColumnType("mediumtext");
        });

        modelBuilder.Entity<CategorySalesFor1997>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("category sales for 1997");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.CategorySales).HasColumnType("double(25,8)");
        });

        modelBuilder.Entity<CurrentProductList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("current product list");

            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.HasIndex(e => e.City, "City");

            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.HasIndex(e => e.Region, "Region");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);

            entity.HasMany(d => d.CustomerTypes).WithMany(p => p.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "Customercustomerdemo",
                    r => r.HasOne<Customerdemographic>().WithMany()
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerCustomerDemo"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerCustomerDemo_Customers"),
                    j =>
                    {
                        j.HasKey("CustomerId", "CustomerTypeId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("customercustomerdemo");
                        j.HasIndex(new[] { "CustomerTypeId" }, "FK_CustomerCustomerDemo");
                        j.IndexerProperty<string>("CustomerId")
                            .HasMaxLength(5)
                            .HasColumnName("CustomerID");
                        j.IndexerProperty<string>("CustomerTypeId")
                            .HasMaxLength(10)
                            .HasColumnName("CustomerTypeID");
                    });
        });

        modelBuilder.Entity<CustomerAndSuppliersByCity>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("customer and suppliers by city");

            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .HasDefaultValueSql("''");
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.Relationship)
                .HasMaxLength(9)
                .HasDefaultValueSql("''")
                .UseCollation("cp850_general_ci")
                .HasCharSet("cp850");
        });

        modelBuilder.Entity<Customerdemographic>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId).HasName("PRIMARY");

            entity.ToTable("customerdemographics");

            entity.Property(e => e.CustomerTypeId)
                .HasMaxLength(10)
                .HasColumnName("CustomerTypeID");
            entity.Property(e => e.CustomerDesc).HasColumnType("mediumtext");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.ReportsTo, "FK_Employees_Employees");

            entity.HasIndex(e => e.LastName, "LastName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.Property(e => e.EmployeeId)
                .HasColumnType("int(11)")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Extension).HasMaxLength(4);
            entity.Property(e => e.FirstName).HasMaxLength(10);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.HomePhone).HasMaxLength(24);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Notes).HasColumnType("mediumtext");
            entity.Property(e => e.PhotoPath).HasMaxLength(255);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.ReportsTo).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasMaxLength(30);
            entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK_Employees_Employees");

            entity.HasMany(d => d.Territories).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "Employeeterritory",
                    r => r.HasOne<Territory>().WithMany()
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Territories"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeTerritories_Employees"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "TerritoryId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("employeeterritories");
                        j.HasIndex(new[] { "TerritoryId" }, "FK_EmployeeTerritories_Territories");
                        j.IndexerProperty<int>("EmployeeId")
                            .HasColumnType("int(11)")
                            .HasColumnName("EmployeeID");
                        j.IndexerProperty<string>("TerritoryId")
                            .HasMaxLength(20)
                            .HasColumnName("TerritoryID");
                    });
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("invoices");

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName).HasMaxLength(40);
            entity.Property(e => e.Discount).HasColumnType("double(8,0)");
            entity.Property(e => e.ExtendedPrice).HasColumnType("double(25,8)");
            entity.Property(e => e.Freight)
                .HasPrecision(10, 4)
                .HasDefaultValueSql("'0.0000'");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(2)");
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.ShipperName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasPrecision(10, 4);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.CustomerId, "FK_Orders_Customers");

            entity.HasIndex(e => e.EmployeeId, "FK_Orders_Employees");

            entity.HasIndex(e => e.ShipVia, "FK_Orders_Shippers");

            entity.HasIndex(e => e.OrderDate, "OrderDate");

            entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");

            entity.HasIndex(e => e.ShippedDate, "ShippedDate");

            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("int(11)")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Freight)
                .HasPrecision(10, 4)
                .HasDefaultValueSql("'0.0000'");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShipVia).HasColumnType("int(11)");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Orders_Employees");

            entity.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShipVia)
                .HasConstraintName("FK_Orders_Shippers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("order details");

            entity.HasIndex(e => e.ProductId, "FK_Order_Details_Products");

            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.Discount).HasColumnType("double(8,0)");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(2)");
            entity.Property(e => e.UnitPrice).HasPrecision(10, 4);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Details_Products");
        });

        modelBuilder.Entity<OrderDetailsExtended>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("order details extended");

            entity.Property(e => e.Discount).HasColumnType("double(8,0)");
            entity.Property(e => e.ExtendedPrice).HasColumnType("double(25,8)");
            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(2)");
            entity.Property(e => e.UnitPrice).HasPrecision(10, 4);
        });

        modelBuilder.Entity<OrderSubtotal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("order subtotals");

            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.Subtotal).HasColumnType("double(25,8)");
        });

        modelBuilder.Entity<OrdersQry>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("orders qry");

            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId)
                .HasColumnType("int(11)")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Freight)
                .HasPrecision(10, 4)
                .HasDefaultValueSql("'0.0000'");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.RequiredDate).HasColumnType("datetime");
            entity.Property(e => e.ShipAddress).HasMaxLength(60);
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
            entity.Property(e => e.ShipRegion).HasMaxLength(15);
            entity.Property(e => e.ShipVia).HasColumnType("int(11)");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.CategoryId, "FK_Products_Categories");

            entity.HasIndex(e => e.SupplierId, "FK_Products_Suppliers");

            entity.HasIndex(e => e.ProductName, "ProductName");

            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.Discontinued)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.ReorderLevel)
                .HasDefaultValueSql("'0'")
                .HasColumnType("smallint(2)");
            entity.Property(e => e.SupplierId)
                .HasColumnType("int(11)")
                .HasColumnName("SupplierID");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10, 4)
                .HasDefaultValueSql("'0.0000'");
            entity.Property(e => e.UnitsInStock)
                .HasDefaultValueSql("'0'")
                .HasColumnType("smallint(2)");
            entity.Property(e => e.UnitsOnOrder)
                .HasDefaultValueSql("'0'")
                .HasColumnType("smallint(2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Products_Suppliers");
        });

        modelBuilder.Entity<ProductSalesFor1997>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("product sales for 1997");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.ProductSales).HasColumnType("double(25,8)");
        });

        modelBuilder.Entity<ProductsAboveAveragePrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("products above average price");

            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10, 4)
                .HasDefaultValueSql("'0.0000'");
        });

        modelBuilder.Entity<ProductsByCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("products by category");

            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.Discontinued)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.UnitsInStock)
                .HasDefaultValueSql("'0'")
                .HasColumnType("smallint(2)");
        });

        modelBuilder.Entity<QuarterlyOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("quarterly orders");

            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasColumnName("CustomerID");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PRIMARY");

            entity.ToTable("region");

            entity.Property(e => e.RegionId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("RegionID");
            entity.Property(e => e.RegionDescription).HasMaxLength(50);
        });

        modelBuilder.Entity<SalesByCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sales by category");

            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.ProductSales).HasColumnType("double(25,8)");
        });

        modelBuilder.Entity<SalesTotalsByAmount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sales totals by amount");

            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.SaleAmount).HasColumnType("double(25,8)");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.ShipperId).HasName("PRIMARY");

            entity.ToTable("shippers");

            entity.Property(e => e.ShipperId)
                .HasColumnType("int(11)")
                .HasColumnName("ShipperID");
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.Phone).HasMaxLength(24);
        });

        modelBuilder.Entity<SummaryOfSalesByQuarter>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("summary of sales by quarter");

            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.Subtotal).HasColumnType("double(25,8)");
        });

        modelBuilder.Entity<SummaryOfSalesByYear>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("summary of sales by year");

            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            entity.Property(e => e.Subtotal).HasColumnType("double(25,8)");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.ToTable("suppliers");

            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.Property(e => e.SupplierId)
                .HasColumnType("int(11)")
                .HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(30);
            entity.Property(e => e.ContactTitle).HasMaxLength(30);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.HomePage).HasColumnType("mediumtext");
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Region).HasMaxLength(15);
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.HasKey(e => e.TerritoryId).HasName("PRIMARY");

            entity.ToTable("territories");

            entity.HasIndex(e => e.RegionId, "FK_Territories_Region");

            entity.Property(e => e.TerritoryId)
                .HasMaxLength(20)
                .HasColumnName("TerritoryID");
            entity.Property(e => e.RegionId)
                .HasColumnType("int(11)")
                .HasColumnName("RegionID");
            entity.Property(e => e.TerritoryDescription).HasMaxLength(50);

            entity.HasOne(d => d.Region).WithMany(p => p.Territories)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Territories_Region");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

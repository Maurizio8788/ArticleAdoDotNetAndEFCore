// See https://aka.ms/new-console-template for more information
using ArticoleAdoDotNetAndEFCore;
using ArticoleAdoDotNetAndEFCore.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

var configuration = new ConfigurationBuilder()
             .SetBasePath(AppContext.BaseDirectory)
             .AddJsonFile("appsettings.json", optional: true)
             .Build();


var connectionString = configuration.GetConnectionString("AdventureWorksDatabase");

using SqlConnection sqlConnection = new(connectionString);

string query = "SELECT TOP 100 Name, ProductNumber FROM [Production].[Product]";

//SqlCommand commandFluent = sqlConnection.CreateCommand();
//commandFluent.CommandText = query;

/* **************************** otherwise *********************************/

SqlCommand command = new SqlCommand(query, sqlConnection);

/* **************************** execute *********************************/

try
{
    sqlConnection.Open();
    using SqlDataReader reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine($"{reader["Name"]} - {reader["ProductNumber"]}");
    }
}
catch (Exception ex)
{
    throw;
}
finally
{
    sqlConnection.Close();
}

#region InsertExample

//query = $@"
//INSERT INTO [Production].[Product] ([Name],
//      [ProductNumber],
//      [MakeFlag],
//      [FinishedGoodsFlag],
//      [Color],
//      [SafetyStockLevel],
//      [ReorderPoint],
//      [StandardCost],
//      [ListPrice],
//      [Size],
//      [SizeUnitMeasureCode],
//      [WeightUnitMeasureCode],
//      [Weight],
//      [DaysToManufacture],
//      [ProductLine],
//      [Class],
//      [Style],
//      [ProductSubcategoryID],
//      [ProductModelID],
//      [SellStartDate],
//      [SellEndDate],
//      [DiscontinuedDate],
//      [rowguid],
//      [ModifiedDate]
//)
//VALUES (@Name, @ProductNumber, @MakeFlag, @FinishedGoodsFlag, @Color, @SafetyStockLevel, @ReorderPoint, @StandardCost, @ListPrice, @Size, @SizeUnitMeasureCode, @WeightUnitMeasureCode, @Weight, @DaysToManufacture, @ProductLine, @Class, @Style, @ProductSubcategoryID, @ProductModelID, @SellStartDate, @SellEndDate, @DiscontinuedDate, @rowguid, @ModifiedDate);
//";

//SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


//sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = "Nuovo Prodotto";
//sqlCommand.Parameters.Add(new SqlParameter("@ProductNumber", SqlDbType.NVarChar, 25)).Value = "N12345";
//sqlCommand.Parameters.Add(new SqlParameter("@MakeFlag", SqlDbType.Bit)).Value = true;
//sqlCommand.Parameters.Add(new SqlParameter("@FinishedGoodsFlag", SqlDbType.Bit)).Value = true;
//sqlCommand.Parameters.Add(new SqlParameter("@Color", SqlDbType.NVarChar, 15)).Value = "Rosso";
//sqlCommand.Parameters.Add(new SqlParameter("@SafetyStockLevel", SqlDbType.SmallInt)).Value = 10;
//sqlCommand.Parameters.Add(new SqlParameter("@ReorderPoint", SqlDbType.SmallInt)).Value = 5;
//sqlCommand.Parameters.Add(new SqlParameter("@StandardCost", SqlDbType.Money)).Value = 10.00;
//sqlCommand.Parameters.Add(new SqlParameter("@ListPrice", SqlDbType.Money)).Value = 19.99;
//sqlCommand.Parameters.Add(new SqlParameter("@Size", SqlDbType.NVarChar, 5)).Value = "M";
//sqlCommand.Parameters.Add(new SqlParameter("@SizeUnitMeasureCode", SqlDbType.NChar, 3)).Value = "CM";
//sqlCommand.Parameters.Add(new SqlParameter("@WeightUnitMeasureCode", SqlDbType.NChar, 3)).Value = "KG";
//sqlCommand.Parameters.Add(new SqlParameter("@Weight", SqlDbType.Decimal, 8, 2)).Value = 2.5;
//sqlCommand.Parameters.Add(new SqlParameter("@DaysToManufacture", SqlDbType.Int)).Value = 5;
//sqlCommand.Parameters.Add(new SqlParameter("@ProductLine", SqlDbType.NChar, 2)).Value = "PL";
//sqlCommand.Parameters.Add(new SqlParameter("@Class", SqlDbType.NChar, 2)).Value = "CL";
//sqlCommand.Parameters.Add(new SqlParameter("@Style", SqlDbType.NChar, 2)).Value = "ST";
//sqlCommand.Parameters.Add(new SqlParameter("@ProductSubcategoryID", SqlDbType.Int)).Value = 1;
//sqlCommand.Parameters.Add(new SqlParameter("@ProductModelID", SqlDbType.Int)).Value = 1;
//sqlCommand.Parameters.Add(new SqlParameter("@SellStartDate", SqlDbType.DateTime)).Value = DateTime.Now;
//sqlCommand.Parameters.Add(new SqlParameter("@SellEndDate", SqlDbType.DateTime)).Value = DBNull.Value; // Imposta su DBNull se il valore è nullo
//sqlCommand.Parameters.Add(new SqlParameter("@DiscontinuedDate", SqlDbType.DateTime)).Value = DBNull.Value;
//sqlCommand.Parameters.Add(new SqlParameter("@rowguid", SqlDbType.UniqueIdentifier)).Value = Guid.NewGuid();
//sqlCommand.Parameters.Add(new SqlParameter("@ModifiedDate", SqlDbType.DateTime)).Value = DateTime.Now;



//try
//{
//    sqlConnection.Open();
//    sqlCommand.ExecuteNonQuery();
//}
//catch (Exception ex)
//{
//    throw;
//}
//finally
//{
//    sqlConnection.Close();
//}

#endregion

#region Implicit Conversion

//query = @"
//SELECT 
//	TOP 1
//	[BusinessEntityID],
//	[Title],
//	[FirstName],
//	[MiddleName],
//	[LastName],
//	[Suffix],
//	[JobTitle],
//	[PhoneNumber],
//	[PhoneNumberType],
//	[EmailAddress],
//	[EmailPromotion],
//	[AddressLine1],
//	[AddressLine2],
//	[City],
//	[StateProvinceName],
//	[PostalCode],
//	[CountryRegionName],
//	[AdditionalContactInfo]
//FROM [HumanResources].[vEmployee];
//";

//SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

//try
//{
//	sqlConnection.Open();
//	using SqlDataReader reader = sqlCommand.ExecuteReader();
//    //Employee employee = reader;
//    Employee employee = reader.ConvertToEntities<Employee>();
//    Console.WriteLine(employee);
//}
//catch (Exception ex)
//{
//	throw;
//}
//finally
//{
//	sqlConnection.Close();
//}

#endregion;

#region Explicit Conversion

//query = @"
//SELECT 
//	TOP 1
//	[BusinessEntityID],
//	[Title],
//	[FirstName],
//	[MiddleName],
//	[LastName],
//	[Suffix],
//	[JobTitle],
//	[PhoneNumber],
//	[PhoneNumberType],
//	[EmailAddress],
//	[EmailPromotion],
//	[AddressLine1],
//	[AddressLine2],
//	[City],
//	[StateProvinceName],
//	[PostalCode],
//	[CountryRegionName],
//	[AdditionalContactInfo]
//FROM [HumanResources].[vEmployee];
//";

//SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

//try
//{
//    sqlConnection.Open();
//    using SqlDataReader reader = sqlCommand.ExecuteReader();
//    Employee employee = (Employee)reader;
//    Console.WriteLine(employee);
//}
//catch (Exception ex)
//{
//    throw;
//}
//finally
//{
//    sqlConnection.Close();
//}

#endregion;

#region Conversion with extension method

//query = @"
//SELECT 
//	TOP 1
//	[BusinessEntityID],
//	[Title],
//	[FirstName],
//	[MiddleName],
//	[LastName],
//	[Suffix],
//	[JobTitle],
//	[PhoneNumber],
//	[PhoneNumberType],
//	[EmailAddress],
//	[EmailPromotion],
//	[AddressLine1],
//	[AddressLine2],
//	[City],
//	[StateProvinceName],
//	[PostalCode],
//	[CountryRegionName],
//	[AdditionalContactInfo]
//FROM [HumanResources].[vEmployee];
//";

//SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

//try
//{
//    sqlConnection.Open();
//    using SqlDataReader reader = sqlCommand.ExecuteReader();
//    Employee employee = reader.ConvertToEntities<Employee>();
//    Console.WriteLine(employee);
//}
//catch (Exception ex)
//{
//    throw;
//}
//finally
//{
//    sqlConnection.Close();
//}

#endregion;

Console.ReadLine();
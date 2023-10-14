using Microsoft.Data.SqlClient;
using System.Data;

namespace ArticoleAdoDotNetAndEFCore;

public class Employee
{
    public int BusinessEntityID { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Suffix { get; set; }
    public string JobTitle { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneNumberType { get; set; }
    public string EmailAddress { get; set; }
    public int EmailPromotion { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string StateProvinceName { get; set; }
    public string PostalCode { get; set; }
    public string CountryRegionName { get; set; }
    public string AdditionalContactInfo { get; set; }

    public static implicit operator Employee(SqlDataReader reader)
    {
        Employee employee = new Employee();

        if (reader.Read())
        {
            employee.BusinessEntityID = (int)reader["BusinessEntityID"];
            employee.Title = reader["Title"] is DBNull ? string.Empty : (string)reader["Title"];
            employee.FirstName = reader["FirstName"] is DBNull ? string.Empty : (string)reader["FirstName"];
            employee.MiddleName = reader["MiddleName"] is DBNull ? string.Empty : (string)reader["MiddleName"];
            employee.LastName = reader["LastName"] is DBNull ? string.Empty : (string)reader["LastName"];
            employee.Suffix = reader["Suffix"] is DBNull ? string.Empty : (string)reader["Suffix"];
            employee.JobTitle = reader["JobTitle"] is DBNull ? string.Empty : (string)reader["JobTitle"];
            employee.PhoneNumber = reader["PhoneNumber"] is DBNull ? string.Empty : (string)reader["PhoneNumber"];
            employee.PhoneNumberType = reader["PhoneNumberType"] is DBNull ? string.Empty : (string)reader["PhoneNumberType"];
            employee.EmailAddress = reader["EmailAddress"] is DBNull ? string.Empty : (string)reader["EmailAddress"];
            employee.EmailPromotion = (int)reader["EmailPromotion"];
            employee.AddressLine1 = reader["AddressLine1"] is DBNull ? string.Empty : (string)reader["AddressLine1"];
            employee.AddressLine2 = reader["AddressLine2"] is DBNull ? string.Empty : (string)reader["AddressLine2"];
            employee.City = reader["City"] is DBNull ? string.Empty : (string)reader["City"];
            employee.StateProvinceName = reader["StateProvinceName"] is DBNull ? string.Empty : (string)reader["StateProvinceName"];
            employee.PostalCode = reader["PostalCode"] is DBNull ? string.Empty : (string)reader["PostalCode"];
            employee.CountryRegionName = reader["CountryRegionName"] is DBNull ? string.Empty : (string)reader["CountryRegionName"];
            employee.AdditionalContactInfo = reader["AdditionalContactInfo"] is DBNull ? string.Empty : (string)reader["AdditionalContactInfo"];
        }
        return employee;
    }

    //public static explicit operator Employee(SqlDataReader reader)
    //{
    //    Employee employee = new Employee();
    //    if (reader.Read())
    //    {
    //        employee.BusinessEntityID = (int)reader["BusinessEntityID"];
    //        employee.Title = reader["Title"] is DBNull ? string.Empty : (string)reader["Title"];
    //        employee.FirstName = reader["FirstName"] is DBNull ? string.Empty : (string)reader["FirstName"];
    //        employee.MiddleName = reader["MiddleName"] is DBNull ? string.Empty : (string)reader["MiddleName"];
    //        employee.LastName = reader["LastName"] is DBNull ? string.Empty : (string)reader["LastName"];
    //        employee.Suffix = reader["Suffix"] is DBNull ? string.Empty : (string)reader["Suffix"];
    //        employee.JobTitle = reader["JobTitle"] is DBNull ? string.Empty : (string)reader["JobTitle"];
    //        employee.PhoneNumber = reader["PhoneNumber"] is DBNull ? string.Empty : (string)reader["PhoneNumber"];
    //        employee.PhoneNumberType = reader["PhoneNumberType"] is DBNull ? string.Empty : (string)reader["PhoneNumberType"];
    //        employee.EmailAddress = reader["EmailAddress"] is DBNull ? string.Empty : (string)reader["EmailAddress"];
    //        employee.EmailPromotion = (int)reader["EmailPromotion"];
    //        employee.AddressLine1 = reader["AddressLine1"] is DBNull ? string.Empty : (string)reader["AddressLine1"];
    //        employee.AddressLine2 = reader["AddressLine2"] is DBNull ? string.Empty : (string)reader["AddressLine2"];
    //        employee.City = reader["City"] is DBNull ? string.Empty : (string)reader["City"];
    //        employee.StateProvinceName = reader["StateProvinceName"] is DBNull ? string.Empty : (string)reader["StateProvinceName"];
    //        employee.PostalCode = reader["PostalCode"] is DBNull ? string.Empty : (string)reader["PostalCode"];
    //        employee.CountryRegionName = reader["CountryRegionName"] is DBNull ? string.Empty : (string)reader["CountryRegionName"];
    //        employee.AdditionalContactInfo = reader["AdditionalContactInfo"] is DBNull ? string.Empty : (string)reader["AdditionalContactInfo"];
    //    }
    //    return employee;
    //}

    public override string ToString()
    {
        return $"{Title} - {FirstName} - {LastName} - {Suffix} - {JobTitle} - {PhoneNumber} - {PhoneNumberType} - {EmailAddress} - {EmailPromotion} - {AddressLine1} - {AddressLine2} - {City} - {StateProvinceName} - {PostalCode} - {CountryRegionName} - {AdditionalContactInfo}.";
    }
}

<Query Kind="Program">
  <Connection>
    <ID>bfa37636-2c1e-4c83-af63-94ccfbcc2891</ID>
    <NamingServiceVersion>3</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Server>localhost</Server>
    <Database>WestWind</Database>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{
//1.  assume this as your WEB APP
// pretend that main() is web app
List<Regions> regionData = Region_GetList();

//Linqpad use dump method to display collections

regionData.Dump();
	
}

// You can define other methods, fields, classes and namespaces here
//2. pretend that this area is your class library app with BLL folder here as collection of all services

// we need to write methods service methods which interact with database to fetch data

public List<Regions> Region_GetList() // entityname_methode
{
  IEnumerable <Regions> info = Regions.OrderBy(r => r.RegionDescription); 
  return info.ToList();
}
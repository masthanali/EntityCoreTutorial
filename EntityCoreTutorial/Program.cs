// See https://aka.ms/new-console-template for more information


using EntityCoreTutorial;
using EntityCoreTutorial.Models;
using Newtonsoft.Json;

//var context = new AlwebieeContext();

////saving data

////Account account = new()
////{
////    Id = 2,
////    Name = "ali",
////    Emailid = "ali@gmail.com",
////    Phonenumber = "9739678408",
////    Createddate = TimeOnly.MaxValue,
////    Updatedate = TimeOnly.MaxValue,
////    Isadmin = false

////};

////context.Accounts.Add(account);
////context.SaveChanges();


////Updating Data
////var account = context.Accounts.First<Account>();
////account.Name = "masthan ali";
////context.SaveChanges();

////var studentsWithSameName = context.Accounts
////                                  .Where(s => s.Name == "masthan ali")
////                                  .ToList();

////var Emailid = context.Accounts.Find(2).Emailid;

////Console.WriteLine(Emailid);


////Userinfo userinfo = new()
////{
////    Id = 1,
////    Connection = "test connection"
////};

////context.Userinfos.Add(userinfo);
////context.SaveChanges();

////var connectionname = context.Userinfos.Find(1);

////context.Userinfos.Remove(connectionname);
////context.SaveChanges();

//var connectionnames = context.Userinfos.Find(1);

//Console.WriteLine(connectionnames.Id);






CrudOperation crudOperation = new();

#region Save Data
Account saveaccount = new()
{
    Id = 3,
    Name = "Test 1",
    Emailid = "test1@gmail.com",
    Phonenumber = "7894561231",
    Isadmin = false,
};

bool Saveresult = crudOperation.SaveData(saveaccount);
Console.WriteLine(Saveresult);

#endregion

#region Update data
Account updateaccount = new()
{
    Id = 3,
    Name = "Test",
    Emailid = "test@gmail.com",
    Phonenumber = "789456123",
    Isadmin = true,
};

bool Updateresult = crudOperation.UpdateData(updateaccount.Id, updateaccount);
Console.WriteLine(Updateresult);
#endregion

#region Get Detail
Account accounts = crudOperation.GetAccount(updateaccount.Id);
Console.WriteLine(JsonConvert.SerializeObject(accounts));
#endregion

#region Get Details
List<Account> accountslist = crudOperation.GetAccounts();
Console.WriteLine(JsonConvert.SerializeObject(accountslist));
#endregion

#region Delete Data
bool deleteresult = crudOperation.DeleteData(updateaccount.Id);
Console.WriteLine(deleteresult);
#endregion


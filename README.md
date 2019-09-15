

## This Api contains one Controller which includ four endpoints:

* CreateContactAsync : to create a contact record
* GetAllContactAsync : to get all contact records with a query model
* GetContactByIdAsync : to get a contact record by id
* DeleteContact : to delete a contact record



**please refer to this  postman collecttion for testing**<br />
    [postman collection link](https://documenter.getpostman.com/view/1492108/SVmtyKMs)<br />
    Note: Localhost port number could be different, Please update based on your local configure
    
    
### testing work flow    
* first call CreateContactAsync to create couple contact enties.
 here are some sample call bodies:
 ``` 
 {
	"Name":"John",
	"Company":"test",
	"ProfileImageUrl":"asd.jpg",
	"Email":"asd@asd.com",
	"PersonalPhoneNumber":"123654789",
	"WorkPhoneNumber":"12345678",
	"StreetAddress":"1823 main st",
	"City":"Chicago",
	"State":"IL",
	"Country":"USA",
	"ZipCode":"60611"
} 
```

 ``` 
 {
	"Name":"Kevin",
	"Company":"test",
	"ProfileImageUrl":"asd.jpg",
	"Email":"asd@asd.com",
	"PersonalPhoneNumber":"123654789",
	"WorkPhoneNumber":"12345678",
	"StreetAddress":"1823 main st",
	"City":"New York",
	"State":"NY",
	"Country":"USA",
	"ZipCode":"16524"
} 
```

 ``` 
 {
	"Name":"Mike",
	"Company":"test",
	"ProfileImageUrl":"asd.jpg",
	"Email":"asd@asd.com",
	"PersonalPhoneNumber":"123654789",
	"WorkPhoneNumber":"12345678",
	"StreetAddress":"1823 main st",
	"City":"Chicago",
	"State":"IL",
	"Country":"USA",
	"ZipCode":"60611"
} 
```

* then try to get one record by Id <br />
	http://localhost:9546/api/Contact/GetContactByIdAsync?id=1
	
* try to get contact records by query model which include the following fields: <br />
```
	Id
        Name
        Company
        ProfileImageUrl 
        Email 
        Birthdate 
        WorkPhoneNumber 
        PersonalPhoneNumber 
        AddressId 
        StreetAddress 
        City 
        State 
        Country 
        ZipCode 
```

	**Note: will return all the records if query model is empty**
	Here are some sample request bodies:
	
```
{
	"Name":"John" 	//it will get all the contacts with Name equals "John"
}
```
```
{
	"City":"New York" 	//it will get all the contacts with city equals "New York"
}
```
```
{
	"City":"Chicago", 
	"State":"IL"		//it will get all the contacts with city equals "Chicago" **AND** state equals "IL"
}
```

* Finally, test the delete endpoint <br />
http://localhost:9546/api/Contact/DeleteContact?id=1 <br />
and then get the record to confirm the it is deleted <br />
http://localhost:9546/api/Contact/GetContactByIdAsync?id=1

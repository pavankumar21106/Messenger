# user creation in MS SQL

``` sql

CREATE LOGIN pavandemo
    WITH PASSWORD = 'test@123';  
GO  

CREATE USER pavandemo FOR LOGIN pavandemo;  
GO

GRANT ALTER, CREATE TABLE, DELETE, INSERT, SELECT, UPDATE  ON DATABASE::Messanger_Test TO pavandemo;
GO


--drop user pavandemo
--drop login pavandemo


```


``` sql 
CREATE LOGIN <user name>
    WITH PASSWORD = <password>;  
GO  

CREATE USER <user name> FOR LOGIN <user name>;  
GO

GRANT ALTER , CREATE TABLE, DELETE, INSERT, SELECT, UPDATE  ON DATABASE::<database name> TO <user name>;
GO


drop user <user name>
drop login <user name>

```


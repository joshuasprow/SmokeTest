use HMT_Testing
go

-- unlink existing user
alter role [udb_StoredProcedureExec] drop member [hmt_webuser]
go
alter role [db_datareader] drop member [hmt_webuser]
go
alter role [db_datawriter] drop member [hmt_webuser]
go

-- drop exisiting user and login
drop user [hmt_webuser]
go
drop login [hmt_webuser]
go

-- recreate user and login
create login [hmt_webuser] with password = N'G0at!HV@CFix', default_database = [HMT_Testing]
go
create user [hmt_webuser] for login [hmt_webuser] with default_schema = [dbo]
go

-- relink new user
alter role [udb_StoredProcedureExec] add member [hmt_webuser]
go
alter role [db_datareader] add member [hmt_webuser]
go
alter role [db_datawriter] add member [hmt_webuser]
go
CREATE TABLE [dbo].[Group]
(
	Id int not null identity(1,1),
	Number int not null,

	constraint Pk_Group_GroupId primary key(Id)
)

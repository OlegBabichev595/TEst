CREATE TABLE [dbo].[Group]
(
	GroupId int not null identity(1,1),
	Number int not null,

	constraint Pk_Group_GroupId primary key(GroupId)
)

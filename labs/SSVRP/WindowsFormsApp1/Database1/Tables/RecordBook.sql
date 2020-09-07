CREATE TABLE [dbo].[RecordBook]
(
	RecordBookId int not null identity(1,1),
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	Course int not null,
	GroupId int not null,

	constraint Pk_Group_RecordBookId primary key(RecordBookId),
	constraint Fk_Group_GroupId foreign key(GroupId) references dbo.[Group](GroupId)
)
